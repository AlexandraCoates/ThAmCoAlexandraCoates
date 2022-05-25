using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class staffingrelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffings_Events_eventClassEventId",
                schema: "thamco.events",
                table: "Staffings");

            migrationBuilder.DropIndex(
                name: "IX_Staffings_eventClassEventId",
                schema: "thamco.events",
                table: "Staffings");

            migrationBuilder.DropColumn(
                name: "eventClassEventId",
                schema: "thamco.events",
                table: "Staffings");

            migrationBuilder.DropColumn(
                name: "Attendance",
                schema: "thamco.events",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_Staffings_EventId",
                schema: "thamco.events",
                table: "Staffings",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffings_Events_EventId",
                schema: "thamco.events",
                table: "Staffings",
                column: "EventId",
                principalSchema: "thamco.events",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffings_Events_EventId",
                schema: "thamco.events",
                table: "Staffings");

            migrationBuilder.DropIndex(
                name: "IX_Staffings_EventId",
                schema: "thamco.events",
                table: "Staffings");

            migrationBuilder.AddColumn<int>(
                name: "eventClassEventId",
                schema: "thamco.events",
                table: "Staffings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Attendance",
                schema: "thamco.events",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Staffings_eventClassEventId",
                schema: "thamco.events",
                table: "Staffings",
                column: "eventClassEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffings_Events_eventClassEventId",
                schema: "thamco.events",
                table: "Staffings",
                column: "eventClassEventId",
                principalSchema: "thamco.events",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
