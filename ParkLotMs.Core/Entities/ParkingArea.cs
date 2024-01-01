namespace ParkLotMs.Core.Entities;

public class ParkingArea:BaseEntityClass
{
    public string Name { get; set; }
    public string Descriptions { get; set; }
    public decimal MaxCapacity { get; set; }
    public Guid VehicleType { get;set; }
    public string Status { get; set; }
    public virtual VehicleType Type { get; set; }
    public virtual ICollection<ParkingSlot> ParkingSlots { get; set; }
}
