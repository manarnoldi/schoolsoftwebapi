using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSoftWeb.Migrations
{
    public partial class addedmissiontoschooldetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mission",
                table: "SchoolDetails",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mission",
                table: "SchoolDetails");
        }
    }
}
