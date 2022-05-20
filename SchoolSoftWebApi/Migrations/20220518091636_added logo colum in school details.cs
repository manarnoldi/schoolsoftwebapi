using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSoftWeb.Migrations
{
    public partial class addedlogocoluminschooldetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "SchoolDetails");

            migrationBuilder.AddColumn<byte[]>(
                name: "Logo",
                table: "SchoolDetails",
                type: "longblob",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "SchoolDetails");

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "SchoolDetails",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
