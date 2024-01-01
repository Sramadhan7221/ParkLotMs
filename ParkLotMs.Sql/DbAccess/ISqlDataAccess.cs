namespace ParkLotMs.DataAccess.DbAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string query, U parameters, string connectionId = "DefaultConnection");
        Task SaveData<T>(string query, T parameters, string connectionId = "DefaultConnection");
    }
}