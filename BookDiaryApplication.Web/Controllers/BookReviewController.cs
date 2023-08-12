using AutoMapper;
using BookDiaryApplication.Data.BookDiaryDB.Models;
using BookDiaryApplication.Interfaces;
using BookDiaryApplication.Web.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace BookDiaryApplication.Web.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BookReviewController : ControllerBase
  {
    private readonly IRepository<BookReview> _bookReviewRepository;
    private readonly IMapper _mapper;

    public BookReviewController(IRepository<BookReview> bookReviewRepository, IMapper mapper)
    {
      _bookReviewRepository = bookReviewRepository;
      _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookReview>>> GetAllBookReviewsAsync()
    {
      var bookReviews = await _bookReviewRepository.GetAllAsync();

      if (bookReviews == null)
      {
        return NotFound();
      }

      return Ok(bookReviews);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookReview>> GetBookReviewByIdAsync(int id)
    {
      if (id < 0)
      {
        return BadRequest();
      }

      var bookReview = await _bookReviewRepository.GetByIdAsync(id);

      if (bookReview == null)
      {
        return NotFound(id);
      }

      return Ok(bookReview);
    }

    [HttpPost]
    public async Task<ActionResult<BookReview>> CreateBookReview(BookReviewDTO bookReviewInputModel)
    {
      if (bookReviewInputModel == null)
      {
        return BadRequest();
      }

      var bookReview = _mapper.Map<BookReview>(bookReviewInputModel);

      await _bookReviewRepository.InsertAsync(bookReview);

      return Ok(bookReview);
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<BookReview>> UpdateBookReview(int id, BookReviewDTO bookReviewInputModel)
    {
      if (!_bookReviewRepository.Exists(id))
      {
        return NotFound();
      }

      var bookReview = _mapper.Map<BookReview>(bookReviewInputModel);
      bookReview.Id = id;

      await _bookReviewRepository.UpdateAsync(bookReview);

      return Ok(bookReview);
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult<BookReview>> DeleteBookReview(int id)
    {
      var bookReview = await _bookReviewRepository.GetByIdAsync(id);

      if (bookReview == null)
      {
        return NotFound();
      }

      await _bookReviewRepository.DeleteAsync(bookReview);

      return Ok(bookReview);
    }
  }
}
