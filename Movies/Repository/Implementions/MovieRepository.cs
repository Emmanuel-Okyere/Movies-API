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
        return _dataContext.Movies.Find(id);
    }

    public async Task<IEnumerable<Movie>> GetAllMovies()
    {
        var movies = await _dataContext.Movies.ToListAsync();
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

    public Movie? update(Movie movie)
    {
        var updatedMovie =_dataContext.Movies.Update(movie);
        _dataContext.SaveChangesAsync();
        return updatedMovie.Entity;
    }

    public void deleteMovie(Movie movie)
    {
        _dataContext.Movies.Remove(movie);
        _dataContext.SaveChangesAsync();
    }
}