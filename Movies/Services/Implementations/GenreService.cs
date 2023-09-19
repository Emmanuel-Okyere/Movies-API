using Movies.dto;
using Movies.Exceptions;
using Movies.Model;
using Movies.Repository;

namespace Movies.Services.Implementations;

public class GenreService: IGenreService
{
    private readonly IGenreRepository _repository;

    public GenreService(IGenreRepository repository)
    {
        _repository = repository;
    }

    public MessageResponseDTO AddGenre(GenreRequestDTO requestDto)
    {
        if (_repository.GetGenreByName(requestDto.Name.ToLower()) != null)
        {
            throw new Duplicate409Exception("genre already added");
        }

        var genre = new Genre
        {
            Name = requestDto.Name.ToLower()
        };
        _repository.AddGenre(genre);
        return new MessageResponseDTO
        {
            message = "genre added successfully",
            status = "success"
        };
    }

    public MessageResponseDTO UpdateGenre(int id, GenreRequestDTO requestDto)
    {
        var genre = _repository.GetGenreById(id);
        if (genre == null)
        {
            throw new NotFound404Exception("genre not found");
        }

        if (!genre.Name.Equals(requestDto.Name.ToLower()))
        {
            var alreadySavedGenre = _repository.GetGenreByName(requestDto.Name.ToLower());
            if (alreadySavedGenre != null)
            {
                throw new Duplicate409Exception("genre already saved with that name");
            }

            _repository.UpdateGenre(genre);
        }

        return new MessageResponseDTO
        {
            message = "genre update success",
            status = "success"
        };
    }

    public Task<IEnumerable<Genre>> GetAllGenre()
    {
        return _repository.GetAllGenre();
    }

    public MessageResponseDTO DeleteGenre(int id)
    {
        var genre = _repository.GetGenreById(id);
        if (genre == null)
        {
            throw new NotFound404Exception("genre not found");
        }
        _repository.DeleteGenre(genre);
        return new MessageResponseDTO
        {
            message = "genre delete success",
            status = "success"
        };
    }

    public MessageResponseDTO AddBulkGenre(GenreBulkRequest genreBulkRequest)
    {
        foreach (var genre in genreBulkRequest.Genres)
        {
            var savedGenre = _repository.GetGenreByName(genre.ToLower());
            if (savedGenre != null) continue;
            var newGenre = new Genre
            {
                Name = genre.ToLower()
            };
            _repository.AddGenre(newGenre);

        }

        return new MessageResponseDTO
        {
            message = "bulk genre add success",
            status = "success"
        };
    }
}