using BookDiaryApplication.Interfaces;

namespace BookDiaryApplication.Data.BookDiaryDB.Models
{
  public class PublishingHouse : IEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Country { get; set; }
    public ICollection<Book> Books { get; set; }
    public ICollection<Store> Stores { get; set; }
  }
}
