namespace BookDiaryApplication.Web.DTOs
{
  public class BookDTO
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public List<int> Authors { get; set; }
    public List<int> Genres { get; set; }
    public List<int> PublishingHouses { get; set; }
  }
}
