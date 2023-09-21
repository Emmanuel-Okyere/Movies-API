using Movies.dto;
using Movies.Exceptions;
using Movies.Model;
using Movies.Repository;
using Movies.Repository.Interfaces;

namespace Movies.Services.Implementations;

public class GenreService: IGenreService
{
    private readonly IGenreRepository _repository;

    public GenreService(IGenreRepository repository)
    {
        _repository = repository;
    }

    public async Task<MessageResponseDTO> AddGenre(GenreRequestDTO requestDto)
    {
        if (await _repository.GetGenreByName(requestDto.Name.ToLower()) != null)
        {
            throw new Duplicate409Exception("genre already added");
        }

        var genre = new Genre
        {
            Name = requestDto.Name.ToLower()
        };
        await _repository.AddGenre(genre);
        return new MessageResponseDTO
        {
            message = "genre added successfully",
            status = "success"
        };
    }

    public async Task<MessageResponseDTO> UpdateGenre(int id, GenreRequestDTO requestDto)
    {
        var genre = await _repository.GetGenreById(id);
        if (genre == null)
        {
            throw new NotFound404Exception("genre not found");
        }

        if (!genre.Name.Equals(requestDto.Name.ToLower()))
        {
            var alreadySavedGenre = await _repository.GetGenreByName(requestDto.Name.ToLower());
            if (alreadySavedGenre != null)
            {
                throw new Duplicate409Exception("genre already saved with that name");
            }

            genre.Name = requestDto.Name;
            _repository.SaveChanges();
        }

        return new MessageResponseDTO
        {
            message = "genre update success",
            status = "success"
        };
    }

    public async Task<IEnumerable<Genre>> GetAllGenre()
    {
        return await _repository.GetAllGenre();
    }

    public async Task<MessageResponseDTO> DeleteGenre(int id)
    {
        var genre = await _repository.GetGenreById(id);
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

    public async Task<MessageResponseDTO> AddBulkGenre(GenreBulkRequest genreBulkRequest)
    {
        foreach (var genre in genreBulkRequest.Genres)
        {
            var savedGenre = await _repository.GetGenreByName(genre.ToLower());
            if (savedGenre != null) continue;
            var newGenre = new Genre
            {
                Name = genre.ToLower()
            };
            await _repository.AddGenre(newGenre);
        }
        return new MessageResponseDTO
        {
            message = "bulk genre add success",
            status = "success"
        };
    }
}