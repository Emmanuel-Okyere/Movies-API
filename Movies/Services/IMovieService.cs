using Movies.dto;
using Movies.Model;
using Movies.Repository;

namespace Movies.Services;

public interface IMovieService
{
    Movie GetMovieById(int id);
    MessageResponseDTO CreateMovie(MovieRequest movie);
    Task<IEnumerable<Movie>> GetAllMoviesList();
    Movie? UpdateMovie(int id, MovieRequest request);
    MessageResponseDTO DeleteMovie(int id);
}