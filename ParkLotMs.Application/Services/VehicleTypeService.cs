using Dapper;
using ParkLotMs.Application.Interfaces;
using ParkLotMs.Application.Models.Requests;
using ParkLotMs.Core.Entities;
using ParkLotMs.DataAccess.DbAccess;
using ParkLotMs.DataAccess.Models;

namespace ParkLotMs.Application.Services;

public class VehicleTypeService : IVehicleTypeService
{
    private readonly ISqlDataAccess _dataAccess;
    public VehicleTypeService(ISqlDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<IEnumerable<VehicleTypeModel>> GetAll(VehicleTypeRequest request)
    {
        var builder = new SqlBuilder();
        var selector = builder.AddTemplate($"SELECT \"Id\",\"Name\", \"Description\", \"MinParkingFee\", \"MaxParkingFee\", \"ProgParkingFee\" FROM \"VehicleTypes\" LIMIT @limit OFFSET @offset", new { limit = request.Length, offset = request.Start});
        if (!string.IsNullOrWhiteSpace(request.Keyword))
            builder.Where($"(\"Name\" ILIKE @keyword OR \"Description\" ILIKE @keyword)", new { keyword = string.Concat("%", request.Keyword, "%") });

        var data = await _dataAccess.LoadData<VehicleType, dynamic>(selector.RawSql, selector.Parameters);

        return data.Select(x => new VehicleTypeModel
        {
            TypeId = x.Id,
            TypeName = x.Name,
            Description = x.Description,
            MaxParkingFee = x.MaxParkingFee,
            MinParkingFee = x.MinParkingFee,
            ProgParkingFee = x.ProgParkingFee
        });
    }

    public Task InsertData(AddVehicleTypeRequest request)
    {
        var query = $"INSERT INTO \"VehicleTypes\" (\"Id\",\"Name\",\"Description\",\"MaxParkingFee\",\"MinParkingFee\",\"ProgParkingFee\",\"CreatedBy\",\"CreatedAt\") " +
            $"VALUES (@id,@name,@desc,@max,@min,@prog,@createdBy,@createdAt)";

        return _dataAccess.SaveData(query, new {id = Guid.NewGuid() ,name = request.Name, desc = request.Description, max = request.MaxParkingFee, min = request.MinParkingFee, prog = request.ProgParkingFee, createdBy = request.CreatedBy, createdAt = DateTime.UtcNow });
    }


    public Task UpdateData(UpdateVehicleTypeRequest request)
    {
        var query = $"UPDATE \"VehicleTypes\" SET \"Name\" = @name ,\"Description\" = @desc ,\"MaxParkingFee\" = @max ,\"MinParkingFee\" = @min ,\"ProgParkingFee\" = @prog ,\"UpdatedBy\" = @updatedBy ,\"UpdatedAt\" = @updateAt ";

        return _dataAccess.SaveData(query, new { id = request.Id, name = request.Name, desc = request.Description, max = request.MaxParkingFee, min = request.MinParkingFee, prog = request.ProgParkingFee, updatedBy = request.CreatedBy, updateAt = DateTime.UtcNow });
    }
    public Task DeleteData(Guid id, bool usingSoftDelete, string deleteBy)
    {
        var query = $"UPDATE \"VehicleTypes\" SET \"DeletedAt\" = @deleted, \"DeletedBy\" = @deleteBy WHERE \"Id\" = @id ";
        if (!usingSoftDelete)
            query = $"DELETE FROM \"VehicleTypes\" WHERE \"Id\" = @id  ";

        return _dataAccess.SaveData(query, new { id, deleted = DateTime.UtcNow, deleteBy });
    }
}
