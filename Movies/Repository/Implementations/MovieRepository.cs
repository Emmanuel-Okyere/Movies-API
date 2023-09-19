using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Model;

namespace Movies.Repository.Implementions;

public class MoviesRepository : IMoviesRepository
{
    private readonly DataContext _dataContext;

    public MoviesRepository(DataContext context)
    {
        _dataContext = context;
    }

    public Movie? GetMovieById(int id)
    {
        return _dataContext.Movies
            .Include(t=>t.Theatres)
            .Include(t=>t.Genres)
            .FirstOrDefault(a=>a.Id==id);
    }

    public async Task<IEnumerable<Movie>> GetAllMovies()
    {
        var movies = await _dataContext.Movies.Include(t=>t.Genres).ToListAsync();
        return movies;
    }

    public int AddMovie(Movie movie)
    {
        _dataContext.Movies.Add(movie);
        var savedMovie = _dataContext.SaveChanges();
        return savedMovie;
    }

    public Movie? GetMovieByName(string name)
    {
        return _dataContext.Movies.SingleOrDefault(a => a.Title == name);
    }

    public void deleteMovie(Movie movie)
    {
        _dataContext.Movies.Remove(movie);
        _dataContext.SaveChangesAsync();
    }

    public void saveChanges()
    {
        _dataContext.SaveChanges();
    }
}