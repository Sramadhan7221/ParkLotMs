using Dapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ParkLotMs.Application.Interfaces;
using ParkLotMs.Application.Models.Requests;
using ParkLotMs.Core.Entities;
using ParkLotMs.DataAccess.DbAccess;
using ParkLotMs.DataAccess.Models;

namespace ParkLotMs.Application.Services;

public class ParkingBillingServices : IParkingBillingServices
{
    private readonly ISqlDataAccess _dataAccess;
    public ParkingBillingServices(ISqlDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public async Task<IEnumerable<ParkingBillingModel>> Get(ParkingBillingRequest request)
    {
        var builder = new SqlBuilder();
        var selector = builder.AddTemplate($"SELECT pb.\"Id\",pb.\"VehicleRegNumber\", pb.\"CheckIn\", pb.\"CheckOut\", pb.\"ParkingCost\", vt.\"Name\" VehicleName, ps.\"Name\" SlotsName, pa.\"Name\" AreaName FROM \"ParkingBillings\" pb " +
            $"JOIN \"VehicleTypes\" vt ON pa.\"TypeId\" = vt.\"Id\" " +
            $"JOIN \"ParkingSlots\" ps ON pb.\"SlotId\" = ps.\"Id\" " +
            $"JOIN \"ParkingAreas\" pa ON pa.\"Id\" = ps.\"AreaId\" " +
            $"LIMIT @limit OFFSET @offset", new { limit = request.Length, offset = request.Start });
        if (!string.IsNullOrWhiteSpace(request.Keyword))
            builder.Where($"(\"VehicleRegNumber\" ILIKE @keyword )", new { keyword = string.Concat("%", request.Keyword, "%") });

        if (request.from != null)
            builder.Where($"(\"CheckIn\" >= @from )", new { keyword = request.from });
        if (request.to != null)
            builder.Where($"(\"CheckIn\" <= @to )", new { keyword = request.to });

        var data = await _dataAccess.LoadData<ParkingBillingModel, dynamic>(selector.RawSql, selector.Parameters);

        return data;
    }

    public Task InsertData(AddParkingBillingRequest request)
    {
        var query = $"INSERT INTO \"ParkingBillings\" (\"Id\",\"VehicleRegNumber\",\"TypeId\",\"AreaSlotId\",\"CheckIn\",\"SlotId\",\"CreatedBy\",\"CreatedAt\") " +
            $"VALUES (@id,@vehicle,@type,@slot,@slot,@cekin,@createdBy,@createdAt)";

        return _dataAccess.SaveData(query, request);
    }

    public async Task<Task> UpdateData(UpdateParkingbilling request)
    {
        var billingsData = await _dataAccess.LoadData<ParkingBilling, dynamic>("SELECT * FROM \"ParkingBillings\" WHERE \"Id\" = @id", new { id = request.Id });
        var billing = billingsData.FirstOrDefault();
        if (billing == null)
            throw new ApplicationException("Billing data not found");

        var vehicleData = await _dataAccess.LoadData<VehicleType, dynamic>("SELECT * FROM \"VehicleTypes\" WHERE \"Id\" = @id", new { id = billing.TypeId });
        var vehicle = vehicleData.FirstOrDefault();
        if (vehicle == null)
            throw new ApplicationException("Vehicle data not found");

        var duration = billing.CheckIn - (billing.CheckOut ?? DateTime.UtcNow);
        var totalHour = (float)Math.Round(duration.Value.TotalHours, 1);
        var totalCost = (decimal)totalHour * vehicle.ProgParkingFee;

        if (totalCost > vehicle.MaxParkingFee)
            totalCost = vehicle.MaxParkingFee;
        if (totalCost < 1)
            totalCost = vehicle.MinParkingFee;

        var query = $"UPDATE \"ParkingBillings\" SET \"CheckOut\" = @cekout ,\"ParkingCost\" = @cost, \"UpdatedBy\" = @updatedBy ,\"UpdatedAt\" = @updateAt WHERE \"Id\" = @id ";

        return Task.FromResult(_dataAccess.SaveData(query, new { id = request.Id, cekout = DateTime.UtcNow, cost = totalCost, updatedBy = request.CreatedBy, updateAt = DateTime.UtcNow }));
    }

    public Task DeleteData(Guid id, bool usingSoftDelete, string deleteBy)
    {
        var query = $"UPDATE \"ParkingBillings\" SET \"DeletedAt\" = @deleted, \"DeletedBy\" = @deleteBy WHERE \"Id\" = @id ";
        if (!usingSoftDelete)
            query = $"DELETE FROM \"ParkingBillings\" WHERE \"Id\" = @id  ";

        return _dataAccess.SaveData(query, new { id, deleted = DateTime.UtcNow, deleteBy });
    }
}
