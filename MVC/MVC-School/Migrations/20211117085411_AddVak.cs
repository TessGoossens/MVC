using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_School.Migrations
{
    public partial class AddVak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Docenten_Locaties_LocatieId",
                table: "Docenten");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Docenten",
                table: "Docenten");

            migrationBuilder.RenameTable(
                name: "Docenten",
                newName: "Docent");

            migrationBuilder.RenameIndex(
                name: "IX_Docenten_LocatieId",
                table: "Docent",
                newName: "IX_Docent_LocatieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Docent",
                table: "Docent",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Vak",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    DocentId = table.Column<int>(type: "int", nullable: false),
                    LocatieID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vak", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Vak_Docent_DocentId",
                        column: x => x.DocentId,
                        principalTable: "Docent",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vak_Locaties_LocatieID",
                        column: x => x.LocatieID,
                        principalTable: "Locaties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vak_DocentId",
                table: "Vak",
                column: "DocentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vak_LocatieID",
                table: "Vak",
                column: "LocatieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Docent_Locaties_LocatieId",
                table: "Docent",
                column: "LocatieId",
                principalTable: "Locaties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Docent_Locaties_LocatieId",
                table: "Docent");

            migrationBuilder.DropTable(
                name: "Vak");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Docent",
                table: "Docent");

            migrationBuilder.RenameTable(
                name: "Docent",
                newName: "Docenten");

            migrationBuilder.RenameIndex(
                name: "IX_Docent_LocatieId",
                table: "Docenten",
                newName: "IX_Docenten_LocatieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Docenten",
                table: "Docenten",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Docenten_Locaties_LocatieId",
                table: "Docenten",
                column: "LocatieId",
                principalTable: "Locaties",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
