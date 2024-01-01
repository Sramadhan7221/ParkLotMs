using Dapper;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Npgsql;

namespace ParkLotMs.DataAccess.DbAccess;

public class SqlDataAccess : ISqlDataAccess
{
	private readonly IConfiguration _config;
	public SqlDataAccess(IConfiguration config)
	{
		_config = config;
	}

	public async Task<IEnumerable<T>> LoadData<T, U>(string query, U parameters, string connectionId = "DefaultConnection")
	{
		var connectionString = _config.GetConnectionString(connectionId);
        using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));

        return await connection.QueryAsync<T>(query, parameters);
	}

	public async Task SaveData<T>(string query, T parameters, string connectionId = "DefaultConnection")
	{
		using IDbConnection connection = new NpgsqlConnection(_config.GetConnectionString(connectionId));

		await connection.ExecuteAsync(query, parameters);
	}
}
