using BookDiaryApplication.Interfaces;
using BookDiaryApplication.Data.BookDiaryDB.Models;
using BookDiaryApplication.Data.BookDiaryApplicationDB;
using Microsoft.EntityFrameworkCore;

namespace BookDiaryApplication.Infrastructure.Repository
{
  public class StoreRepository : IRepository<Store>
  {
    private readonly BookDiaryContext _context;

    public StoreRepository(BookDiaryContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Store>> GetAllAsync()
    {
      return await _context.Stores.AsNoTracking().ToListAsync();
    }

    public async Task<Store> GetByIdAsync(int id)
    {
      return await _context.Stores.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task InsertAsync(Store entity)
    {
      _context.Stores.Add(entity);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Store entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Store entity)
    {
      _context?.Stores.Remove(entity);
      await _context.SaveChangesAsync();
    }

    public bool Exists(int id)
    {
      return _context.Stores.Any(x => x.Id == id);
    }
  }
}
