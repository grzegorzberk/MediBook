namespace ReservationService.Controllers;
using Microsoft.AspNetCore.Mvc;
using ReservationService.Data.Entities;
using ReservationService.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using ReservationService.Controllers.Request;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using ReservationService.Controllers.Responses;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;

    public UsersController(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    [HttpGet("profile")]
    public async Task<IActionResult> GetUserProfile()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userRepository.GetUserById(Guid.Parse(userId));
        if (user == null)
        {
            return NotFound();
        }

        var userResponse = new LoginResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Role = user.Role
        };

        return Ok(userResponse);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userLogin)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userRepository.GetUserByEmail(userLogin.Email);
        if (user == null)
        {
            return Unauthorized(new { message = "Invalid email or password." });
        }

        var passwordHasher = new PasswordHasher<User>();
        var result = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, userLogin.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            return Unauthorized(new { message = "Invalid email or password." });
        }

        // Utworzenie listy roszczeń (claims)
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            IsPersistent = true, // Zachowaj sesję po zamknięciu przeglądarki
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

        // Zwróć podstawowe informacje o użytkowniku
        var loginResponseDto = new LoginResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Role = user.Role
        };

        return Ok(loginResponseDto);
    }

    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok(new { message = "Logged out successfully." });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(Guid id)
    {
        var user = await _userRepository.GetUserById(id);
        if (user == null)
            return NotFound();
        return user;
    }

    [HttpPost("register/user")]
    public async Task<ActionResult> RegisterUser([FromBody] RegisterUserDto userDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingUser = await _userRepository.GetUserByEmail(userDto.Email);
        if (existingUser != null)
            return BadRequest(new { message = "User already exists." });

        var user = new User
        {
            Name = userDto.Name,
            Email = userDto.Email,
            Role = "User",
        };

        var passwordHasher = new PasswordHasher<User>();
        user.PasswordHash = passwordHasher.HashPassword(user, userDto.Password);

        await _userRepository.AddUser(user);

        return Ok(new { message = "User registered successfully!" });
    }

    [HttpPost("register/service-provider")]
    public async Task<ActionResult> RegisterServiceProvider(User user)
    {
        var existingUser = await _userRepository.GetUserByEmail(user.Email);
        if (existingUser != null)
            return BadRequest(new {error = "Service Provider already exists." });

        var passwordHasher = new PasswordHasher<User>();
        user.PasswordHash = passwordHasher.HashPassword(user, user.PasswordHash);

        user.Role = "ServiceProvider";

        await _userRepository.AddUser(user);

        return Ok(new {message = "Service Provider registered succesfully!" });
    }
}