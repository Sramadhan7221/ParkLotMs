
using System.Text.Json.Serialization;

namespace ParkLotMs.DataAccess.Models;
public class ParkingSlotModel
{
    [JsonPropertyName("slot_id")]
    public Guid SlotId { get; set; }
    [JsonPropertyName("slot_name")]
    public string SlotName { get; set; }
    [JsonPropertyName("status")]
    public string Status { get; set; }
    [JsonPropertyName("parking_area")]
    public ParkingAreaModel ParkingArea { get; set; }
}
