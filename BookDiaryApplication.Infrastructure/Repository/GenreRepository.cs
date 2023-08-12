using BookDiaryApplication.Interfaces;
using BookDiaryApplication.Data.BookDiaryDB.Models;
using BookDiaryApplication.Data.BookDiaryApplicationDB;
using Microsoft.EntityFrameworkCore;

namespace BookDiaryApplication.Infrastructure.Repository
{
  public class GenreRepository : IRepository<Genre>
  {
    private readonly BookDiaryContext _context;

    public GenreRepository(BookDiaryContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Genre>> GetAllAsync()
    {
      return await _context.Genres.AsNoTracking().ToListAsync();
    }

    public async Task<Genre> GetByIdAsync(int id)
    {
      return await _context.Genres.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task InsertAsync(Genre entity)
    {
      _context.Genres.Add(entity);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Genre entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Genre entity)
    {
      _context?.Genres.Remove(entity);
      await _context.SaveChangesAsync();
    }

    public bool Exists(int id)
    {
      return _context.Genres.Any(x => x.Id == id);
    }
  }
}
