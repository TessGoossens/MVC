using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_School.Migrations
{
    public partial class AddAllChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vak_Locaties_LocatieID",
                table: "Vak");

            migrationBuilder.DropIndex(
                name: "IX_Vak_LocatieID",
                table: "Vak");

            migrationBuilder.DropColumn(
                name: "LocatieID",
                table: "Vak");

            migrationBuilder.AddColumn<int>(
                name: "VakId",
                table: "Docent",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VakId",
                table: "Docent");

            migrationBuilder.AddColumn<int>(
                name: "LocatieID",
                table: "Vak",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vak_LocatieID",
                table: "Vak",
                column: "LocatieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vak_Locaties_LocatieID",
                table: "Vak",
                column: "LocatieID",
                principalTable: "Locaties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
