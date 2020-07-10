using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFPro.Migrations
{
    public partial class change2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    round = table.Column<string>(nullable: true),
                    startTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GamePlayer",
                columns: table => new
                {
                    playerid = table.Column<int>(nullable: false),
                    gameid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayer", x => new { x.playerid, x.gameid });
                    table.ForeignKey(
                        name: "FK_GamePlayer_Game_gameid",
                        column: x => x.gameid,
                        principalTable: "Game",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayer_players_playerid",
                        column: x => x.playerid,
                        principalTable: "players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayer_gameid",
                table: "GamePlayer",
                column: "gameid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GamePlayer");

            migrationBuilder.DropTable(
                name: "Game");
        }
    }
}
