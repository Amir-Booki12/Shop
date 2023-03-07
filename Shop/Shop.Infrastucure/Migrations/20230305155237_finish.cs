using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastucture.Migrations
{
    public partial class finish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "user",
                table: "Users",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                schema: "user",
                table: "Users",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_PhoneNumber",
                schema: "user",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "user",
                table: "Users");
        }
    }
}
