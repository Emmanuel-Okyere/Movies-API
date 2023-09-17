using System.ComponentModel.DataAnnotations;
using Movies.Enums;

namespace Movies.dto;

public class MovieRequest
{
    [Required]
    public string? Title { get; set; }
    [Required]
    public List<MovieCategories>? Genre { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public DateTime ReleasedDate { get; set; }
}