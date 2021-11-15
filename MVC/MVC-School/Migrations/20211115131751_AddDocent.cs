using Microsoft.EntityFrameworkCore.Migrations;

namespace MVC_School.Migrations
{
    public partial class AddDocent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Docenten",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Voornaam = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Achternaam = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    LocatieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docenten", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Docenten_Locaties_LocatieId",
                        column: x => x.LocatieId,
                        principalTable: "Locaties",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Docenten_LocatieId",
                table: "Docenten",
                column: "LocatieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Docenten");
        }
    }
}
