using AutoMapper;
using BookDiaryApplication.Data.BookDiaryDB.Models;
using BookDiaryApplication.Interfaces;
using BookDiaryApplication.Web.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookDiaryApplication.Web.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GenreController : ControllerBase
  {
    private readonly IRepository<Genre> _genreRepository;
    private readonly IMapper _mapper;

    public GenreController(IRepository<Genre> genreRepository, IMapper mapper)
    {
      _genreRepository = genreRepository;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Genre>>> GetAllGenresAsync()
    {
      var genres = await _genreRepository.GetAllAsync();

      if (genres == null)
      {
        return NotFound();
      }

      return Ok(genres);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Genre>> GetGenreByIdAsync(int id)
    {
      if (id < 0)
      {
        return BadRequest();
      }

      var genre = await _genreRepository.GetByIdAsync(id);

      if (genre == null)
      {
        return NotFound(id);
      }

      return Ok(genre);
    }

    [HttpPost]
    public async Task<ActionResult<Genre>> CreateGenre(GenreDTO genreInputModel)
    {
      if (genreInputModel == null)
      {
        return BadRequest();
      }

      var genre = _mapper.Map<Genre>(genreInputModel);

      await _genreRepository.InsertAsync(genre);

      return Ok(genre);
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<Genre>> UpdateGenre(int id, GenreDTO genreInputModel)
    {
      if (!_genreRepository.Exists(id))
      {
        return NotFound();
      }

      var genre = _mapper.Map<Genre>(genreInputModel);
      genre.Id = id;

      await _genreRepository.UpdateAsync(genre);

      return Ok(genre);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<Genre>> DeleteGenre(int id)
    {
      var genre = await _genreRepository.GetByIdAsync(id);

      if (genre == null)
      {
        return NotFound();
      }

      await _genreRepository.DeleteAsync(genre);

      return Ok(genre);
    }
  }
}
