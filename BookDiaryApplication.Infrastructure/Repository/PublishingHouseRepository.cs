using BookDiaryApplication.Interfaces;
using BookDiaryApplication.Data.BookDiaryDB.Models;
using BookDiaryApplication.Data.BookDiaryApplicationDB;
using Microsoft.EntityFrameworkCore;

namespace BookDiaryApplication.Infrastructure.Repository
{
  public class PublishingHouseRepository : IRepository<PublishingHouse>
  {
    private readonly BookDiaryContext _context;

    public PublishingHouseRepository(BookDiaryContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<PublishingHouse>> GetAllAsync()
    {
      return await _context.PublishingHouses.AsNoTracking().ToListAsync();
    }

    public async Task<PublishingHouse> GetByIdAsync(int id)
    {
      return await _context.PublishingHouses.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task InsertAsync(PublishingHouse entity)
    {
      _context.PublishingHouses.Add(entity);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(PublishingHouse entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(PublishingHouse entity)
    {
      _context?.PublishingHouses.Remove(entity);
      await _context.SaveChangesAsync();
    }

    public bool Exists(int id)
    {
      return _context.PublishingHouses.Any(x => x.Id == id);
    }
  }
}
