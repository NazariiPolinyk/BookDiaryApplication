using BookDiaryApplication.Data.BookDiaryApplicationDB;
using BookDiaryApplication.Data.BookDiaryDB.Models;
using BookDiaryApplication.Infrastructure.Repository;
using BookDiaryApplication.Interfaces;
using BookDiaryApplication.Web.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BookDiaryContext>();
builder.Services.AddScoped(typeof(IRepository<Author>), typeof(AuthorRepository));
builder.Services.AddScoped(typeof(IRepository<Book>), typeof(BookRepository));
builder.Services.AddScoped(typeof(IRepository<BookReview>), typeof(BookReviewRepository));
builder.Services.AddScoped(typeof(IRepository<Genre>), typeof(GenreRepository));
builder.Services.AddScoped(typeof(IRepository<User>), typeof(UserRepository));
builder.Services.AddAutoMapper(typeof(BookDiaryMappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
