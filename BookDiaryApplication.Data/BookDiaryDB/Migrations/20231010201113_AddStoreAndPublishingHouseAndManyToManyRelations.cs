using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookDiaryApplication.Data.BookDiaryDB.Migrations
{
    /// <inheritdoc />
    public partial class AddStoreAndPublishingHouseAndManyToManyRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Author",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_Genre",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_AuthorRef",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_GenreRef",
                table: "Book");

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                columns: table => new
                {
                    AuthorsId = table.Column<int>(type: "int", nullable: false),
                    BooksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsId, x.BooksId });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Author_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookGenre",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookGenre", x => new { x.BooksId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_BookGenre_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookGenre_Genre_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublishingHouse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishingHouse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookPublishingHouse",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    PublishingHousesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookPublishingHouse", x => new { x.BooksId, x.PublishingHousesId });
                    table.ForeignKey(
                        name: "FK_BookPublishingHouse_Book_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookPublishingHouse_PublishingHouse_PublishingHousesId",
                        column: x => x.PublishingHousesId,
                        principalTable: "PublishingHouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublishingHouseStore",
                columns: table => new
                {
                    PublishingHousesId = table.Column<int>(type: "int", nullable: false),
                    StoresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishingHouseStore", x => new { x.PublishingHousesId, x.StoresId });
                    table.ForeignKey(
                        name: "FK_PublishingHouseStore_PublishingHouse_PublishingHousesId",
                        column: x => x.PublishingHousesId,
                        principalTable: "PublishingHouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublishingHouseStore_Store_StoresId",
                        column: x => x.StoresId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksId",
                table: "AuthorBook",
                column: "BooksId");

            migrationBuilder.CreateIndex(
                name: "IX_BookGenre_GenresId",
                table: "BookGenre",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_BookPublishingHouse_PublishingHousesId",
                table: "BookPublishingHouse",
                column: "PublishingHousesId");

            migrationBuilder.CreateIndex(
                name: "IX_PublishingHouseStore_StoresId",
                table: "PublishingHouseStore",
                column: "StoresId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook");

            migrationBuilder.DropTable(
                name: "BookGenre");

            migrationBuilder.DropTable(
                name: "BookPublishingHouse");

            migrationBuilder.DropTable(
                name: "PublishingHouseStore");

            migrationBuilder.DropTable(
                name: "PublishingHouse");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorRef",
                table: "Book",
                column: "AuthorRef");

            migrationBuilder.CreateIndex(
                name: "IX_Book_GenreRef",
                table: "Book",
                column: "GenreRef");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Author",
                table: "Book",
                column: "AuthorRef",
                principalTable: "Author",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Genre",
                table: "Book",
                column: "GenreRef",
                principalTable: "Genre",
                principalColumn: "Id");
        }
    }
}
