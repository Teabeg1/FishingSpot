using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FishFocus.Migrations
{
    /// <inheritdoc />
    public partial class AddFishIdKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiaryEntry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompletionTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MinutesSpent = table.Column<int>(type: "integer", nullable: false),
                    FishName = table.Column<string>(type: "text", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiaryEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiaryEntry_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Rarity = table.Column<int>(type: "integer", nullable: false),
                    Points = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    MinMinutes = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fish", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FishCatchResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FishId = table.Column<int>(type: "integer", nullable: false),
                    MinutesFished = table.Column<int>(type: "integer", nullable: false),
                    BasePoints = table.Column<int>(type: "integer", nullable: false),
                    TimeBonus = table.Column<int>(type: "integer", nullable: false),
                    TotalPoints = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishCatchResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FishCatchResult_Fish_FishId",
                        column: x => x.FishId,
                        principalTable: "Fish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FishCatchResult_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiaryEntry_UserId",
                table: "DiaryEntry",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FishCatchResult_FishId",
                table: "FishCatchResult",
                column: "FishId");

            migrationBuilder.CreateIndex(
                name: "IX_FishCatchResult_UserId",
                table: "FishCatchResult",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiaryEntry");

            migrationBuilder.DropTable(
                name: "FishCatchResult");

            migrationBuilder.DropTable(
                name: "Fish");
        }
    }
}
