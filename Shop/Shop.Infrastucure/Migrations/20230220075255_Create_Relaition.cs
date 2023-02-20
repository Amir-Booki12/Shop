using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastucture.Migrations
{
    public partial class Create_Relaition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"

                ALTER TABLE [seller].Invertories
                ADD CONSTRAINT FK_Invertories_Products_ProductId
                FOREIGN KEY (ProductId) REFERENCES [product].Products(Id)

                ");
            migrationBuilder.Sql(@"

                ALTER TABLE [order].OrderItems
                ADD CONSTRAINT FK_OrderItems_Invertories_InvertoryId
                FOREIGN KEY (InvertoryId) REFERENCES [seller].Invertories(Id)

                ");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
