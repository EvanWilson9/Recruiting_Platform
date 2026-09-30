using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class AddAthleticCareers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "athletic_careers",
                columns: table => new
                {
                    AthleticCareersId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    SchoolId = table.Column<int>(type: "integer", nullable: false),
                    Sport = table.Column<string>(type: "text", nullable: true),
                    level = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_athletic_careers", x => x.AthleticCareersId);
                    table.ForeignKey(
                        name: "FK_athletic_careers_players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_athletic_careers_schools_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "schools",
                        principalColumn: "SchoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_athletic_careers_PlayerId",
                table: "athletic_careers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_athletic_careers_SchoolId",
                table: "athletic_careers",
                column: "SchoolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "athletic_careers");
        }
    }
}
