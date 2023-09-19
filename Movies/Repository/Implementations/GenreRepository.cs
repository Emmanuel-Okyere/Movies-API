using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Model;

namespace Movies.Repository.Implementations;

public class GenreRepository: IGenreRepository
{
    private readonly DataContext _context;

    public GenreRepository(DataContext context)
    {
        _context = context;
    }

    public Genre? AddGenre(Genre genre)
    {
        var savedGenre = _context.Genres.Add(genre);
        _context.SaveChanges();
        return savedGenre.Entity;
    }

    public Genre? UpdateGenre(Genre genre)
    {
        var updatedGenre = _context.Update(genre);
        _context.SaveChangesAsync();
        return updatedGenre.Entity;
    }

    public Genre? GetGenreById(int id)
    {
        return _context.Genres.Find(id);
    }

    public Genre? GetGenreByName(string name)
    {
        var savedGenre = _context.Genres.FirstOrDefault(t => t.Name == name);
        return savedGenre;
    }

    public async Task<IEnumerable<Genre>> GetAllGenre()
    {
        return await _context.Genres.ToListAsync();
    }

    public void DeleteGenre(Genre genre)
    {
        _context.Genres.Remove(genre);
        _context.SaveChangesAsync();
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }
}