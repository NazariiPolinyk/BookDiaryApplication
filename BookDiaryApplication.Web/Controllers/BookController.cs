using AutoMapper;
using BookDiaryApplication.Data.BookDiaryDB.Models;
using BookDiaryApplication.Interfaces;
using BookDiaryApplication.Web.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookDiaryApplication.Web.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BookController : ControllerBase
  {
    private readonly IRepository<Book> _bookRepository;
    private readonly IMapper _mapper;

    public BookController(IRepository<Book> bookRepository, IMapper mapper)
    {
      _bookRepository = bookRepository;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> GetAllBooksAsync()
    {
      var books = await _bookRepository.GetAllAsync();

      if (books == null)
      {
        return NotFound();
      }

      return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetBookByIdAsync(int id)
    {
      if (id < 0)
      {
        return BadRequest();
      }

      var book = await _bookRepository.GetByIdAsync(id);

      if (book == null)
      {
        return NotFound(id);
      }

      return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<Book>> CreateBook(BookDTO bookInputModel)
    {
      if (bookInputModel == null)
      {
        return BadRequest();
      }

      var book = _mapper.Map<Book>(bookInputModel);

      await _bookRepository.InsertAsync(book);

      return Ok(book);
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<Book>> UpdateBook(int id, BookDTO bookInputModel)
    {
      if (!_bookRepository.Exists(id))
      {
        return NotFound();
      }

      var book = _mapper.Map<Book>(bookInputModel);
      book.Id = id;

      await _bookRepository.UpdateAsync(book);

      return Ok(book);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<Book>> DeleteBook(int id)
    {
      var book = await _bookRepository.GetByIdAsync(id);

      if (book == null)
      {
        return NotFound();
      }

      await _bookRepository.DeleteAsync(book);

      return Ok(book);
    }
  }
}
