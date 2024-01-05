using ParkLotMs.Application.Models.Requests;
using ParkLotMs.DataAccess.Models;

namespace ParkLotMs.Application.Interfaces
{
    public interface IParkingBillingServices
    {
        Task DeleteData(Guid id, bool usingSoftDelete, string deleteBy);
        Task<IEnumerable<ParkingBillingModel>> Get(ParkingBillingRequest request);
        Task InsertData(AddParkingBillingRequest request);
        Task<Task> UpdateData(UpdateParkingbilling request);
    }
}