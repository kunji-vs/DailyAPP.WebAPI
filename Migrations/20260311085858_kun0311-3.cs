using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyAPP.WebAPI.Migrations
{
    public partial class kun03113 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "WaitInfo",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "WaitInfo");
        }
    }
}
