using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStartYearAndMonth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "athletic_careers");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "athletic_careers");

            migrationBuilder.AddColumn<int>(
                name: "EndMonth",
                table: "player_schools",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartMonth",
                table: "player_schools",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EndMonth",
                table: "athletic_careers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EndYear",
                table: "athletic_careers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartMonth",
                table: "athletic_careers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartYear",
                table: "athletic_careers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndMonth",
                table: "player_schools");

            migrationBuilder.DropColumn(
                name: "StartMonth",
                table: "player_schools");

            migrationBuilder.DropColumn(
                name: "EndMonth",
                table: "athletic_careers");

            migrationBuilder.DropColumn(
                name: "EndYear",
                table: "athletic_careers");

            migrationBuilder.DropColumn(
                name: "StartMonth",
                table: "athletic_careers");

            migrationBuilder.DropColumn(
                name: "StartYear",
                table: "athletic_careers");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "athletic_careers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "athletic_careers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
