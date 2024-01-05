using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkLotMs.Application.Interfaces;
using ParkLotMs.Application.Models.Requests;
using ParkLotMs.DataAccess.Models;
using ParkLotMs.WebApi.ViewModels;

namespace ParkLotMs.WebApi.Controllers;

//[Authorize]
public class ParkingBillingController : ControllerBase
{
    private readonly IParkingBillingServices _parkingBilingService;

    public ParkingBillingController(IParkingBillingServices parkingBilingService)
    {
        _parkingBilingService = parkingBilingService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ParkingBillingModel>), 200)]
    [Route("/api/billing")]
    public async Task<IActionResult> Index(ParkingBillingRequest request)
    {
        var data = await _parkingBilingService.Get(request);
        return Ok(data);
    }

    [HttpPost]
    [Route("/api/billing/add")]
    public IActionResult InsertParkingArea([FromBody] AddParkingBillingRequest request)
    {
        _parkingBilingService.InsertData(request);

        return Ok();
    }

    [HttpPut]
    [Route("/api/billing/update")]
    public IActionResult UpdateParkingArea([FromBody] UpdateParkingbilling request)
    {
        _parkingBilingService.UpdateData(request);

        return Ok();
    }

    [HttpDelete]
    [Route("/api/billing/delete/{id}"), Authorize(Roles = "Superadmin")]
    public IActionResult DeleteArea(Guid id, bool usingSoftDelete)
    {
        _parkingBilingService.DeleteData(id, usingSoftDelete, "Test");

        return Ok();
    }
}
