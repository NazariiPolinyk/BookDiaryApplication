using AutoMapper;
using BookDiaryApplication.Data.BookDiaryDB.Models;
using BookDiaryApplication.Interfaces;
using BookDiaryApplication.Web.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookDiaryApplication.Web.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthorController : ControllerBase
  {
    private readonly IRepository<Author> _authorRepository;
    private readonly IMapper _mapper;

    public AuthorController(IRepository<Author> authorRepository, IMapper mapper)
    {
      _authorRepository = authorRepository;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthorsAsync()
    {
      var authors = await _authorRepository.GetAllAsync();

      if (authors == null)
      {
        return NotFound();
      }

      return Ok(authors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Author>> GetAuthorByIdAsync(int id)
    {
      if(id < 0)
      {
        return BadRequest();
      }

      var author = await _authorRepository.GetByIdAsync(id);

      if(author == null)
      {
        return NotFound(id);
      }

      return Ok(author);
    }

    [HttpPost]
    public async Task<ActionResult<Author>> CreateAuthor(AuthorDTO authorInputModel)
    {
      if (authorInputModel == null)
      {
        return BadRequest();
      }

      var author = _mapper.Map<Author>(authorInputModel);

      await _authorRepository.InsertAsync(author);

      return Ok(author);
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<Author>> UpdateAuthor(int id, AuthorDTO authorInputModel)
    {
      if (!_authorRepository.Exists(id))
      {
        return NotFound();
      }

      var author = _mapper.Map<Author>(authorInputModel);
      author.Id = id;

      await _authorRepository.UpdateAsync(author);

      return Ok(author);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<Author>> DeleteAuthor(int id)
    {
      var author = await _authorRepository.GetByIdAsync(id);

      if (author == null) 
      {
        return NotFound();
      }

      await _authorRepository.DeleteAsync(author);

      return Ok(author);
    }
  }
}
