using System.ComponentModel.DataAnnotations;

namespace Movies.dto;

public class MovieEventBookingDto
{
    [Required]
    public string? EmailAddress { get; set; }
    [Required]
    public int NumberOfPersons { get; set; }
    [Required]
    public int MovieEventId { get; set; }
}