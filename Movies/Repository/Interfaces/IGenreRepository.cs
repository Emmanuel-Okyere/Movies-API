using Movies.Model;

namespace Movies.Repository.Interfaces;

public interface IGenreRepository
{
    Task<Genre?> AddGenre(Genre genre);
    Task<Genre?> GetGenreById(int id);
    Task<Genre?> GetGenreByName(string name);
    Task<IEnumerable<Genre>> GetAllGenre();
    void DeleteGenre(Genre genre);
    void SaveChanges();
}