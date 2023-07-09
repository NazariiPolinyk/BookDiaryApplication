using BookDiaryApplication.Interfaces;

namespace BookDiaryApplication.Data.BookDiaryDB.Models
{
  public class Author : IEntity
  {
    public int Id { get; set; }
    public string Name { get; set;}
    public string Description { get; set;}

    public ICollection<Book> Books { get; set; }
  }
}
