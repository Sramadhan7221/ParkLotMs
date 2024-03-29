﻿using ParkLotMs.Application.Models.Requests;
using System.Text.Json.Serialization;

namespace ParkLotMs.WebApi.ViewModels;

public class InsertParkingAreaViewModel
{
    [JsonPropertyName("area_name")]
    public string AreaName { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("max")]
    public decimal Max { get; set; }
    [JsonPropertyName("type_id")]
    public Guid TypeId { get; set; }
}

public class UpdateParkingAreaViewModel: InsertParkingAreaViewModel
{
    [JsonPropertyName("area_id")]
    public Guid AreaId { get; set; }
    [JsonPropertyName("status")]
    public string Status { get; set; }
}
