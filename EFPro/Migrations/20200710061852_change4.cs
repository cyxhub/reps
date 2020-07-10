using Microsoft.EntityFrameworkCore.Migrations;

namespace EFPro.Migrations
{
    public partial class change4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayer_Game_gameid",
                table: "GamePlayer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "games");

            migrationBuilder.AddPrimaryKey(
                name: "PK_games",
                table: "games",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayer_games_gameid",
                table: "GamePlayer",
                column: "gameid",
                principalTable: "games",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GamePlayer_games_gameid",
                table: "GamePlayer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_games",
                table: "games");

            migrationBuilder.RenameTable(
                name: "games",
                newName: "Game");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_GamePlayer_Game_gameid",
                table: "GamePlayer",
                column: "gameid",
                principalTable: "Game",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
