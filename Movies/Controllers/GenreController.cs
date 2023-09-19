using Microsoft.AspNetCore.Mvc;
using Movies.dto;
using Movies.Model;
using Movies.Services;

namespace Movies.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class GenreController: ControllerBase
{
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<IEnumerable<Genre>> GetAllGenres()
    {
        return _genreService.GetAllGenre();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public ActionResult AddGenre([FromBody] GenreRequestDTO genreRequestDto)
    {
        return Ok(_genreService.AddGenre(genreRequestDto));
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public ActionResult UpdateGenre(int id, [FromBody] GenreRequestDTO genreRequestDto)
    {
        return Ok(_genreService.UpdateGenre(id, genreRequestDto));
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult DeleteGenre(int id)
    {
        return Ok(_genreService.DeleteGenre(id));
    }

    [HttpPost("bulk")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult AddBulkGenre(GenreBulkRequest genreBulkRequest)
    {
        return Ok(_genreService.AddBulkGenre(genreBulkRequest));
    }
}