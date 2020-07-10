using Microsoft.EntityFrameworkCore.Migrations;

namespace EFPro.Migrations
{
    public partial class change3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "resumeid",
                table: "players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Resume",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(nullable: true),
                    playerid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resume", x => x.id);
                    table.ForeignKey(
                        name: "FK_Resume_players_playerid",
                        column: x => x.playerid,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resume_playerid",
                table: "Resume",
                column: "playerid",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resume");

            migrationBuilder.DropColumn(
                name: "resumeid",
                table: "players");
        }
    }
}
