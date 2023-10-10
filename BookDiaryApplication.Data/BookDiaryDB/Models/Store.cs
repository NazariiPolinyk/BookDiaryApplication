﻿

namespace BookDiaryApplication.Data.BookDiaryDB.Models
{
  public class Store
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ICollection<PublishingHouse> PublishingHouses { get; set; }
  }
}
