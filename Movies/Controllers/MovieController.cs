
using Microsoft.AspNetCore.Mvc;
using Movies.dto;
using Movies.Model;
using Movies.Services;

namespace Movies.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class MovieController: ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Movie))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetMovieById(int id)
    {
        return Ok(_movieService.GetMovieById(id));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<MessageResponseDTO> CreateMovie(MovieRequest movie)
    {
        return Ok(_movieService.CreateMovie(movie));
    }

    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<IEnumerable<Movie>> GetAllMoviesList()
    {
        return _movieService.GetAllMoviesList();
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult UpdateMovie(int id, MovieRequest request)
    {
        return Ok(_movieService.UpdateMovie(id, request));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteMovie(int id)
    {
        return Ok(_movieService.DeleteMovie(id));
    }
}
