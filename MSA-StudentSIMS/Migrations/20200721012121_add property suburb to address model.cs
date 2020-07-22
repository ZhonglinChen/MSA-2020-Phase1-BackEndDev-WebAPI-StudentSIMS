using Microsoft.EntityFrameworkCore.Migrations;

namespace MSA_StudentSIMS.Migrations
{
    public partial class addpropertysuburbtoaddressmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "suburb",
                table: "Address",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "suburb",
                table: "Address");
        }
    }
}
