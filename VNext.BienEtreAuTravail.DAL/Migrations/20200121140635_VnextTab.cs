using Microsoft.EntityFrameworkCore.Migrations;

namespace VNext.BienEtreAuTravail.DAL.Migrations
{
    public partial class VnextTab : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HumeurEmp_Humeur_IdHumeur",
                table: "HumeurEmp");

            migrationBuilder.DropIndex(
                name: "IX_HumeurEmp_IdHumeur",
                table: "HumeurEmp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Humeur",
                table: "Humeur");

            migrationBuilder.DropColumn(
                name: "IdHumeur",
                table: "Humeur");

            migrationBuilder.AddColumn<int>(
                name: "HumeurEmpMoodId",
                table: "HumeurEmp",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MoodId",
                table: "Humeur",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Humeur",
                table: "Humeur",
                column: "MoodId");

            migrationBuilder.CreateIndex(
                name: "IX_HumeurEmp_HumeurEmpMoodId",
                table: "HumeurEmp",
                column: "HumeurEmpMoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_HumeurEmp_Humeur_HumeurEmpMoodId",
                table: "HumeurEmp",
                column: "HumeurEmpMoodId",
                principalTable: "Humeur",
                principalColumn: "MoodId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HumeurEmp_Humeur_HumeurEmpMoodId",
                table: "HumeurEmp");

            migrationBuilder.DropIndex(
                name: "IX_HumeurEmp_HumeurEmpMoodId",
                table: "HumeurEmp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Humeur",
                table: "Humeur");

            migrationBuilder.DropColumn(
                name: "HumeurEmpMoodId",
                table: "HumeurEmp");

            migrationBuilder.DropColumn(
                name: "MoodId",
                table: "Humeur");

            migrationBuilder.AddColumn<int>(
                name: "IdHumeur",
                table: "Humeur",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Humeur",
                table: "Humeur",
                column: "IdHumeur");

            migrationBuilder.CreateIndex(
                name: "IX_HumeurEmp_IdHumeur",
                table: "HumeurEmp",
                column: "IdHumeur");

            migrationBuilder.AddForeignKey(
                name: "FK_HumeurEmp_Humeur_IdHumeur",
                table: "HumeurEmp",
                column: "IdHumeur",
                principalTable: "Humeur",
                principalColumn: "IdHumeur",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
