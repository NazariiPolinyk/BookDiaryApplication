using BookDiaryApplication.Interfaces;

namespace BookDiaryApplication.Data.BookDiaryDB.Models
{
  public class BookReview : IEntity
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Commentary { get; set; }
    public int UserRef { get; set; }
    public int BookRef { get; set; }

    public User User { get; set; }
    public Book Book { get; set; }
  }
}
