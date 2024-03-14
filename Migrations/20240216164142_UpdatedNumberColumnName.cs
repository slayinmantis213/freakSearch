using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace freakSearch.Migrations
{
    public partial class UpdatedNumberColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EpisodeNumber",
                table: "Episodes",
                newName: "NUMBER");

            migrationBuilder.RenameColumn(
                name: "EpisodeId",
                table: "Episodes",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NUMBER",
                table: "Episodes",
                newName: "EpisodeNumber");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Episodes",
                newName: "EpisodeId");
        }
    }
}
