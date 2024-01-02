using ParkLotMs.Application.Models.Requests;
using ParkLotMs.DataAccess.Models;

namespace ParkLotMs.Application.Interfaces
{
    public interface IParkingAreaServices
    {
        Task<IEnumerable<ParkingAreaModel>> GetPakingAreas(ParkingAreaRequest request);
        Task InsertData(AddParkingAreaRequest request);
        Task UpdateData(UpdateParkingAreaRequest request);
        Task DeleteData(Guid id, bool usingSoftDelete, string deleteBy);
    }
}