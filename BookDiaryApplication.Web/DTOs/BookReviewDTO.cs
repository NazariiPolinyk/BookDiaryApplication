namespace BookDiaryApplication.Web.DTOs
{
  public class BookReviewDTO
  {
    public string Title { get; set; }
    public string Commentary { get; set; }
    public int UserRef { get; set; }
    public int BookRef { get; set; }
  }
}
