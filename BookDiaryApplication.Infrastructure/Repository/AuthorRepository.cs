using BookDiaryApplication.Interfaces;
using BookDiaryApplication.Data.BookDiaryDB.Models;
using BookDiaryApplication.Data.BookDiaryApplicationDB;
using Microsoft.EntityFrameworkCore;

namespace BookDiaryApplication.Infrastructure.Repository
{
  public class AuthorRepository : IRepository<Author>
  {
    private readonly BookDiaryContext _context;

    public AuthorRepository(BookDiaryContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Author>> GetAllAsync()
    {
      return await _context.Authors.AsNoTracking().ToListAsync();
    }

    public async Task<Author> GetByIdAsync(int id)
    {
      return await _context.Authors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task InsertAsync(Author entity)
    {
      _context.Authors.Add(entity);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Author entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Author entity)
    {
      _context?.Authors.Remove(entity);
      await _context.SaveChangesAsync();
    }
  }
}
