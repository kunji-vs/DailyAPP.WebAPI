using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyAPP.WebAPI.Migrations
{
    public partial class kun0311 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MenuIconName = table.Column<string>(type: "TEXT", nullable: false),
                    MenuName = table.Column<string>(type: "TEXT", nullable: false),
                    ViewName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuInfo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuInfo");
        }
    }
}
