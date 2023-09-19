using Movies.Model;

namespace Movies.Repository;

public interface IGenreRepository
{
    Genre? AddGenre(Genre genre);
    Genre? UpdateGenre(Genre genre);
    Genre? GetGenreById(int id);
    Genre? GetGenreByName(string nanem);
    Task<IEnumerable<Genre>> GetAllGenre();
    void DeleteGenre(Genre genre);
    void SaveChanges();
}