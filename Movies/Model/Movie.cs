using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Movies.Enums;

namespace Movies.Model;

public class Movie
{
    [Required]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string? Title { get; set; }
    [Required]
    public List<MovieCategories>? Genre { get; set; }
    [Required]
    public string? Description { get; set; }
    [Required]
    public DateTime ReleasedDate { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}