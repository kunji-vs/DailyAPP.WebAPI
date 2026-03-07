using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyAPP.WebAPI.Migrations
{
    public partial class kun0305 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountInfo",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Account = table.Column<string>(type: "TEXT", nullable: false),
                    Pwd = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountInfo", x => x.AccountId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountInfo");
        }
    }
}
