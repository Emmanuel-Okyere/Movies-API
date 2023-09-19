using Microsoft.EntityFrameworkCore;
using Movies.Model;

namespace Movies.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Theatre> Theatres { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .Property(s => s.CreatedAt)
            .HasDefaultValueSql("current_timestamp");
        modelBuilder.Entity<Theatre>()
            .Property(s => s.CreatedAt)
            .HasDefaultValueSql("current_timestamp");
    }
}