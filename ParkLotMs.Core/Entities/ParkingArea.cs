using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkLotMs.Core.Entities;

public class ParkingArea:BaseEntityClass
{
    [StringLength(255)]
    public string Name { get; set; }
    [StringLength(500)]
    public string Descriptions { get; set; }
    public decimal MaxCapacity { get; set; }
    [ForeignKey("VehicleType")]
    public Guid VehicleType { get;set; }
    public string Status { get; set; }
    public virtual VehicleType Type { get; set; }
    public virtual ICollection<ParkingSlot> ParkingSlots { get; set; }
}
