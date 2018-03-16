using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GoodGuysCommunity.Data.Migrations
{
    public partial class resoursefolderpath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ResourceFolders",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "ResourceFolders",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Path",
                table: "ResourceFolders");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ResourceFolders",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
