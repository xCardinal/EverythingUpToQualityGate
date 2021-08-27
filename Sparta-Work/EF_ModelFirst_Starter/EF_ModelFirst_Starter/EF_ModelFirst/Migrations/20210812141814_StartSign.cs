using Microsoft.EntityFrameworkCore.Migrations;

namespace EF_ModelFirst.Migrations
{
    public partial class StartSign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "starSigns",
                columns: table => new
                {
                    StarSignId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_starSigns", x => x.StarSignId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "starSigns");
        }
    }
}
