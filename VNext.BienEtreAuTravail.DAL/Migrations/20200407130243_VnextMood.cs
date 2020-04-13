using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VNext.BienEtreAuTravail.DAL.Migrations
{
    public partial class VnextMood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departement",
                columns: table => new
                {
                    IdDepartement = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomDepartement = table.Column<string>(nullable: true),
                    NomResponsable = table.Column<string>(nullable: true),
                    Created_at = table.Column<DateTime>(nullable: false),
                    Updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departement", x => x.IdDepartement);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesDto",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pseudo = table.Column<string>(nullable: true),
                    Created_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesDto", x => x.IdEmployee);
                });

            migrationBuilder.CreateTable(
                name: "Moods",
                columns: table => new
                {
                    MoodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<int>(nullable: false),
                    Created_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moods", x => x.MoodId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pseudo = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    IsDepartmentManager = table.Column<bool>(nullable: false),
                    Created_at = table.Column<DateTime>(nullable: false),
                    Updated_at = table.Column<DateTime>(nullable: false),
                    IdDepartement = table.Column<int>(nullable: false),
                    DepartementIdDepartement = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.IdEmployee);
                    table.ForeignKey(
                        name: "FK_Employees_Departement_DepartementIdDepartement",
                        column: x => x.DepartementIdDepartement,
                        principalTable: "Departement",
                        principalColumn: "IdDepartement",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commentaire",
                columns: table => new
                {
                    IdCommentaire = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Created_at = table.Column<DateTime>(nullable: false),
                    Updated_at = table.Column<DateTime>(nullable: false),
                    CommentOfEmployee = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaire", x => x.IdCommentaire);
                    table.ForeignKey(
                        name: "FK_Commentaire_Employees_CommentOfEmployee",
                        column: x => x.CommentOfEmployee,
                        principalTable: "Employees",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HumeurEmp",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(nullable: false),
                    IdHumeur = table.Column<int>(nullable: false),
                    HumeurEmpMoodId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HumeurEmp", x => new { x.IdEmployee, x.IdHumeur });
                    table.ForeignKey(
                        name: "FK_HumeurEmp_Moods_HumeurEmpMoodId",
                        column: x => x.HumeurEmpMoodId,
                        principalTable: "Moods",
                        principalColumn: "MoodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HumeurEmp_Employees_IdEmployee",
                        column: x => x.IdEmployee,
                        principalTable: "Employees",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commentaire_CommentOfEmployee",
                table: "Commentaire",
                column: "CommentOfEmployee",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartementIdDepartement",
                table: "Employees",
                column: "DepartementIdDepartement");

            migrationBuilder.CreateIndex(
                name: "IX_HumeurEmp_HumeurEmpMoodId",
                table: "HumeurEmp",
                column: "HumeurEmpMoodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commentaire");

            migrationBuilder.DropTable(
                name: "EmployeesDto");

            migrationBuilder.DropTable(
                name: "HumeurEmp");

            migrationBuilder.DropTable(
                name: "Moods");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departement");
        }
    }
}
