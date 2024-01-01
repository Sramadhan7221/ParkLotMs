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
		var selector = builder.AddTemplate($"");

        var filters = $"AND \"Status\" = '{request.Status}' ";
		var orderType = string.IsNullOrWhiteSpace(request.OrderType) ? "ASC " : request.OrderType;
		var orderBy = $"\"Name\" {orderType} ";
		if (!string.IsNullOrWhiteSpace(request.Keyword))
			filters += $"AND \"Name\" ILIKE '%{request.Keyword}%' ";
		if (!string.IsNullOrWhiteSpace(request.OrderBy))
			orderBy = $"{request.OrderBy} {orderType} ";

		var query = new
		{
			Table = "\"ParkingAreas\"",
			Filter = filters,
			OrderBy = orderBy,
			Limit = request.Length,
			Offset = request.Start
		};

		var data = await _dataAccess.LoadData<ParkingArea, dynamic>(SqlQueries.GetAll, query);

		return data.Select(x => new ParkingAreaModel
		{
			AreaId = x.Id,
			AreaName = x.Name,
			Description = x.Descriptions,
			MaxCapacity = x.MaxCapacity,
			Status = x.Status
		});
	}

	public Task InsertData(AddParkingAreaRequest request)
	{
		var query = new
		{
			Table = "\"ParkingAreas\"",
			Key = "\"Id\",\"Name\",\"Descriptions\",\"MaxCapacity\",\"VehicleType\",\"Status\",\"CreatedBy\",\"CreatedAt\" ",
			Value = $"'{Guid.NewGuid()}','{request.Name}','{request.Descriptions}',{request.MaxCapacity},'{request.VehicleType}','{request.Status}','{request.CreatedBy}','{DateTime.UtcNow}' "
        };

		return _dataAccess.SaveData(SqlQueries.Insert, query);
	}

	//public async Task<ParkingAreaModel> GetParkingAreaById(string id)
	//{
	//	var joins = $"JOIN ";

	//}
}
