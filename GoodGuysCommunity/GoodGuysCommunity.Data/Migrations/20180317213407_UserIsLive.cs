using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodGuysCommunity.Data.Migrations
{
    public partial class UserIsLive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLive",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLive",
                table: "AspNetUsers");
        }
    }
}
