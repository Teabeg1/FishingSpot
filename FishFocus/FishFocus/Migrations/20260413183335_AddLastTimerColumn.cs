using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishFocus.Migrations
{
    /// <inheritdoc />
    public partial class AddLastTimerColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LastSelectedMinutes",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastSelectedMinutes",
                table: "Users");
        }
    }
}
