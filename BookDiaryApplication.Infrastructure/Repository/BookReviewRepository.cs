using BookDiaryApplication.Interfaces;
using BookDiaryApplication.Data.BookDiaryDB.Models;
using BookDiaryApplication.Data.BookDiaryApplicationDB;
using Microsoft.EntityFrameworkCore;

namespace BookDiaryApplication.Infrastructure.Repository
{
  public class BookReviewRepository : IRepository<BookReview>
  {
    private readonly BookDiaryContext _context;

    public BookReviewRepository(BookDiaryContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<BookReview>> GetAllAsync()
    {
      return await _context.BookReviews.AsNoTracking().ToListAsync();
    }

    public async Task<BookReview> GetByIdAsync(int id)
    {
      return await _context.BookReviews.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task InsertAsync(BookReview entity)
    {
      _context.BookReviews.Add(entity);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(BookReview entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(BookReview entity)
    {
      _context?.BookReviews.Remove(entity);
      await _context.SaveChangesAsync();
    }

    public bool Exists(int id)
    {
      return _context.BookReviews.Any(x => x.Id == id);
    }
  }
}
