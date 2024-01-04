
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkLotMs.Application.Interfaces;
using ParkLotMs.Application.Models.Requests;
using ParkLotMs.Application.Services;
using ParkLotMs.DataAccess.Models;
using ParkLotMs.WebApi.ViewModels;

namespace ParkLotMs.WebApi.Controllers;

[Authorize]
public class VehicleTypeController : ControllerBase
{
    private readonly IVehicleTypeService _vehicleService;

	public VehicleTypeController(IVehicleTypeService vehicleService)
	{
		_vehicleService = vehicleService;
	}

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<VehicleTypeModel>), 200)]
    [Route("/api/vehicle")]
    public async Task<IActionResult> Index(VehicleTypeRequest request)
    {
        var data = await _vehicleService.GetAll(request);
        return Ok(data);
    }

    [HttpPost]
    [Route("/api/vehicle/add")]
    public IActionResult InsertVehicle([FromBody] InsertVehicleTypeViewModel request)
    {
        _vehicleService.InsertData(new AddVehicleTypeRequest
        {
            Name = request.TypeName,
            Description = request.Description,
            MaxParkingFee = request.MaxParkingFee,
            MinParkingFee = request.MinParkingFee,
            ProgParkingFee = request.ProgParkingFee,
            CreatedBy = "Test"
        });

        return Ok();
    }

    [HttpPut]
    [Route("/api/vehicle/update")]
    public IActionResult UpdateVehicle([FromBody] UpdateVehicleTypeViewModel request)
    {
        _vehicleService.UpdateData(new UpdateVehicleTypeRequest
        {
            Id = request.TypeId,
            Name = request.TypeName,
            Description = request.Description,
            MaxParkingFee = request.MaxParkingFee,
            MinParkingFee = request.MinParkingFee,
            ProgParkingFee = request.ProgParkingFee,
            CreatedBy = "Test"
        });

        return Ok();
    }

    [HttpDelete]
    [Route("/api/vehicle/delete/{id}")]
    public IActionResult DeleteVehicle(Guid id, bool usingSoftDelete)
    {
        _vehicleService.DeleteData(id, usingSoftDelete, "Test");

        return Ok();
    }
}
