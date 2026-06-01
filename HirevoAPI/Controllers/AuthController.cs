using HirevoAPI.Contracts.IServices;
using HirevoAPI.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;

    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    // REGISTER
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        var result = await _userService.RegisterAsync(dto);

        return Ok(result);
    }

    // LOGIN
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var result = await _userService.LoginAsync(dto);

        if (result == null)
            return Unauthorized(new { message = "Invalid username or password." });

        return Ok(result);
    }
}