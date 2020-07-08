using Microsoft.EntityFrameworkCore.Migrations;

namespace MSA_StudentSIMS.Migrations
{
    public partial class updateStudentProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "midlleName",
                table: "Student");

            migrationBuilder.AddColumn<string>(
                name: "middleName",
                table: "Student",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "middleName",
                table: "Student");

            migrationBuilder.AddColumn<string>(
                name: "midlleName",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
