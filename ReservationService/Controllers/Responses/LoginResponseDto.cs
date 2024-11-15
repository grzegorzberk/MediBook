using System.ComponentModel.DataAnnotations;

namespace ReservationService.Controllers.Responses; 

public class LoginResponseDto
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Role { get; set; } = null!;
}
