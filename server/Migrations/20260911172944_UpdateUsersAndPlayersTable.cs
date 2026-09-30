using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsersAndPlayersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "player_schools");

            migrationBuilder.DropTable(
                name: "player_profiles");

            migrationBuilder.DropTable(
                name: "schools");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Zipcode",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Headline = table.Column<string>(type: "text", nullable: true),
                    About = table.Column<string>(type: "text", nullable: true),
                    PrimaryPosition = table.Column<string>(type: "text", nullable: true),
                    SecondaryPosition = table.Column<string>(type: "text", nullable: true),
                    ClassYear = table.Column<int>(type: "integer", nullable: true),
                    Height = table.Column<double>(type: "double precision", nullable: true),
                    Weight = table.Column<double>(type: "double precision", nullable: true),
                    BenchPress = table.Column<double>(type: "double precision", nullable: true),
                    BackSquat = table.Column<double>(type: "double precision", nullable: true),
                    PowerClean = table.Column<double>(type: "double precision", nullable: true),
                    VerticalJump = table.Column<double>(type: "double precision", nullable: true),
                    BroadJump = table.Column<double>(type: "double precision", nullable: true),
                    FortyYardDash = table.Column<double>(type: "double precision", nullable: true),
                    ProfileImage = table.Column<string>(type: "text", nullable: true),
                    BannerImage = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_players", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_players_users_Id",
                        column: x => x.Id,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_players_Id",
                table: "players",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "players");

            migrationBuilder.DropColumn(
                name: "City",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "users");

            migrationBuilder.DropColumn(
                name: "State",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Zipcode",
                table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "player_profiles",
                columns: table => new
                {
                    PlayerProfileId = table.Column<int>(type: "integer", nullable: false),
                    About = table.Column<string>(type: "text", nullable: true),
                    BannerImage = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    ClassYear = table.Column<int>(type: "integer", nullable: true),
                    ContactEmail = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Headline = table.Column<string>(type: "text", nullable: true),
                    HeightInches = table.Column<int>(type: "integer", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true),
                    ProfileImage = table.Column<string>(type: "text", nullable: true),
                    SecondaryPosition = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WeightLbs = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player_profiles", x => x.PlayerProfileId);
                    table.ForeignKey(
                        name: "FK_player_profiles_users_PlayerProfileId",
                        column: x => x.PlayerProfileId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "schools",
                columns: table => new
                {
                    SchoolId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    City = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Division = table.Column<string>(type: "text", nullable: true),
                    LogoUrl = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    State = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schools", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "player_schools",
                columns: table => new
                {
                    PlayerSchoolId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerProfileId = table.Column<int>(type: "integer", nullable: false),
                    SchoolId = table.Column<int>(type: "integer", nullable: false),
                    EndYear = table.Column<int>(type: "integer", nullable: true),
                    IsCurrent = table.Column<bool>(type: "boolean", nullable: false),
                    Level = table.Column<string>(type: "text", nullable: true),
                    StartYear = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player_schools", x => x.PlayerSchoolId);
                    table.ForeignKey(
                        name: "FK_player_schools_player_profiles_PlayerProfileId",
                        column: x => x.PlayerProfileId,
                        principalTable: "player_profiles",
                        principalColumn: "PlayerProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_player_schools_schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_player_schools_PlayerProfileId",
                table: "player_schools",
                column: "PlayerProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_player_schools_SchoolId",
                table: "player_schools",
                column: "SchoolId");
        }
    }
}
