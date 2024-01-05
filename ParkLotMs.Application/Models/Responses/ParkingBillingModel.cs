using System.ComponentModel.DataAnnotations.Schema;

namespace ParkLotMs.Application.Models.Responses;

public class ParkingBillingModel
{
    public Guid Id { get; set; }
    public string AreaName { get; set; }
    public string SlotsName { get; set; }
    public string VehicleRegNumber { get; set; }
    public string VehicleName { get; set; }
    public DateTime? CheckIn { get; set; }
    public DateTime? CheckOut { get; set; }
    public decimal ParkingCost { get; set; }
}
