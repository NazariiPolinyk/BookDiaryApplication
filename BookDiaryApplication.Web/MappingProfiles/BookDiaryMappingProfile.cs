using AutoMapper;
using BookDiaryApplication.Data.BookDiaryDB.Models;
using BookDiaryApplication.Web.DTOs;

namespace BookDiaryApplication.Web.MappingProfiles
{
  public class BookDiaryMappingProfile : Profile
  {
    public BookDiaryMappingProfile() 
    {
      CreateMap<Author, AuthorDTO>().ReverseMap();
      CreateMap<Book, BookDTO>().ReverseMap();
      CreateMap<BookReview, BookReviewDTO>().ReverseMap();
      CreateMap<Genre, GenreDTO>().ReverseMap();
      CreateMap<User, UserDTO>().ReverseMap();
    }
  }
}
