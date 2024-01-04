using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkLotMs.Application.Interfaces;
using ParkLotMs.WebApi.ViewModels;

namespace ParkLotMs.WebApi.Controllers;

public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    public IActionResult Login([FromBody] UserLoginViewModel request)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

		try
		{
			string userToken = _authService.Login(request.UserName, request.Password);
		}
		catch (Exception)
		{

			throw;
		}
		return Ok();
    }
}
