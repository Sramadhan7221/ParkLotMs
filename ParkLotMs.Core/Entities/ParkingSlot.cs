namespace ParkLotMs.Core.Entities;

public class ParkingSlot:BaseEntityClass
{
    public Guid AreaId { get; set; }
    public string Name { get; set; }
    public string Status { get; set; }
    
}
