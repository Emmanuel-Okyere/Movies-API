using Movies.dto;
using Movies.Model;
using Movies.Repository;

namespace Movies.Services;

public interface IMovieService
{
    Movie GetMovieById(int id);
    MessageResponseDTO CreateMovie(MovieRequestDTO movie);
    Task<IEnumerable<Movie>> GetAllMoviesList();
    Movie? UpdateMovie(int id, MovieRequestDTO requestDto);
    MessageResponseDTO DeleteMovie(int id);
}