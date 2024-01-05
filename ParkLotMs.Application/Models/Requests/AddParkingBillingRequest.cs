
namespace ParkLotMs.Application.Models.Requests;

public class AddParkingBillingRequest
{
    public string VehicleRegNumber { get; set; }
    public string CreatedBy { get; set; }
    public Guid TypeId { get; set; }
    public Guid AreaSlotId { get; set; }
}

public class UpdateParkingbilling
{
    public DateTime? CheckOut { get; set; }
    public Guid Id { get; set; }

    public string CreatedBy { get; set; }
}

public class ParkingBillingRequest {
    public string Keyword { get; set; }
    public Status Status { get; set; }
    public string OrderBy { get; set; }
    public string OrderType { get; set; }
    public DateTime? from { get; set; }
    public DateTime? to { get; set; }
    public int Start { get; set; } = 0;
    public int Length { get; set; } = 10;
}