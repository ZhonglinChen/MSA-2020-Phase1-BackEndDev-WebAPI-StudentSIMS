using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MSA_StudentSIMS.Migrations
{
    public partial class UpdateModelStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "phoneNumber",
                table: "Student",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "timeCreated",
                table: "Student",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "phoneNumber",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "timeCreated",
                table: "Student");
        }
    }
}
