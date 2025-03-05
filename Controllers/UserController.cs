using Microsoft.AspNetCore.Mvc;
using PetAdoptionAPI.Models;
using PetAdoptionAPI.Services.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if(user == null) return NotFound("User not found.");
        return Ok(user);
    }

    [HttpGet("email/{email}")]
    public async Task<ActionResult<User>> GetUserByEmail(string email)
    {
        var user = await _userService.GetUserByEmailAsync(email);
        if (user == null) return NotFound("User not found.");
        return Ok(user);
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> RegisterUser([FromBody] User user)
    {
        if (user == null) return BadRequest("Invalid User data.");

        var creeatedUser = await _userService.RegisterUserAsync(user);
        return CreatedAtAction(nameof(GetUserById), new { id = creeatedUser.ID}, creeatedUser);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
    {
        if(id != user.ID) return BadRequest("User ID mismatch.");

        var updated = await _userService.UpdateUserAsync(user);
        if (!updated) return NotFound("User not found.");

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var deleted = await _userService.DeleteUserAsync(id);
        if(!deleted) return NotFound("User not found.");

        return NoContent();
    }

}