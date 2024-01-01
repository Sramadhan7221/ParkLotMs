using System.Text.Json.Serialization;

namespace ParkLotMs.DataAccess.Models;

public class ParkingBillingModel
{
    [JsonPropertyName("billing_id")]
    public Guid BillingId { get; set; }
    [JsonPropertyName("vehicle_reg_number")]
    public string VehicleRegNumber { get; set; }
    //[JsonPropertyName("billing_id")]
    //public Guid BillingId { get; set; }
    //[JsonPropertyName("billing_id")]
    //public Guid BillingId { get; set; }
    //[JsonPropertyName("billing_id")]
    //public Guid BillingId { get; set; }
    //[JsonPropertyName("billing_id")]
    //public Guid BillingId { get; set; }
    //[JsonPropertyName("billing_id")]
    //public Guid BillingId { get; set; }

}
