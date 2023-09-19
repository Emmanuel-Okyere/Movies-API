using Movies.Model;

namespace Movies.Repository;

public interface ITheatreRepository
{
    Theatre GetTheatreById(int id);
    Theatre AddTheatre(Theatre theatre);
    Task<IEnumerable<Theatre>> GetAllTheatres();
    // List<Movie> GetAllMoviesInATheatre(Theatre theatre);
    void DeleteTheatre(Theatre theatre);
    Theatre UpdateTheatre(Theatre theatre);
    int AddMovieToTheatre(Theatre theatreId,Movie movie);
    Theatre? GetTheatreByNameAndLocation(string name, string location);
    void SaveChanges();

}