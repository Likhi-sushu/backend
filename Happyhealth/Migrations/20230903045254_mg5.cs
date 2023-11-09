using Microsoft.EntityFrameworkCore.Migrations;

namespace Happyhealth.Migrations
{
    public partial class mg5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TreatmentType",
                table: "ScheduleAppointment");

            migrationBuilder.AddColumn<string>(
                name: "HealthIssue",
                table: "ScheduleAppointment",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SelectDoctor",
                table: "ScheduleAppointment",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SelectSlot",
                table: "ScheduleAppointment",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HealthIssue",
                table: "ScheduleAppointment");

            migrationBuilder.DropColumn(
                name: "SelectDoctor",
                table: "ScheduleAppointment");

            migrationBuilder.DropColumn(
                name: "SelectSlot",
                table: "ScheduleAppointment");

            migrationBuilder.AddColumn<string>(
                name: "TreatmentType",
                table: "ScheduleAppointment",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
