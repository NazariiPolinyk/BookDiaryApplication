namespace BookDiaryApplication.Interfaces
{
  public interface IRepository<T> where T : class, IEntity
  {
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task InsertAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
  }
}
