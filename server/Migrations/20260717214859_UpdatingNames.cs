using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_player_profiles_users_Id",
                table: "player_profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_player_schools_player_profiles_PlayerId",
                table: "player_schools");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "schools",
                newName: "SchoolId");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "player_schools",
                newName: "PlayerProfileId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "player_schools",
                newName: "PlayerSchoolId");

            migrationBuilder.RenameIndex(
                name: "IX_player_schools_PlayerId",
                table: "player_schools",
                newName: "IX_player_schools_PlayerProfileId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "player_profiles",
                newName: "PlayerProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_player_profiles_users_PlayerProfileId",
                table: "player_profiles",
                column: "PlayerProfileId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_player_schools_player_profiles_PlayerProfileId",
                table: "player_schools",
                column: "PlayerProfileId",
                principalTable: "player_profiles",
                principalColumn: "PlayerProfileId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_player_profiles_users_PlayerProfileId",
                table: "player_profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_player_schools_player_profiles_PlayerProfileId",
                table: "player_schools");

            migrationBuilder.RenameColumn(
                name: "SchoolId",
                table: "schools",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PlayerProfileId",
                table: "player_schools",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "PlayerSchoolId",
                table: "player_schools",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_player_schools_PlayerProfileId",
                table: "player_schools",
                newName: "IX_player_schools_PlayerId");

            migrationBuilder.RenameColumn(
                name: "PlayerProfileId",
                table: "player_profiles",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_player_profiles_users_Id",
                table: "player_profiles",
                column: "Id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_player_schools_player_profiles_PlayerId",
                table: "player_schools",
                column: "PlayerId",
                principalTable: "player_profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
