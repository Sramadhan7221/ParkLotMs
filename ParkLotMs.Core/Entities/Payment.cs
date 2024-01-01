namespace ParkLotMs.Core.Entities;

public class Payment:BaseEntityClass
{
    public Guid BillingId { get; set; }
    public decimal Amount { get; set; }
    public decimal Balance { get; set; }
}
