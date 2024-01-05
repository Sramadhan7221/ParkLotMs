using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ParkLotMs.Application.Interfaces;
using ParkLotMs.Core.Entities;
using ParkLotMs.DataAccess.Models;
using ParkLotMs.Infrastructure.Authentication;
using ParkLotMs.WebApi.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ParkLotMs.WebApi.Controllers;

public class AuthController : ControllerBase
{

    private readonly IAuthService _authService;
    public AuthController(IAuthService authService) 
	{
		_authService = authService;
	}

	[HttpPost]
    [Route("/api/auth/login")]
    public IActionResult Login([FromBody] UserViewModel request)
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

		try
		{
			string userToken = _authService.Login(request.UserName, request.Password);
			var response = new BaseResponseApi<AuthResponse>
			{
				Payload = new AuthResponse
				{
					Token = userToken
				}
			};

			return Ok(response);
		}
		catch (Exception ex)
		{
			return BadRequest(ex);
		}

    }

	[Authorize]
	[HttpGet]
	[Route("/api/auth/get-me")]
	public IActionResult GetMe()
	{
		var username = User.Identity.Name;
		var role = User.FindFirstValue(ClaimTypes.Role);
		return Ok(new
		{
			Username = username,
			Role = role
		});
	}
}
