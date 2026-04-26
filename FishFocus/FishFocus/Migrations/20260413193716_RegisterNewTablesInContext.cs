using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FishFocus.Migrations
{
    /// <inheritdoc />
    public partial class RegisterNewTablesInContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiaryEntry_Users_UserId",
                table: "DiaryEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_FishCatchResult_Fish_FishId",
                table: "FishCatchResult");

            migrationBuilder.DropForeignKey(
                name: "FK_FishCatchResult_Users_UserId",
                table: "FishCatchResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FishCatchResult",
                table: "FishCatchResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fish",
                table: "Fish");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiaryEntry",
                table: "DiaryEntry");

            migrationBuilder.RenameTable(
                name: "FishCatchResult",
                newName: "CaughtFishes");

            migrationBuilder.RenameTable(
                name: "Fish",
                newName: "Fishes");

            migrationBuilder.RenameTable(
                name: "DiaryEntry",
                newName: "DiaryEntries");

            migrationBuilder.RenameIndex(
                name: "IX_FishCatchResult_UserId",
                table: "CaughtFishes",
                newName: "IX_CaughtFishes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FishCatchResult_FishId",
                table: "CaughtFishes",
                newName: "IX_CaughtFishes_FishId");

            migrationBuilder.RenameIndex(
                name: "IX_DiaryEntry_UserId",
                table: "DiaryEntries",
                newName: "IX_DiaryEntries_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "CaughtFishes",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "DiaryEntries",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaughtFishes",
                table: "CaughtFishes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fishes",
                table: "Fishes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiaryEntries",
                table: "DiaryEntries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaughtFishes_Fishes_FishId",
                table: "CaughtFishes",
                column: "FishId",
                principalTable: "Fishes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaughtFishes_Users_UserId",
                table: "CaughtFishes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DiaryEntries_Users_UserId",
                table: "DiaryEntries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaughtFishes_Fishes_FishId",
                table: "CaughtFishes");

            migrationBuilder.DropForeignKey(
                name: "FK_CaughtFishes_Users_UserId",
                table: "CaughtFishes");

            migrationBuilder.DropForeignKey(
                name: "FK_DiaryEntries_Users_UserId",
                table: "DiaryEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fishes",
                table: "Fishes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiaryEntries",
                table: "DiaryEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaughtFishes",
                table: "CaughtFishes");

            migrationBuilder.RenameTable(
                name: "Fishes",
                newName: "Fish");

            migrationBuilder.RenameTable(
                name: "DiaryEntries",
                newName: "DiaryEntry");

            migrationBuilder.RenameTable(
                name: "CaughtFishes",
                newName: "FishCatchResult");

            migrationBuilder.RenameIndex(
                name: "IX_DiaryEntries_UserId",
                table: "DiaryEntry",
                newName: "IX_DiaryEntry_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CaughtFishes_UserId",
                table: "FishCatchResult",
                newName: "IX_FishCatchResult_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CaughtFishes_FishId",
                table: "FishCatchResult",
                newName: "IX_FishCatchResult_FishId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "DiaryEntry",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "FishCatchResult",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fish",
                table: "Fish",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiaryEntry",
                table: "DiaryEntry",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FishCatchResult",
                table: "FishCatchResult",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DiaryEntry_Users_UserId",
                table: "DiaryEntry",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FishCatchResult_Fish_FishId",
                table: "FishCatchResult",
                column: "FishId",
                principalTable: "Fish",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FishCatchResult_Users_UserId",
                table: "FishCatchResult",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
