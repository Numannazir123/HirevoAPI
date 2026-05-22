using HirevoAPI.Contracts.IServices;
using HirevoAPI.DataTransferObject;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // GET ALL USERS
    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();

        return Ok(users);
    }

    // GET USER BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound(new
            {
                message = "User not found"
            });
        }

        return Ok(user);
    }

    // UPDATE USER
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(
        int id,
        RegisterDto dto)
    {
        var result =
            await _userService
            .UpdateUserAsync(id, dto);

        return Ok(result);
    }

    // DELETE USER
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var result =
            await _userService
            .DeleteUserAsync(id);

        return Ok(new
        {
            message = result
        });
    }
}