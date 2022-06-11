using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSoftWeb.Migrations
{
    public partial class configuredtoTPT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Person_StaffDetailsId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Discipline_OccurenceTypes_OccurenceTypeId",
                table: "Discipline");

            migrationBuilder.DropForeignKey(
                name: "FK_Discipline_Outcomes_OutcomeId",
                table: "Discipline");

            migrationBuilder.DropForeignKey(
                name: "FK_Discipline_Person_StaffDetailsId",
                table: "Discipline");

            migrationBuilder.DropForeignKey(
                name: "FK_Discipline_Person_StudentId",
                table: "Discipline");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_Person_StudentId",
                table: "ExamResults");

            migrationBuilder.DropForeignKey(
                name: "FK_FormerSchools_Person_StudentId",
                table: "FormerSchools");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Designations_DesignationId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_EmploymentTypes_EmploymentTypeId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Genders_GenderId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_LearningModes_LearningModeId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Nationalities_NationalityId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Occupations_OccupationId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Religions_ReligionId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_StaffCategories_StaffCategoryId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_Person_StaffDetailsId",
                table: "SchoolClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_Person_StudentId",
                table: "SchoolClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffAttendances_Person_StaffDetailsId",
                table: "StaffAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffSubjects_Person_StaffDetailsId",
                table: "StaffSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_Person_StudentId",
                table: "StudentClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentParents_Person_ParentId",
                table: "StudentParents");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentParents_Person_StudentId",
                table: "StudentParents");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Person_StudentId",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Person_StaffDetailsId",
                table: "Subjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_DesignationId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_EmploymentTypeId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_LearningModeId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_OccupationId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_StaffCategoryId",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Discipline",
                table: "Discipline");

            migrationBuilder.DropIndex(
                name: "IX_Discipline_StaffDetailsId",
                table: "Discipline");

            migrationBuilder.DropIndex(
                name: "IX_Discipline_StudentId",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "StudentAttendances");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StudentAttendances");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "StudentAttendances");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "StudentAttendances");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "StudentAttendances");

            migrationBuilder.DropColumn(
                name: "Present",
                table: "StudentAttendances");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "StudentAttendances");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "StaffAttendances");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "StaffAttendances");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "StaffAttendances");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "StaffAttendances");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "StaffAttendances");

            migrationBuilder.DropColumn(
                name: "Present",
                table: "StaffAttendances");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "StaffAttendances");

            migrationBuilder.DropColumn(
                name: "AdmissionDate",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ApplicationDate",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "EmploymentTypeId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "HealthConcerns",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "IdNumber",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "LearningModeId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Notifiable",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "OccupationId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Payer",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Pickup",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "StaffCategoryId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "StaffDetailsId",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Discipline");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Discipline");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Persons");

            migrationBuilder.RenameTable(
                name: "Discipline",
                newName: "Disciplines");

            migrationBuilder.RenameIndex(
                name: "IX_Person_ReligionId",
                table: "Persons",
                newName: "IX_Persons_ReligionId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_NationalityId",
                table: "Persons",
                newName: "IX_Persons_NationalityId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_GenderId",
                table: "Persons",
                newName: "IX_Persons_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Discipline_OutcomeId",
                table: "Disciplines",
                newName: "IX_Disciplines_OutcomeId");

            migrationBuilder.RenameIndex(
                name: "IX_Discipline_OccurenceTypeId",
                table: "Disciplines",
                newName: "IX_Disciplines_OccurenceTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StudentAttendances",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StaffAttendances",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Disciplines",
                table: "Disciplines",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Attendances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Present = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Remarks = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Modified = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModifiedBy = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendances", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Notifiable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Payer = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Pickup = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    OccupationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parents_Occupations_OccupationId",
                        column: x => x.OccupationId,
                        principalTable: "Occupations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Parents_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Staffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IdNumber = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StaffCategoryId = table.Column<int>(type: "int", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false),
                    EmploymentTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Staffs_Designations_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staffs_EmploymentTypes_EmploymentTypeId",
                        column: x => x.EmploymentTypeId,
                        principalTable: "EmploymentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staffs_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staffs_StaffCategories_StaffCategoryId",
                        column: x => x.StaffCategoryId,
                        principalTable: "StaffCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    HealthConcerns = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LearningModeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_LearningModes_LearningModeId",
                        column: x => x.LearningModeId,
                        principalTable: "LearningModes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Persons_Id",
                        column: x => x.Id,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StaffDisciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    StaffDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffDisciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffDisciplines_Disciplines_Id",
                        column: x => x.Id,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffDisciplines_Staffs_StaffDetailsId",
                        column: x => x.StaffDetailsId,
                        principalTable: "Staffs",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "StudentDisciplines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentDisciplines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentDisciplines_Disciplines_Id",
                        column: x => x.Id,
                        principalTable: "Disciplines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentDisciplines_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Parents_OccupationId",
                table: "Parents",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffDisciplines_StaffDetailsId",
                table: "StaffDisciplines",
                column: "StaffDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_DesignationId",
                table: "Staffs",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_EmploymentTypeId",
                table: "Staffs",
                column: "EmploymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_StaffCategoryId",
                table: "Staffs",
                column: "StaffCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentDisciplines_StudentId",
                table: "StudentDisciplines",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_LearningModeId",
                table: "Students",
                column: "LearningModeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Staffs_StaffDetailsId",
                table: "Departments",
                column: "StaffDetailsId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_OccurenceTypes_OccurenceTypeId",
                table: "Disciplines",
                column: "OccurenceTypeId",
                principalTable: "OccurenceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Outcomes_OutcomeId",
                table: "Disciplines",
                column: "OutcomeId",
                principalTable: "Outcomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_Students_StudentId",
                table: "ExamResults",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormerSchools_Students_StudentId",
                table: "FormerSchools",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Genders_GenderId",
                table: "Persons",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Nationalities_NationalityId",
                table: "Persons",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Religions_ReligionId",
                table: "Persons",
                column: "ReligionId",
                principalTable: "Religions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_Staffs_StaffDetailsId",
                table: "SchoolClasses",
                column: "StaffDetailsId",
                principalTable: "Staffs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_Students_StudentId",
                table: "SchoolClasses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffAttendances_Attendances_Id",
                table: "StaffAttendances",
                column: "Id",
                principalTable: "Attendances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffAttendances_Staffs_StaffDetailsId",
                table: "StaffAttendances",
                column: "StaffDetailsId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffSubjects_Staffs_StaffDetailsId",
                table: "StaffSubjects",
                column: "StaffDetailsId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAttendances_Attendances_Id",
                table: "StudentAttendances",
                column: "Id",
                principalTable: "Attendances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_Students_StudentId",
                table: "StudentClasses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentParents_Parents_ParentId",
                table: "StudentParents",
                column: "ParentId",
                principalTable: "Parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentParents_Students_StudentId",
                table: "StudentParents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                table: "StudentSubjects",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Staffs_StaffDetailsId",
                table: "Subjects",
                column: "StaffDetailsId",
                principalTable: "Staffs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Staffs_StaffDetailsId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_OccurenceTypes_OccurenceTypeId",
                table: "Disciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Outcomes_OutcomeId",
                table: "Disciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamResults_Students_StudentId",
                table: "ExamResults");

            migrationBuilder.DropForeignKey(
                name: "FK_FormerSchools_Students_StudentId",
                table: "FormerSchools");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Genders_GenderId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Nationalities_NationalityId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Religions_ReligionId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_Staffs_StaffDetailsId",
                table: "SchoolClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolClasses_Students_StudentId",
                table: "SchoolClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffAttendances_Attendances_Id",
                table: "StaffAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffAttendances_Staffs_StaffDetailsId",
                table: "StaffAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_StaffSubjects_Staffs_StaffDetailsId",
                table: "StaffSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAttendances_Attendances_Id",
                table: "StudentAttendances");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentClasses_Students_StudentId",
                table: "StudentClasses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentParents_Parents_ParentId",
                table: "StudentParents");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentParents_Students_StudentId",
                table: "StudentParents");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Students_StudentId",
                table: "StudentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_Staffs_StaffDetailsId",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "Attendances");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "StaffDisciplines");

            migrationBuilder.DropTable(
                name: "StudentDisciplines");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Disciplines",
                table: "Disciplines");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Person");

            migrationBuilder.RenameTable(
                name: "Disciplines",
                newName: "Discipline");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_ReligionId",
                table: "Person",
                newName: "IX_Person_ReligionId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_NationalityId",
                table: "Person",
                newName: "IX_Person_NationalityId");

            migrationBuilder.RenameIndex(
                name: "IX_Persons_GenderId",
                table: "Person",
                newName: "IX_Person_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Disciplines_OutcomeId",
                table: "Discipline",
                newName: "IX_Discipline_OutcomeId");

            migrationBuilder.RenameIndex(
                name: "IX_Disciplines_OccurenceTypeId",
                table: "Discipline",
                newName: "IX_Discipline_OccurenceTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StudentAttendances",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "StudentAttendances",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "StudentAttendances",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "StudentAttendances",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "StudentAttendances",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "StudentAttendances",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Present",
                table: "StudentAttendances",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "StudentAttendances",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "StaffAttendances",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "StaffAttendances",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "StaffAttendances",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "StaffAttendances",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "StaffAttendances",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "StaffAttendances",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "Present",
                table: "StaffAttendances",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "StaffAttendances",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "AdmissionDate",
                table: "Person",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApplicationDate",
                table: "Person",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DesignationId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Person",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "EmploymentTypeId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HealthConcerns",
                table: "Person",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "IdNumber",
                table: "Person",
                type: "varchar(255)",
                maxLength: 255,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "LearningModeId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Notifiable",
                table: "Person",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OccupationId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Payer",
                table: "Person",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Pickup",
                table: "Person",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffCategoryId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Discipline",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "StaffDetailsId",
                table: "Discipline",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Discipline",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Discipline",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Discipline",
                table: "Discipline",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Person_DesignationId",
                table: "Person",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_EmploymentTypeId",
                table: "Person",
                column: "EmploymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_LearningModeId",
                table: "Person",
                column: "LearningModeId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_OccupationId",
                table: "Person",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_StaffCategoryId",
                table: "Person",
                column: "StaffCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_StaffDetailsId",
                table: "Discipline",
                column: "StaffDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Discipline_StudentId",
                table: "Discipline",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Person_StaffDetailsId",
                table: "Departments",
                column: "StaffDetailsId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discipline_OccurenceTypes_OccurenceTypeId",
                table: "Discipline",
                column: "OccurenceTypeId",
                principalTable: "OccurenceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discipline_Outcomes_OutcomeId",
                table: "Discipline",
                column: "OutcomeId",
                principalTable: "Outcomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discipline_Person_StaffDetailsId",
                table: "Discipline",
                column: "StaffDetailsId",
                principalTable: "Person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Discipline_Person_StudentId",
                table: "Discipline",
                column: "StudentId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResults_Person_StudentId",
                table: "ExamResults",
                column: "StudentId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormerSchools_Person_StudentId",
                table: "FormerSchools",
                column: "StudentId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Designations_DesignationId",
                table: "Person",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_EmploymentTypes_EmploymentTypeId",
                table: "Person",
                column: "EmploymentTypeId",
                principalTable: "EmploymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Genders_GenderId",
                table: "Person",
                column: "GenderId",
                principalTable: "Genders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_LearningModes_LearningModeId",
                table: "Person",
                column: "LearningModeId",
                principalTable: "LearningModes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Nationalities_NationalityId",
                table: "Person",
                column: "NationalityId",
                principalTable: "Nationalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Occupations_OccupationId",
                table: "Person",
                column: "OccupationId",
                principalTable: "Occupations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Religions_ReligionId",
                table: "Person",
                column: "ReligionId",
                principalTable: "Religions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_StaffCategories_StaffCategoryId",
                table: "Person",
                column: "StaffCategoryId",
                principalTable: "StaffCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_Person_StaffDetailsId",
                table: "SchoolClasses",
                column: "StaffDetailsId",
                principalTable: "Person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolClasses_Person_StudentId",
                table: "SchoolClasses",
                column: "StudentId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffAttendances_Person_StaffDetailsId",
                table: "StaffAttendances",
                column: "StaffDetailsId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StaffSubjects_Person_StaffDetailsId",
                table: "StaffSubjects",
                column: "StaffDetailsId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentClasses_Person_StudentId",
                table: "StudentClasses",
                column: "StudentId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentParents_Person_ParentId",
                table: "StudentParents",
                column: "ParentId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentParents_Person_StudentId",
                table: "StudentParents",
                column: "StudentId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Person_StudentId",
                table: "StudentSubjects",
                column: "StudentId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_Person_StaffDetailsId",
                table: "Subjects",
                column: "StaffDetailsId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
