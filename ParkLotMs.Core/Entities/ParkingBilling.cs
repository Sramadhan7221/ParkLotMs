namespace ParkLotMs.Core.Entities;

public class ParkingBilling:BaseEntityClass
{
    public string VehicleRegNumber { get; set; }
    public Guid TypeId { get; set; }
    public Guid AreaSlotId { get; set; }
    public DateTime? CheckIn { get; set; }
    public DateTime? CheckOut { get; set; }
    public decimal ParkingCost { get; set; }
    public string CheckInImg { get; set; }
    public virtual ParkingArea Area { get; set; }
    public virtual VehicleType VehicleType { get; set; }
    public virtual Payment Payment { get; set; }
}
