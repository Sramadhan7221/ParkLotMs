using System.ComponentModel.DataAnnotations;

namespace ParkLotMs.Core.Entities;
public class VehicleType:BaseEntityClass
{
    [StringLength(255)]
    public string Name { get; set; }
    [StringLength(500)]
    public string Description { get; set; }
    public decimal MinParkingFee { get;set; }
    public decimal MaxParkingFee { get;set; }
    public decimal ProgParkingFee { get;set; }
}
