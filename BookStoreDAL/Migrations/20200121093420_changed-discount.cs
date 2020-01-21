using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreDAL.Migrations
{
    public partial class changeddiscount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Percent",
                table: "Discounts",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Percent",
                table: "Discounts",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}