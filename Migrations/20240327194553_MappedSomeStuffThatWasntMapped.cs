using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace freakSearch.Migrations
{
    public partial class MappedSomeStuffThatWasntMapped : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EpisodePresenter",
                columns: table => new
                {
                    EpisodesId = table.Column<int>(type: "int", nullable: false),
                    PresentersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodePresenter", x => new { x.EpisodesId, x.PresentersId });
                    table.ForeignKey(
                        name: "FK_EpisodePresenter_Episodes_EpisodesId",
                        column: x => x.EpisodesId,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodePresenter_Presenters_PresentersId",
                        column: x => x.PresentersId,
                        principalTable: "Presenters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodePresenter_PresentersId",
                table: "EpisodePresenter",
                column: "PresentersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpisodePresenter");
        }
    }
}
