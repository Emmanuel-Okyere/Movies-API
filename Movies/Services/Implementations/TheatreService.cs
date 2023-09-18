using Movies.dto;
using Movies.Model;

namespace Movies.Services.Implementations;

public class TheatreService: ITheatreService
{
    public MessageResponseDTO CreateTheatre(TheatreRequestDTO theatre)
    {
        throw new NotImplementedException();
    }

    public Theatre GetTheatreById(int id)
    {
        throw new NotImplementedException();
    }

    public Theatre UpdateTheatre(int id, TheatreRequestDTO theatreRequestDto)
    {
        throw new NotImplementedException();
    }

    public MessageResponseDTO DeletedTheatreById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Theatre> GetAllTheatres()
    {
        throw new NotImplementedException();
    }

    public MessageResponseDTO AddMovieToTheatre(int theatreId, AddMovieToTheatreRequestDto movieId)
    {
        throw new NotImplementedException();
    }

    public MessageResponseDTO AddBulkMovieToTheatre(int theatreId, List<int> movieIds)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Movie> GetAllMoviesInATheatre(int id)
    {
        throw new NotImplementedException();
    }

    public MessageResponseDTO DeleteMovieFromTheatre(int theatreId, int movieId)
    {
        throw new NotImplementedException();
    }
}