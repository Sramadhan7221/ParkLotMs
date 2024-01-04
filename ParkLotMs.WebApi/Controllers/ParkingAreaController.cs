using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkLotMs.Application.Interfaces;
using ParkLotMs.Application.Models.Requests;
using ParkLotMs.DataAccess.Models;
using ParkLotMs.WebApi.ViewModels;

namespace ParkLotMs.WebApi.Controllers;

[Authorize]
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

    [HttpPut]
    [Route("/api/parking-area/update")]
    public IActionResult UpdateParkingArea([FromBody] UpdateParkingAreaViewModel request)
    {
        if (Enum.TryParse(request.Status, out Status parsedEnum))
        {
            _parkingAreaService.UpdateData(new UpdateParkingAreaRequest
            {
                Name = request.AreaName,
                Descriptions = request.Description,
                MaxCapacity = request.Max,
                VehicleType = request.TypeId,
                CreatedBy = "Test",
                Status = parsedEnum,

            });
        }
        else
        {
            return BadRequest(new {Message = "Incorrect Status"});
        }

        return Ok();
    }

    [HttpDelete]
    [Route("/api/parking-area/delete/{id}")]
    public IActionResult DeleteArea(Guid id, bool usingSoftDelete)
    {
        _parkingAreaService.DeleteData(id, usingSoftDelete, "Test");

        return Ok();
    }
}
