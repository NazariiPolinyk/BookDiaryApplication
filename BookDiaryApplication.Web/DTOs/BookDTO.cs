namespace BookDiaryApplication.Web.DTOs
{
  public class BookDTO
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public int AuthorRef { get; set; }
    public int GenreRef { get; set; }
  }
}
