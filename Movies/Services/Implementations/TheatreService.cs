using Movies.dto;
using Movies.Exceptions;
using Movies.Model;
using Movies.Repository;

namespace Movies.Services.Implementations;

public class TheatreService: ITheatreService
{
    private readonly ITheatreRepository _theatreRepository;
    private readonly IMoviesRepository _moviesRepository;

    public TheatreService(ITheatreRepository theatreRepository, IMoviesRepository moviesRepository)
    {
        _theatreRepository = theatreRepository;
        _moviesRepository = moviesRepository;
    }

    public MessageResponseDTO CreateTheatre(TheatreRequestDTO theatre)
    {
        var savedTheatre = _theatreRepository
            .GetTheatreByNameAndLocation(theatre.Name.ToLower(), theatre.Location.ToLower());
        if (savedTheatre != null)
        {
            throw new Duplicate409Exception("theatre already created");
        }

        var newTheatre = new Theatre()
        {
            Name = theatre.Name.ToLower(),
            Capacity = theatre.Capacity,
            Location = theatre.Location.ToLower()
        };
        _theatreRepository.AddTheatre(newTheatre);
        return new MessageResponseDTO()
        {
            message = "theatre save success",
            status = "success"
        };
    }

    public Theatre GetTheatreById(int id)
    {
        var theatre = _theatreRepository.GetTheatreById(id);
        if (theatre == null)
        {
            throw new NotFound404Exception("theatre not found");
        }

        return theatre;
    }

    public Theatre UpdateTheatre(int id, TheatreRequestDTO theatreRequestDto)
    {
        var savedTheatre = _theatreRepository.GetTheatreById(id);
        if (savedTheatre == null)
        {
            throw new NotFound404Exception("theatre not found");
        }

        savedTheatre.Capacity = theatreRequestDto.Capacity;
        savedTheatre.Location = theatreRequestDto.Location;
        savedTheatre.Name = theatreRequestDto.Name;
        var theatre = _theatreRepository.UpdateTheatre(savedTheatre);
        return theatre;
    }

    public MessageResponseDTO DeletedTheatreById(int id)
    {
        var theatre = _theatreRepository.GetTheatreById(id);
        if (theatre == null)
        {
            throw new NotFound404Exception("theatre not found");
        }
        _theatreRepository.DeleteTheatre(theatre);
        return new MessageResponseDTO()
        {
            message = "theatre delete success",
            status = "success"
        };
    }

    public IEnumerable<Theatre> GetAllTheatres()
    {
        return _theatreRepository.GetAllTheatres().Result;
    }

    public MessageResponseDTO AddMovieToTheatre(int theatreId, AddMovieToTheatreRequestDto movieId)
    {
        var theatre = _theatreRepository.GetTheatreById(theatreId);
        if (theatre == null)
        {
            throw new NotFound404Exception("theatre not found");
        }

        var movie = _moviesRepository.GetMovieById(movieId.MovieId);
        if (movie == null)
        {
            throw new NotFound404Exception("movie not found");
        }

        if (theatre.Movies.Contains(movie))
        {
            throw new Duplicate409Exception("movie already added");
        }
        theatre.Movies.Add(movie);
        movie.Theatres.Add(theatre);
        _theatreRepository.SaveChanges();
        _moviesRepository.saveChanges();
        return new MessageResponseDTO
        {
            message = "movie add to theatre success",
            status = "success"
        };
    }

    public MessageResponseDTO AddBulkMovieToTheatre(int theatreId, List<int> movieIds)
    {
        var theatre = _theatreRepository.GetTheatreById(theatreId);
        if (theatre == null)
        {
            throw new NotFound404Exception("theatre not found");
        }
        foreach (var movieId in movieIds)
        {
            var movie = _moviesRepository.GetMovieById(movieId);
            if (movie != null && !theatre.Movies.Contains(movie))
            {
                theatre.Movies.Add(movie);
                movie.Theatres.Add(theatre);
                _moviesRepository.saveChanges();
                _theatreRepository.SaveChanges();
            }
        }
        return new MessageResponseDTO()
        {
            message = "bulk movies added",
            status = "success"
        };
    }

    public IEnumerable<Movie> GetAllMoviesInATheatre(int id)
    {
        var theatre = _theatreRepository.GetTheatreById(id);
        if (theatre == null)
        {
            throw new NotFound404Exception("theatre not found");
        }

        return theatre.Movies;
    }

    public MessageResponseDTO DeleteMovieFromTheatre(int theatreId, int movieId)
    {
        var theatre = _theatreRepository.GetTheatreById(theatreId);
        if (theatre == null)
        {
            throw new NotFound404Exception("theatre not found");
        }

        var movie = _moviesRepository.GetMovieById(movieId);
        if (movie == null)
        {
            throw new NotFound404Exception("movie not found");
        }

        if (!theatre.Movies.Contains(movie))
        {
            throw new NotFound404Exception("movie can not be found in theatre");
        }

        theatre.Movies.Remove(movie);
        movie.Theatres.Remove(theatre);
        _moviesRepository.saveChanges();
        _theatreRepository.SaveChanges();
        return new MessageResponseDTO()
        {
            message = "movie remove success",
            status = "success"
        };
    }
}