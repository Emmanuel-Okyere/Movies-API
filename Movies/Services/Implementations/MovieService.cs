using Movies.dto;
using Movies.Exceptions;
using Movies.Model;
using Movies.Repository;

namespace Movies.Services.Implementations;

public class MovieService:IMovieService
{
    private readonly IMoviesRepository _moviesRepository;

    public MovieService(IMoviesRepository moviesRepository)
    {
        _moviesRepository = moviesRepository;
    }

    public Movie GetMovieById(int id)
    {
        var movie= _moviesRepository.GetMovieById(id);
        if (movie == null)
        {
            throw new NotFound404Exception("movie no found");
        }
        
        return movie;
    }

    public MessageResponseDTO CreateMovie(MovieRequest movie)
    {
        var savedMovie = _moviesRepository.GetMovieByName(movie.Title.ToLower());
        if (savedMovie is not null)
        {
            throw new Duplicate409Exception("movie already created");
        }
        var newMovie = new Movie
        {
            Description = movie.Description,
            Title = movie.Title.ToLower(),
            ReleasedDate = movie.ReleasedDate,
            Genre = movie.Genre
        };
        var result = _moviesRepository.AddMovie(newMovie);
        Console.WriteLine(result);
        return new MessageResponseDTO()
        {
            message = "movie saved",
            status = "succeess"
        };
    }

    public Task<IEnumerable<Movie>> GetAllMoviesList()
    {
        return _moviesRepository.GetAllMovies();
    }

    public Movie? UpdateMovie(int id, MovieRequest request)
    {
        var savedMovie = _moviesRepository.GetMovieById(id);
        if (savedMovie == null)
        {
            throw new NotFound404Exception("movie not found");
        }
        savedMovie.Description = request.Description;
        savedMovie.Title = request.Title;
        savedMovie.ReleasedDate = request.ReleasedDate;
        savedMovie.Genre = request.Genre;
        savedMovie.UpdatedAt = DateTime.Now;
        return _moviesRepository.update(savedMovie);
    }

    public MessageResponseDTO DeleteMovie(int id)
    {
        var movie =_moviesRepository.GetMovieById(id);
        if (movie == null)
        {
            throw new NotFound404Exception("movie not found");
        }
        _moviesRepository.deleteMovie(movie);
        return new MessageResponseDTO()
        {
            message = "movie deleted successfully",
            status = "success"
        };
    }
}
