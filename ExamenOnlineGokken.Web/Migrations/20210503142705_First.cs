using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExamenOnlineGokken.Web.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Hometeam = table.Column<string>(nullable: true),
                    AwayTeam = table.Column<string>(nullable: true),
                    DateOfGame = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    Outcome = table.Column<string>(nullable: true),
                    BetAmount = table.Column<decimal>(type: "Decimal", nullable: false),
                    UserId = table.Column<long>(nullable: false),
                    GameId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => new { x.GameId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Bets_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "AwayTeam", "DateOfGame", "Hometeam" },
                values: new object[,]
                {
                    { 1L, "Cagliari", new DateTime(2020, 1, 20, 15, 30, 0, 0, DateTimeKind.Unspecified), "Juventus" },
                    { 16L, "Arsenal", new DateTime(2020, 2, 21, 20, 30, 0, 0, DateTimeKind.Unspecified), "Olympiacos" },
                    { 15L, "AS Roma", new DateTime(2020, 2, 27, 20, 30, 0, 0, DateTimeKind.Unspecified), "AA Gent" },
                    { 14L, "Man United", new DateTime(2020, 2, 20, 21, 30, 0, 0, DateTimeKind.Unspecified), "Club Brugge" },
                    { 13L, "Inter Milan", new DateTime(2020, 2, 20, 20, 30, 0, 0, DateTimeKind.Unspecified), "Ludogorets" },
                    { 12L, "Barcelona", new DateTime(2020, 2, 25, 21, 0, 0, 0, DateTimeKind.Unspecified), "Napoli" },
                    { 10L, "Valencia", new DateTime(2020, 2, 19, 20, 30, 0, 0, DateTimeKind.Unspecified), "Atalanta" },
                    { 9L, "Liverpool", new DateTime(2020, 2, 18, 20, 30, 0, 0, DateTimeKind.Unspecified), "Atletico Madrid" },
                    { 11L, "Bayern", new DateTime(2020, 2, 19, 20, 30, 0, 0, DateTimeKind.Unspecified), "Chelsea" },
                    { 7L, "FC Antwerp", new DateTime(2020, 1, 23, 20, 30, 0, 0, DateTimeKind.Unspecified), "Standard" },
                    { 6L, "AA Gent", new DateTime(2020, 1, 23, 18, 30, 0, 0, DateTimeKind.Unspecified), "KRC Genk" },
                    { 5L, "Cercle Brugge", new DateTime(2020, 1, 23, 13, 30, 0, 0, DateTimeKind.Unspecified), "Club Brugge" },
                    { 4L, "Bologna", new DateTime(2020, 1, 20, 20, 30, 0, 0, DateTimeKind.Unspecified), "Milan" },
                    { 3L, "Cagliari", new DateTime(2020, 1, 20, 15, 30, 0, 0, DateTimeKind.Unspecified), "Napoli" },
                    { 2L, "Pescara", new DateTime(2020, 1, 21, 18, 30, 0, 0, DateTimeKind.Unspecified), "Inter" },
                    { 8L, "Cercle Brugge", new DateTime(2020, 1, 23, 13, 30, 0, 0, DateTimeKind.Unspecified), "Club Brugge" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[,]
                {
                    { 4L, "qsdflkjqmlj43ézearf", "Siegfried" },
                    { 1L, "qsdflkjqmlj43ézearf", "Mileto" },
                    { 2L, "qsdflkjqmlj43ézearf", "Bart" },
                    { 3L, "qsdflkjqmlj43ézearf", "William" },
                    { 5L, "qsdflkjqmlj43ézearf", "Joachim" }
                });

            migrationBuilder.InsertData(
                table: "Bets",
                columns: new[] { "GameId", "UserId", "BetAmount", "Outcome" },
                values: new object[,]
                {
                    { 1L, 1L, 0m, null },
                    { 6L, 1L, 0m, null },
                    { 10L, 1L, 0m, null },
                    { 9L, 2L, 0m, null },
                    { 11L, 2L, 0m, null },
                    { 12L, 2L, 0m, null },
                    { 16L, 3L, 0m, null },
                    { 8L, 3L, 0m, null },
                    { 13L, 3L, 0m, null },
                    { 14L, 3L, 0m, null },
                    { 3L, 4L, 0m, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_UserId",
                table: "Bets",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
