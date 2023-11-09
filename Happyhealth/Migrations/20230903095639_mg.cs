using Microsoft.EntityFrameworkCore.Migrations;

namespace Happyhealth.Migrations
{
    public partial class mg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Doctor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
