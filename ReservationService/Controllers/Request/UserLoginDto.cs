using System.ComponentModel.DataAnnotations;

namespace ReservationService.Controllers.Request;

public class UserLoginDto
{
    [Required]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
}