using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HandicapMobile.MockAPI.Migrations
{
    public partial class AddTournamentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    TournamentId = table.Column<Guid>(nullable: false),
                    GolfClubId = table.Column<Guid>(nullable: false),
                    HasBeenCancelled = table.Column<bool>(nullable: false),
                    HasBeenCompleted = table.Column<bool>(nullable: false),
                    HasResultBeenProduced = table.Column<bool>(nullable: false),
                    MeasuredCourseId = table.Column<Guid>(nullable: false),
                    MeasuredCourseName = table.Column<string>(nullable: true),
                    MeasuredCourseSSS = table.Column<int>(nullable: false),
                    MeasuredCourseTeeColour = table.Column<string>(nullable: true),
                    PlayerCategory = table.Column<int>(nullable: false),
                    PlayersScoresRecordedCount = table.Column<int>(nullable: false),
                    PlayersSignedUpCount = table.Column<int>(nullable: false),
                    TournamentDate = table.Column<DateTime>(nullable: false),
                    TournamentFormat = table.Column<int>(nullable: false),
                    TournamentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.TournamentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tournaments");
        }
    }
}
