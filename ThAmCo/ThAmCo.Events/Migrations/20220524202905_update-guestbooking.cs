using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class updateguestbooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestBookings_Events_eventClassEventId",
                schema: "thamco.events",
                table: "GuestBookings");

            migrationBuilder.DropIndex(
                name: "IX_GuestBookings_eventClassEventId",
                schema: "thamco.events",
                table: "GuestBookings");

            migrationBuilder.DropColumn(
                name: "eventClassEventId",
                schema: "thamco.events",
                table: "GuestBookings");

            migrationBuilder.CreateIndex(
                name: "IX_GuestBookings_EventId",
                schema: "thamco.events",
                table: "GuestBookings",
                column: "EventId");

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

            migrationBuilder.DropIndex(
                name: "IX_GuestBookings_EventId",
                schema: "thamco.events",
                table: "GuestBookings");

            migrationBuilder.AddColumn<int>(
                name: "eventClassEventId",
                schema: "thamco.events",
                table: "GuestBookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuestBookings_eventClassEventId",
                schema: "thamco.events",
                table: "GuestBookings",
                column: "eventClassEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestBookings_Events_eventClassEventId",
                schema: "thamco.events",
                table: "GuestBookings",
                column: "eventClassEventId",
                principalSchema: "thamco.events",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
