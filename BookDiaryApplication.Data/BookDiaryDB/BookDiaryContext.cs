﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BookDiaryApplication.Data.BookDiaryDB.Models;

namespace BookDiaryApplication.Data.BookDiaryApplicationDB
{
  public class BookDiaryContext : DbContext
  {
    protected readonly IConfiguration Configuration;

    public BookDiaryContext() { }

    public BookDiaryContext(DbContextOptions<BookDiaryContext> options, IConfiguration configuration) : base(options)
    {
      Configuration = configuration;
    }

    public virtual DbSet<Author> Authors { get; set; }
    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<BookReview> BookReviews { get; set; }
    public virtual DbSet<Genre> Genres { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<PublishingHouse> PublishingHouses { get; set; }
    public virtual DbSet<Store> Stores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Author>(entity =>
      {
        entity.ToTable("Author");

        entity.Property(e => e.Name).IsRequired();

        entity.Property(e => e.Description).IsRequired(false);
      });

      modelBuilder.Entity<Book>(entity => 
      {
        entity.ToTable("Book");

        entity.Property(e => e.Name).IsRequired();

        entity.Property(e => e.Description).IsRequired(false);

        entity.Property(e => e.ReleaseDate).IsRequired(false)
                                           .HasColumnType("date");

        entity.HasMany(a => a.Authors)
              .WithMany(b => b.Books);

        entity.HasMany(g => g.Genres)
              .WithMany(b => b.Books);
      });

      modelBuilder.Entity<Genre>(entity =>
      {
        entity.ToTable("Genre");

        entity.Property(e => e.Name).IsRequired();

        entity.Property(e => e.Description).IsRequired(false);
      });

      modelBuilder.Entity<BookReview>(entity =>
      {
        entity.ToTable("BookReview");

        entity.Property(e => e.Title).IsRequired();

        entity.Property(e => e.Commentary).IsRequired();

        entity.HasOne(u => u.User)
              .WithMany(b => b.BookReviews)
              .HasForeignKey(u => u.UserRef)
              .HasConstraintName("FK_BookReview_User")
              .OnDelete(DeleteBehavior.ClientSetNull);

        entity.HasOne(b => b.Book)
              .WithMany(br => br.BookReviews)
              .HasForeignKey(b => b.BookRef)
              .HasConstraintName("FK_BookReview_Book")
              .OnDelete(DeleteBehavior.ClientSetNull);
      });

      modelBuilder.Entity<User>(entity =>
      {
        entity.ToTable("User");

        entity.Property(e => e.Name).IsRequired();

        entity.Property(e => e.Login).IsRequired();

        entity.Property(e => e.Email).IsRequired();

        entity.Property(e => e.Password).IsRequired();
      });

      modelBuilder.Entity<PublishingHouse>(entity =>
      {
        entity.ToTable("PublishingHouse");

        entity.Property(e => e.Name).IsRequired();

        entity.Property(e => e.Description).IsRequired();

        entity.Property(e => e.Country).IsRequired();

        entity.HasMany(e => e.Books)
              .WithMany(e => e.PublishingHouses);

        entity.HasMany(e => e.Stores)
              .WithMany(e => e.PublishingHouses);
      });

      modelBuilder.Entity<Store>(entity =>
      {
        entity.ToTable("Store");

        entity.Property(e => e.Name).IsRequired();

        entity.Property(e => e.Description).IsRequired();
      });
    }
  }
}
