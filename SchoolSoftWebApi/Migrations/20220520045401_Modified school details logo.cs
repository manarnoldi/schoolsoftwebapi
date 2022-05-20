using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSoftWeb.Migrations
{
    public partial class Modifiedschooldetailslogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "SchoolDetails");

            migrationBuilder.AddColumn<string>(
                name: "LogoAsBase64",
                table: "SchoolDetails",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoAsBase64",
                table: "SchoolDetails");

            migrationBuilder.AddColumn<byte[]>(
                name: "Logo",
                table: "SchoolDetails",
                type: "longblob",
                nullable: true);
        }
    }
}
