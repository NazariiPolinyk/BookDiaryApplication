using BookDiaryApplication.Interfaces;
using BookDiaryApplication.Data.BookDiaryDB.Models;
using BookDiaryApplication.Data.BookDiaryApplicationDB;
using Microsoft.EntityFrameworkCore;

namespace BookDiaryApplication.Infrastructure.Repository
{
  public class UserRepository : IRepository<User>
  {
    private readonly BookDiaryContext _context;

    public UserRepository(BookDiaryContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
      return await _context.Users.AsNoTracking().ToListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
      return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task InsertAsync(User entity)
    {
      _context.Users.Add(entity);
      await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User entity)
    {
      _context.Entry(entity).State = EntityState.Modified;
      await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User entity)
    {
      _context?.Users.Remove(entity);
      await _context.SaveChangesAsync();
    }

    public bool Exists(int id)
    {
      return _context.Users.Any(x => x.Id == id);
    }
  }
}
