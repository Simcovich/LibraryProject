using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace BookStoreDAL.Migrations
{
    public partial class addeddiscountsmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Publishers_PublisherId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Authors_AuthorFK",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_AuthorFK",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "PublisherId",
                table: "Items",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Items",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Items",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Percent = table.Column<float>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_AuthorId",
                table: "Items",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Publishers_PublisherId",
                table: "Items",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Authors_AuthorId",
                table: "Items",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Publishers_PublisherId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Authors_AuthorId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Items_AuthorId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Items");

            migrationBuilder.AlterColumn<int>(
                name: "PublisherId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_Items_AuthorFK",
                table: "Items",
                column: "AuthorFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Publishers_PublisherId",
                table: "Items",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Authors_AuthorFK",
                table: "Items",
                column: "AuthorFK",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}