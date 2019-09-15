using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HandicapMobile.MockAPI.Migrations
{
    public partial class AddPlayerTournamentsSignUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlayerTournamentSignIns",
                columns: table => new
                {
                    PlayerId = table.Column<Guid>(nullable: false),
                    TournamentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTournamentSignIns", x => new { x.PlayerId, x.TournamentId });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerTournamentSignIns");
        }
    }
}
