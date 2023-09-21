using Movies.Model;

namespace Movies.Repository.Interfaces;

public interface ITheatreRepository
{
    Task<Theatre?> GetTheatreById(int id);
    Task<Theatre> AddTheatre(Theatre theatre);
    Task<IEnumerable<Theatre>> GetAllTheatres();
    Task<Theatre?> GetTheatreByNameAndLocation(string name, string location);
    void SaveChanges();
    void DeleteTheatre(Theatre theatre);

}