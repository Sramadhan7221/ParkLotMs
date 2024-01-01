using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkLotMs.Core.Entities;

public class ParkingBilling:BaseEntityClass
{

    [StringLength(100)]
    public string VehicleRegNumber { get; set; }
    [ForeignKey("VehicleType")]
    public Guid TypeId { get; set; }
    [ForeignKey("ParkingSlot")]
    public Guid AreaSlotId { get; set; }
    public DateTime? CheckIn { get; set; }
    public DateTime? CheckOut { get; set; }
    public decimal ParkingCost { get; set; }
    public string CheckInImg { get; set; }
    public virtual ParkingSlot Slot { get; set; }
    public virtual VehicleType VehicleType { get; set; }
    public virtual Payment Payment { get; set; }
}
