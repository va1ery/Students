using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentsDB.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentID = table.Column<int>(nullable: false),
                    AssignmentDescription = table.Column<string>(maxLength: 255, nullable: true),
                    ClassID = table.Column<int>(nullable: false),
                    Exam = table.Column<bool>(nullable: false),
                    PercentOfGrade = table.Column<double>(nullable: true),
                    MaximumPoints = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassID = table.Column<int>(nullable: false),
                    ClassName = table.Column<string>(maxLength: 50, nullable: true),
                    DepartmentID = table.Column<int>(nullable: true),
                    Section = table.Column<short>(name: "Section №", nullable: true),
                    InstructorID = table.Column<int>(nullable: true),
                    Term = table.Column<string>(maxLength: 30, nullable: true),
                    Units = table.Column<string>(maxLength: 30, nullable: true),
                    Year = table.Column<short>(nullable: true),
                    Location = table.Column<string>(maxLength: 255, nullable: true),
                    DaysAndTimes = table.Column<string>(maxLength: 20, nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(nullable: false),
                    DepartmentName = table.Column<string>(maxLength: 50, nullable: true),
                    DepartmentNumber = table.Column<int>(nullable: true),
                    DepartmentManager = table.Column<string>(maxLength: 30, nullable: true),
                    DepartmentChairperson = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    InstructorID = table.Column<int>(nullable: false),
                    Instructor = table.Column<string>(maxLength: 50, nullable: true),
                    EmailName = table.Column<string>(maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 30, nullable: true),
                    Extension = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportID = table.Column<int>(nullable: false),
                    ReportName = table.Column<string>(maxLength: 50, nullable: true),
                    ReportDesc = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ResultsID = table.Column<int>(nullable: false),
                    StudentID = table.Column<int>(nullable: true),
                    AssignmentID = table.Column<int>(nullable: true),
                    Score = table.Column<double>(nullable: true),
                    Late = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    ParentsNames = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 255, nullable: true),
                    City = table.Column<string>(maxLength: 50, nullable: true),
                    StateOrProvince = table.Column<string>(maxLength: 20, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 20, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 30, nullable: true),
                    EmailName = table.Column<string>(maxLength: 50, nullable: true),
                    Major = table.Column<string>(maxLength: 50, nullable: true),
                    StudentNumber = table.Column<string>(maxLength: 30, nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Students And Classes",
                columns: table => new
                {
                    StudentClassID = table.Column<int>(nullable: false),
                    ClassID = table.Column<int>(nullable: false),
                    StudentID = table.Column<int>(nullable: true),
                    Grade = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students And Classes_1", x => x.StudentClassID);
                    table.ForeignKey(
                        name: "FK_Students And Classes_Classes",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Students And Classes_Students",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students And Classes_ClassID",
                table: "Students And Classes",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Students And Classes_StudentID",
                table: "Students And Classes",
                column: "StudentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Students And Classes");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
