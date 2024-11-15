using System.ComponentModel.DataAnnotations;
namespace ReservationService.Controllers.Request;

public class RegisterUserDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    [MinLength(6)]
    public string Password { get; set; } = null!;
}