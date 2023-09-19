using Microsoft.EntityFrameworkCore;
using Movies.Data;
using Movies.Model;

namespace Movies.Repository;

public interface IMoviesRepository
{
    Movie? GetMovieById(int id);
    Task<IEnumerable<Movie>> GetAllMovies();
    int AddMovie(Movie movie);
    Movie? GetMovieByName(string name);
    void deleteMovie(Movie movie);
    void saveChanges();
}

