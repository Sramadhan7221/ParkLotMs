using Microsoft.AspNetCore.Mvc;
using ParkLotMs.Application.Interfaces;
using ParkLotMs.Application.Models.Requests;
using ParkLotMs.DataAccess.Models;
using ParkLotMs.WebApi.ViewModels;

namespace ParkLotMs.WebApi.Controllers;

public class ParkingAreaController : ControllerBase
{
    private readonly IParkingAreaServices _parkingAreaService;

    public ParkingAreaController(IParkingAreaServices parkingAreaService)
    {
        _parkingAreaService = parkingAreaService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ParkingAreaModel>), 200)]
    [Route("/api/parking-area")]
    public async Task<IActionResult> Index(ParkingAreaRequest request)
    {
        var data = await _parkingAreaService.GetPakingAreas(request);
        return Ok(data);
    }

    [HttpPost]
    [Route("/api/parking-area/add")]
    public IActionResult InsertParkingArea([FromBody] InsertParkingAreaViewModel request)
    {
        _parkingAreaService.InsertData(new AddParkingAreaRequest
        {
            Name = request.AreaName,
            Descriptions = request.Description,
            MaxCapacity = request.Max,
            VehicleType = request.TypeId,
            CreatedBy = "Test",
            Status = Status.Available
        });

        return Ok();
    }
}
