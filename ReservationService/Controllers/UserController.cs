namespace ReservationService.Controllers;
using Microsoft.AspNetCore.Mvc;
using ReservationService.Data.Entities;
using ReservationService.Data.Repositories;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UsersController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(Guid id)
    {
        var user = await _userRepository.GetUserById(id);
        if (user == null)
            return NotFound();
        return user;
    }

    [HttpPost]
    public async Task<ActionResult> AddUser(User user)
    {
        await _userRepository.AddUser(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }
}