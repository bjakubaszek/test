using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public class CreatePolitykRequest
{
    
    [Required]
    [MaxLength(50)]
    public string Imie { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Nazwisko { get; set; } = string.Empty;
    [MaxLength(200)]
    public string? Powiedzenie { get; set; }
    public IEnumerable<int>? Przynaleznosc { get; set; }
}