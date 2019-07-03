using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HandicapMobile.MockAPI.Migrations
{
    public partial class addmemberships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GolfClubMemberships",
                columns: table => new
                {
                    GolfClubId = table.Column<Guid>(nullable: false),
                    GolfClubName = table.Column<string>(nullable: true),
                    PlayerId = table.Column<Guid>(nullable: false),
                    MembershipId = table.Column<Guid>(nullable: false),
                    PlayerFullName = table.Column<string>(nullable: true),
                    PlayerDateOfBirth = table.Column<DateTime>(nullable: false),
                    PlayerGender = table.Column<string>(nullable: true),
                    AcceptedDateTime = table.Column<DateTime>(nullable: false),
                    RejectionDateTime = table.Column<DateTime>(nullable: false),
                    RejectionMessage = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GolfClubMemberships", x => x.MembershipId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GolfClubMemberships");
        }
    }
}
