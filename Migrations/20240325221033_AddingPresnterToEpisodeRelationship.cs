using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace freakSearch.Migrations
{
    public partial class AddingPresnterToEpisodeRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PresentedBys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PresenterId = table.Column<int>(type: "int", nullable: false),
                    EpisodeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentedBys", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresentedBys_Episodes_EpisodeId",
                        column: x => x.EpisodeId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresentedBys_Presenters_PresenterId",
                        column: x => x.PresenterId,
                        principalTable: "Presenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PresentedBys_EpisodeId",
                table: "PresentedBys",
                column: "EpisodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PresentedBys_PresenterId",
                table: "PresentedBys",
                column: "PresenterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresentedBys");
        }
    }
}
