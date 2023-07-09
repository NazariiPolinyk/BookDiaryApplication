using BookDiaryApplication.Interfaces;

namespace BookDiaryApplication.Data.BookDiaryDB.Models
{
  public class Book : IEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public int AuthorRef { get; set; }
    public int GenreRef { get; set; }

    public Author Author { get; set; }
    public Genre Genre { get; set; }

    public ICollection<BookReview> BookReviews { get; set; }
  }
}
