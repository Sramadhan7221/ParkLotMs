namespace ParkLotMs.Application.Models.Requests;

public enum Status {Available,Reserved,Full}
public class ParkingAreaRequest
{
    public string Keyword { get; set; }
    public Status Status { get; set; }
    public string OrderBy { get; set; }
    public string OrderType { get; set; }
    public int Start { get; set; } = 0;
    public int Length { get; set; } = 10;
}

public class AddParkingAreaRequest
{
    public string Name { get; set; }
    public string Descriptions { get; set; }
    public decimal MaxCapacity { get; set; }
    public Guid VehicleType { get; set; }
    public Status Status { get; set; }
    public string CreatedBy { get; set; }
}
