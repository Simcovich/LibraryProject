using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreDAL.Migrations
{
    public partial class discountvaluespublic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Discounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Discounts",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedDate",
                table: "Discounts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Discounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "PublishedDate",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Discounts");
        }
    }
}
