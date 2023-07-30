using BookDiaryApplication.Interfaces;
using BookDiaryApplication.Data.BookDiaryDB.Models;
using BookDiaryApplication.Data.BookDiaryApplicationDB;
using Microsoft.EntityFrameworkCore;

namespace BookDiaryApplication.Infrastructure.Repository
{
  public class BookRepository : IRepository<Book>
  {
    private readonly BookDiaryContext _context;

    public BookRepository(BookDiaryContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
      return await _context.Books.AsNoTracking().ToListAsync();
    }

    public async Task<Book> GetByIdAsync(int id)
    {
      return await _context.Books.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task InsertAsync(Book entity)
    {
      _context.Books.Add(entity);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Book entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Book entity)
    {
      _context?.Books.Remove(entity);
      await _context.SaveChangesAsync();
    }
  }
}
