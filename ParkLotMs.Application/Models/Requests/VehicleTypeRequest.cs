using System.ComponentModel.DataAnnotations;

namespace ParkLotMs.Application.Models.Requests;

public class VehicleTypeRequest
{
    public string Keyword { get; set; }
    public string OrderBy { get; set; }
    public string OrderType { get; set; } = "ASC";
    public int Start { get; set; } = 0;
    public int Length { get; set; } = 10;

}
public class AddVehicleTypeRequest
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal MinParkingFee { get; set; }
    public decimal MaxParkingFee { get; set; }
    public decimal ProgParkingFee { get; set; }
    public string CreatedBy { get; set; }
}

public class UpdateVehicleTypeRequest: AddVehicleTypeRequest
{
    [Required]
    public Guid Id { get; set; }
}
