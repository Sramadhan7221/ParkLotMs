using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkLotMs.Core.Entities;

public class ParkingSlot:BaseEntityClass
{

    [ForeignKey("ParkingArea")]
    public Guid AreaId { get; set; }
    [StringLength(255)]
    public string Name { get; set; }
    public string Status { get; set; }
    public virtual ParkingArea ParkingArea { get; set; }
}
