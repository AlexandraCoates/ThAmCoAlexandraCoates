using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class addingbookingstoevents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventClassEventId",
                schema: "thamco.events",
                table: "GuestBookings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuestBookings_EventClassEventId",
                schema: "thamco.events",
                table: "GuestBookings",
                column: "EventClassEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestBookings_Events_EventClassEventId",
                schema: "thamco.events",
                table: "GuestBookings",
                column: "EventClassEventId",
                principalSchema: "thamco.events",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestBookings_Events_EventClassEventId",
                schema: "thamco.events",
                table: "GuestBookings");

            migrationBuilder.DropIndex(
                name: "IX_GuestBookings_EventClassEventId",
                schema: "thamco.events",
                table: "GuestBookings");

            migrationBuilder.DropColumn(
                name: "EventClassEventId",
                schema: "thamco.events",
                table: "GuestBookings");
        }
    }
}
