using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class cascadetest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestBookings_Events_EventId",
                schema: "thamco.events",
                table: "GuestBookings");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestBookings_Events_EventId",
                schema: "thamco.events",
                table: "GuestBookings",
                column: "EventId",
                principalSchema: "thamco.events",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestBookings_Events_EventId",
                schema: "thamco.events",
                table: "GuestBookings");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestBookings_Events_EventId",
                schema: "thamco.events",
                table: "GuestBookings",
                column: "EventId",
                principalSchema: "thamco.events",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
