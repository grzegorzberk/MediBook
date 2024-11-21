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
    [Authorize]
    [HttpGet("profile")]
    public async Task<IActionResult> GetUserProfile()
    {
        Console.WriteLine("Fetching User profile");
        try
        {
            // Pobranie ID użytkownika z kontekstu
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized(new { message = "User is not authenticated" });
            }

            // Pobranie użytkownika z repozytorium
            var user = await _userRepository.GetUserById(int.Parse(userId));
            if (user == null)
            {
                return NotFound(new { message = "User not found" });
            }

            // Zwrócenie danych użytkownika
            var userResponse = new LoginResponseDto
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role
            };

            return Ok(userResponse);
        }
        catch (Exception ex)
        {
            // Logowanie błędu dla celów debugowania
            Console.WriteLine($"Error in GetUserProfile: {ex.Message}");
            return StatusCode(500, new { message = "Internal Server Error", error = ex.Message });
        }
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userLogin)
    {
        Console.WriteLine("Logging in");
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
            IsPersistent = true,
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

        var loginResponseDto = new LoginResponseDto
        {
            Id = user.Id,
            Name = user.Name,
            Role = user.Role
        };

        return Ok(loginResponseDto);
    }
    [AllowAnonymous]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok(new { message = "Logged out successfully." });
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await _userRepository.GetUserById(id);
        if (user == null)
            return NotFound();
        return user;
    }
    [AllowAnonymous]
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