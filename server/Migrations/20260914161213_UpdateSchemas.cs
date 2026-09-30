using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchemas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_athletic_careers_schools_SchoolId",
                table: "athletic_careers");

            migrationBuilder.DropForeignKey(
                name: "FK_players_users_Id",
                table: "players");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "players",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_players_Id",
                table: "players",
                newName: "IX_players_UserId");

            migrationBuilder.RenameColumn(
                name: "AthleticCareersId",
                table: "athletic_careers",
                newName: "AthleticCareerId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "NOW()");

            migrationBuilder.CreateTable(
                name: "player_schools",
                columns: table => new
                {
                    PlayerSchoolId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    SchoolId = table.Column<int>(type: "integer", nullable: false),
                    StartYear = table.Column<int>(type: "integer", nullable: false),
                    EndYear = table.Column<int>(type: "integer", nullable: true),
                    Level = table.Column<string>(type: "text", nullable: true),
                    Gpa = table.Column<double>(type: "double precision", nullable: true),
                    SAT = table.Column<int>(type: "integer", nullable: true),
                    ACT = table.Column<int>(type: "integer", nullable: true),
                    IsCurrent = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player_schools", x => x.PlayerSchoolId);
                    table.ForeignKey(
                        name: "FK_player_schools_players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_player_schools_schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_player_schools_PlayerId",
                table: "player_schools",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_player_schools_SchoolId",
                table: "player_schools",
                column: "SchoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_athletic_careers_schools_SchoolId",
                table: "athletic_careers",
                column: "SchoolId",
                principalTable: "schools",
                principalColumn: "SchoolId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_players_users_UserId",
                table: "players",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_athletic_careers_schools_SchoolId",
                table: "athletic_careers");

            migrationBuilder.DropForeignKey(
                name: "FK_players_users_UserId",
                table: "players");

            migrationBuilder.DropTable(
                name: "player_schools");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "players",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_players_UserId",
                table: "players",
                newName: "IX_players_Id");

            migrationBuilder.RenameColumn(
                name: "AthleticCareerId",
                table: "athletic_careers",
                newName: "AthleticCareersId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "NOW()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddForeignKey(
                name: "FK_athletic_careers_schools_SchoolId",
                table: "athletic_careers",
                column: "SchoolId",
                principalTable: "schools",
                principalColumn: "SchoolId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_players_users_Id",
                table: "players",
                column: "Id",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
