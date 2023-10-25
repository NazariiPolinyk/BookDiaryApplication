namespace BookDiaryApplication.Web.DTOs
{
  public class PublishingHouseDTO
  {
    public string Name { get; set; }
    public string Description { get; set; }
    public string Country { get; set; }
    public List<int> Stores { get; set; }
  }
}
