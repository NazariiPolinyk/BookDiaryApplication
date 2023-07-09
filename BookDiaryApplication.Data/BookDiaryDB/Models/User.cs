using BookDiaryApplication.Interfaces;

namespace BookDiaryApplication.Data.BookDiaryDB.Models
{
  public class User : IUser
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string? Token { get; set; }

    public ICollection<BookReview> BookReviews { get; set; }
  }
}
