using Microsoft.AspNetCore.Mvc;
using Movies.dto;
using Movies.Model;
using Movies.Services;
using Movies.Services.Interfaces;

namespace Movies.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class TheatreController: ControllerBase
{
    private readonly ITheatreService _theatreService;

    public TheatreController(ITheatreService theatreService)
    {
        _theatreService = theatreService;
    }
    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<MessageResponseDTO> CreateTheatre(TheatreRequestDTO theatre)
    {
        return Ok(_theatreService.CreateTheatre(theatre));
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Theatre> GetTheatreById(int id)
    {
        return Ok(_theatreService.GetTheatreById(id));
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateTheatre(int id, TheatreRequestDTO theatreRequestDto)
    {
        return Ok(_theatreService.UpdateTheatre(id, theatreRequestDto));
    }

    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAllTheatres()
    {
        return Ok(_theatreService.GetAllTheatres());
    }
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeletedTheatreById(int id)
    {
        return Ok(_theatreService.DeletedTheatreById(id));
    }

    [HttpPost("{id:int}/add-movie")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public ActionResult AddMovieToTheatre(int id, [FromBody] AddMovieToTheatreRequestDto movieId)
    {
        return Ok(_theatreService.AddMovieToTheatre(id, movieId));
    }

    [HttpPost("{id:int}/add-bulk-movie")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult AddBulkMoviesToTheatre(int id, List<int> movieIds)
    {
        return Ok(_theatreService.AddBulkMovieToTheatre(id, movieIds));
    }

    [HttpGet("{id:int}/movies")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetAllMoviesInATheatre(int id)
    {
        return Ok(_theatreService.GetAllMoviesInATheatre(id));
    }

    [HttpDelete("{id:int}/movie/{movieId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteMovieFromTheatre(int id, int movieId)
    {
        return Ok(_theatreService.DeleteMovieFromTheatre(id, movieId));
    }
}