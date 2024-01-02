using Dapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ParkLotMs.Application.Interfaces;
using ParkLotMs.Application.Models.Requests;
using ParkLotMs.Core.Entities;
using ParkLotMs.DataAccess.DbAccess;
using ParkLotMs.DataAccess.Models;

namespace ParkLotMs.Application.Services;

public class ParkingAreaServices : IParkingAreaServices
{
	private readonly ISqlDataAccess _dataAccess;
	public ParkingAreaServices(ISqlDataAccess dataAccess)
	{
		_dataAccess = dataAccess;
	}

	public async Task<IEnumerable<ParkingAreaModel>> GetPakingAreas(ParkingAreaRequest request)
	{
        var builder = new SqlBuilder();
        var selector = builder.AddTemplate($"SELECT pa.\"Id\",pa.\"Name\", pa.\"Descriptions\", pa.\"MaxCapacity\", \"TypeId\", \"Status\", vt.\"Name\" VehicleName FROM \"ParkingAreas\" pa " +
			$"JOIN \"VehicleTypes\" vt ON pa.\"TypeId\" = vt.\"Id\" LIMIT @limit OFFSET @offset", new { limit = request.Length, offset = request.Start });
        if (!string.IsNullOrWhiteSpace(request.Keyword))
            builder.Where($"(\"Name\" ILIKE @keyword OR \"Descriptions\" ILIKE @keyword)", new { keyword = string.Concat("%", request.Keyword, "%") });

        var data = await _dataAccess.LoadData<ParkingArea, dynamic>(selector.RawSql, selector.Parameters);
		var slotsData = await _dataAccess.LoadData<ParkingSlot, dynamic>("SELECT * FROM \"ParkingSlots\" WHERE \"AreaId\" IN (@areaId)", new {areaId = string.Join(",",data.Select(x => x.Id))});

        return data.Select(x => new ParkingAreaModel
		{
			AreaId = x.Id,
			AreaName = x.Name,
			Description = x.Descriptions,
			MaxCapacity = x.MaxCapacity,
			Status = x.Status,
			VehicleName = x.VehicleName,
			ParkingSlots = slotsData.Where(y => y.AreaId == x.Id).Select(y => new ParkingSlotModel
			{
				SlotId = y.Id,
				SlotName = y.Name,
				Status = y.Status,
				ParkingArea = new ParkingAreaModel {
                    AreaId = x.Id,
                    AreaName = x.Name,
                    Description = x.Descriptions,
                    MaxCapacity = x.MaxCapacity,
                    Status = x.Status,
                    VehicleName = x.VehicleName
                }
			}).ToList()
		});
	}

	public Task InsertData(AddParkingAreaRequest request)
	{
		var query = $"INSERT INTO \"ParkingAreas\" (\"Id\",\"Name\",\"Descriptions\",\"MaxCapacity\",\"TypeId\",\"Status\",\"CreatedBy\",\"CreatedAt\") VALUES (@id,@name,@desc,@max,@type,@status,@createdBy,@createdAt)";
		return _dataAccess.SaveData(query, new {id = Guid.NewGuid(), name = request.Name, desc = request.Descriptions, max = request.MaxCapacity, type = request.VehicleType, status = request.Status.ToString(), createdBy = request.CreatedBy, createdAt = DateTime.UtcNow});
	}

    public Task UpdateData(UpdateParkingAreaRequest request)
    {
        var query = $"UPDATE \"ParkingAreas\" SET \"Name\" = COALESCE(@name, \"Name\") ,\"Descriptions\" = COALESCE(@desc, \"Descriptions\") ,\"MaxCapacity\" = COALESCE(@max,\"MaxCapacity\") ,\"TypeId\" = COALESCE(@type,\"TypeId\"),\"Status\" = COALESCE(@status,\"Status\"),\"UpdatedBy\" = @updatedBy ,\"UpdatedAt\" = @updateAt WHERE \"Id\" = @id ";

        return _dataAccess.SaveData(query, new { id = request.Id, name = request.Name, desc = request.Descriptions, max = request.MaxCapacity, type = request.VehicleType, status = request.Status.ToString(), updatedBy = request.CreatedBy, updateAt = DateTime.UtcNow });
    }

    public Task DeleteData(Guid id, bool usingSoftDelete, string deleteBy)
    {
        var query = $"UPDATE \"ParkingAreas\" SET \"DeletedAt\" = @deleted, \"DeletedBy\" = @deleteBy WHERE \"Id\" = @id ";
        if (!usingSoftDelete)
            query = $"DELETE FROM \"ParkingAreas\" WHERE \"Id\" = @id  ";

        return _dataAccess.SaveData(query, new { id, deleted = DateTime.UtcNow, deleteBy });
    }
}
