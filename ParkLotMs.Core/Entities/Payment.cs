using System.ComponentModel.DataAnnotations.Schema;

namespace ParkLotMs.Core.Entities;

public class Payment:BaseEntityClass
{

    [ForeignKey("ParkingBilling")]
    public Guid BillingId { get; set; }
    public decimal Amount { get; set; }
    public decimal Balance { get; set; }
    public virtual ParkingBilling ParkingBilling { get; set; }
}
