using Movies.dto;
using Movies.Model;

namespace Movies.Services;

public interface IGenreService
{
    MessageResponseDTO AddGenre(GenreRequestDTO requestDto);
    MessageResponseDTO UpdateGenre(int id, GenreRequestDTO requestDto);
    Task<IEnumerable<Genre>> GetAllGenre();
    MessageResponseDTO DeleteGenre(int id);
    MessageResponseDTO AddBulkGenre(GenreBulkRequest genreBulkRequest);
}