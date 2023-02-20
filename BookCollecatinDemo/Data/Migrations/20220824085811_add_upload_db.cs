using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookCollecatinDemo.Data.Migrations
{
    public partial class add_upload_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookColleactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Authorname = table.Column<string>(nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    Rating = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookColleactions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookColleactions");
        }
    }
}
