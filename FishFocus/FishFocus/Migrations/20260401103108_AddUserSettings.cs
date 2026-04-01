using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishFocus.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSettings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BirdsVolume",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsBirdsEnabled",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNightMode",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRadioEnabled",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRainEnabled",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsThunderEnabled",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWavesEnabled",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PlayFog",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RadioVolume",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RainVolume",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThunderVolume",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WavesVolume",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirdsVolume",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsBirdsEnabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsNightMode",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsRadioEnabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsRainEnabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsThunderEnabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsWavesEnabled",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PlayFog",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RadioVolume",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RainVolume",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ThunderVolume",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WavesVolume",
                table: "Users");
        }
    }
}
