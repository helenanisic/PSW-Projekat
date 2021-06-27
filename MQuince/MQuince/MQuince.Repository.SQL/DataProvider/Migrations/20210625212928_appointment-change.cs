using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MQuince.Repository.SQL.Migrations
{
    public partial class appointmentchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "StartDateTime",
                table: "Appointment");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Appointment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "StartTime",
                table: "Appointment",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Appointment");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                table: "Appointment",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDateTime",
                table: "Appointment",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
