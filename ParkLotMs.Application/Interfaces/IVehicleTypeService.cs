using ParkLotMs.Application.Models.Requests;
using ParkLotMs.DataAccess.Models;

namespace ParkLotMs.Application.Interfaces
{
    public interface IVehicleTypeService
    {
        Task<IEnumerable<VehicleTypeModel>> GetAll(VehicleTypeRequest request);
        Task InsertData(AddVehicleTypeRequest request);
        Task UpdateData(UpdateVehicleTypeRequest request);
        Task DeleteData(Guid id , bool usingSoftDelete, string deleteBy);
    }
}