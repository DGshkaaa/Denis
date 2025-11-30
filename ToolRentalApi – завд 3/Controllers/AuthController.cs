using Microsoft.AspNetCore.Mvc;
using ToolRentalApi.Models;
using ToolRentalApi.Models.Dto;
using ToolRentalApi.Services;
using ToolRentalApi.Services.Interfaces;

namespace ToolRentalApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly TokenService _tokenService;

    public AuthController(IUserService userService, TokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
    {
        var user = await _userService.GetByEmailAsync(request.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return Unauthorized("Невірний email або пароль");

        var token = _tokenService.GenerateToken(user);
        return Ok(new LoginResponse(token, user));
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(RegisterRequest request)
    {
        if (await _userService.GetByEmailAsync(request.Email) != null)
            return Conflict("Користувач з таким email вже існує");

        var user = new User
        {
            Name = request.Name,
            Email = request.Email.ToLowerInvariant(),
            Phone = request.Phone
        };

        var created = await _userService.CreateWithPasswordAsync(user, request.Password);
        return Created($"api/users/{created.Id}", created);
    }
}