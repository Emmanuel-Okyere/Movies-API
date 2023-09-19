using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Model;
[Table(name:"movie")]
public class Movie
{
    [Required]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string? Title { get; set; }
    [Required]
    public List<Genre>? Genres { get; set; }= new();
    [Required]
    public string? Description { get; set; }
    [Required]
    public DateTime ReleasedDate { get; set; }

    public List<Theatre> Theatres { get; set; } = new();
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}