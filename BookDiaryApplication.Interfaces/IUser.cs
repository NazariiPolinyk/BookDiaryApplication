namespace BookDiaryApplication.Interfaces
{
  public interface IUser : IEntity
  {
    public string Login { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }  
  }
}
