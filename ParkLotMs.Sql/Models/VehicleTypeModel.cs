using System.Text.Json.Serialization;

namespace ParkLotMs.DataAccess.Models
{
    public class VehicleTypeModel
    {
        [JsonPropertyName("type_id")]
        public Guid TypeId { get; set; }
        [JsonPropertyName("type_name")]
        public string TypeName { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("min_parking_fee")]
        public decimal MinParkingFee { get; set; }
        [JsonPropertyName("max_parking_fee")]
        public decimal MaxParkingFee { get; set; }
        [JsonPropertyName("prog_parking_fee")]
        public decimal ProgParkingFee { get; set; }
    }
}
