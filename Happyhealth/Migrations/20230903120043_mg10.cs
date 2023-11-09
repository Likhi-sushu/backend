using Microsoft.EntityFrameworkCore.Migrations;

namespace Happyhealth.Migrations
{
    public partial class mg10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "Doctor");

            migrationBuilder.AddColumn<string>(
                name: "Patientreviews",
                table: "Doctor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Doctor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Speciality",
                table: "Doctor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Patientreviews",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Speciality",
                table: "Doctor");

            migrationBuilder.AddColumn<string>(
                name: "Specialty",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
