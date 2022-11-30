using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeeLive.Infrastructure.Migrations
{
    public partial class event_date_time : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Venues",
                schema: "dbo",
                newName: "Venues");

            migrationBuilder.RenameTable(
                name: "Events",
                schema: "dbo",
                newName: "Events");

            migrationBuilder.RenameTable(
                name: "EventListing",
                schema: "dbo",
                newName: "EventListing");

            migrationBuilder.RenameTable(
                name: "Artists",
                schema: "dbo",
                newName: "Artists");

            migrationBuilder.AddColumn<DateTime>(
                name: "EventDateTime",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventDateTime",
                table: "Events");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Venues",
                newName: "Venues",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Events",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "EventListing",
                newName: "EventListing",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Artists",
                newName: "Artists",
                newSchema: "dbo");
        }
    }
}
