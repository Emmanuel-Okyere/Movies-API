using Movies.dto;
using Movies.Model;

namespace Movies.Services;

public interface ITheatreService
{
    MessageResponseDTO CreateTheatre(Theatre theatre);
    Theatre GetTheatreById(int id);
    Theatre UpdateTheatre(int id, TheatreRequestDTO theatreRequestDto);
    MessageResponseDTO DeletedTheatreById(int id);
    IEnumerable<Theatre> GetAllTheatres();
    MessageResponseDTO AddMovieToTheatre(int theatreId, int movieId);
    MessageResponseDTO AddBulkMovieToTheatre(int theatreId, List<int> movieIds);
    IEnumerable<Movie> GetAllMoviesInATheatre(int id);
    MessageResponseDTO DeleteMovieFromTheatre(int theatreId, int movieId);
}