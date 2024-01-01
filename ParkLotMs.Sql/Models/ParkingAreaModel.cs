using System.Text.Json.Serialization;

namespace ParkLotMs.DataAccess.Models;

public class ParkingAreaModel
{
    [JsonPropertyName("area_id")]
    public Guid AreaId { get; set; }
    [JsonPropertyName("area_name")]
    public string AreaName { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("max_capacity")]
    public decimal MaxCapacity { get; set; }
    [JsonPropertyName("status")]
    public string Status { get; set; }
    [JsonPropertyName("type")]
    public VehicleTypeModel Type { get; set; }
    [JsonPropertyName("parking_slots")]
    public ICollection<ParkingSlotModel> ParkingSlots { get; set; }
}
