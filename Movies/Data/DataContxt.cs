using Microsoft.EntityFrameworkCore;
using Movies.Model;

namespace Movies.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>()
            .Property(s => s.CreatedAt)
            .HasDefaultValueSql("current_timestamp");
    }
}