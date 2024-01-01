
namespace ParkLotMs.Core.Entities;
public class VehicleType:BaseEntityClass
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal MinParkingFee { get;set; }
    public decimal MaxParkingFee { get;set; }
    public decimal ProgParkingFee { get;set; }
}
