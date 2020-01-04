using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VNext.BienEtreAuTravail.DAL.Migrations
{
    public partial class VnextTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commentaires",
                columns: table => new
                {
                    IdCommentaire = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Created_at = table.Column<DateTime>(nullable: false),
                    Updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaires", x => x.IdCommentaire);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pseudo = table.Column<string>(nullable: true),
                    Created_at = table.Column<DateTime>(nullable: false),
                    Updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.IdEmployee);
                });

            migrationBuilder.CreateTable(
                name: "CommentaireEmps",
                columns: table => new
                {
                    IdEmployee = table.Column<int>(nullable: false),
                    IdCommentaire = table.Column<int>(nullable: false),
                    EmployeeIdEmployee = table.Column<int>(nullable: true),
                    CommentaireIdCommentaire = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentaireEmps", x => new { x.IdEmployee, x.IdCommentaire });
                    table.ForeignKey(
                        name: "FK_CommentaireEmps_Commentaires_CommentaireIdCommentaire",
                        column: x => x.CommentaireIdCommentaire,
                        principalTable: "Commentaires",
                        principalColumn: "IdCommentaire",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommentaireEmps_Employees_EmployeeIdEmployee",
                        column: x => x.EmployeeIdEmployee,
                        principalTable: "Employees",
                        principalColumn: "IdEmployee",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentaireEmps_CommentaireIdCommentaire",
                table: "CommentaireEmps",
                column: "CommentaireIdCommentaire");

            migrationBuilder.CreateIndex(
                name: "IX_CommentaireEmps_EmployeeIdEmployee",
                table: "CommentaireEmps",
                column: "EmployeeIdEmployee");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentaireEmps");

            migrationBuilder.DropTable(
                name: "Commentaires");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
