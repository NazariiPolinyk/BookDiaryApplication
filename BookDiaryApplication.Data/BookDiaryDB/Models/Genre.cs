using BookDiaryApplication.Interfaces;

namespace BookDiaryApplication.Data.BookDiaryDB.Models
{
  public class Genre : IEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<Book> Books { get; set; }
  }
}
