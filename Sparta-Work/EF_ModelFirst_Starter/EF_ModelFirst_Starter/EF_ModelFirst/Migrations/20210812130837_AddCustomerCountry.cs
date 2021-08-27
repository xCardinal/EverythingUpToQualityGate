using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_ModelFirst.Migrations
{
    public partial class AddCustomerCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress1",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Customers");
        }
    }
}
