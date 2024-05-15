using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSoftWeb.Migrations
{
    public partial class RemovedStaffIdfromSchoolClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_Staffs_StaffDetailsId",
                table: "SchoolClasses");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "SchoolClasses");

            migrationBuilder.AlterColumn<int>(
                name: "StaffDetailsId",
                table: "SchoolClasses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_Staffs_StaffDetailsId",
                table: "SchoolClasses",
                column: "StaffDetailsId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_Staffs_StaffDetailsId",
                table: "SchoolClasses");

            migrationBuilder.AlterColumn<int>(
                name: "StaffDetailsId",
                table: "SchoolClasses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "SchoolClasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_Staffs_StaffDetailsId",
                table: "SchoolClasses",
                column: "StaffDetailsId",
                principalTable: "Staffs",
                principalColumn: "Id");
        }
    }
}
