using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSoftWeb.Migrations
{
    public partial class RemovedStaffClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffClasses");

            migrationBuilder.AddColumn<int>(
                name: "StaffDetailsId",
                table: "SchoolClasses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "SchoolClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolClasses_StaffDetailsId",
                table: "SchoolClasses",
                column: "StaffDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_Person_StaffDetailsId",
                table: "SchoolClasses",
                column: "StaffDetailsId",
                principalTable: "Person",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_Person_StaffDetailsId",
                table: "SchoolClasses");

            migrationBuilder.DropIndex(
                name: "IX_SchoolClasses_StaffDetailsId",
                table: "SchoolClasses");

            migrationBuilder.DropColumn(
                name: "StaffDetailsId",
                table: "SchoolClasses");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "SchoolClasses");

            migrationBuilder.CreateTable(
                name: "StaffClasses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SchoolClassId = table.Column<int>(type: "int", nullable: false),
                    StaffDetailsId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Remarks = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffClasses_Person_StaffDetailsId",
                        column: x => x.StaffDetailsId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffClasses_SchoolClasses_SchoolClassId",
                        column: x => x.SchoolClassId,
                        principalTable: "SchoolClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_StaffClasses_SchoolClassId",
                table: "StaffClasses",
                column: "SchoolClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffClasses_StaffDetailsId",
                table: "StaffClasses",
                column: "StaffDetailsId");
        }
    }
}
