using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class FKadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventId",
                schema: "thamco.events",
                table: "GuestBookings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "eventClassEventId",
                schema: "thamco.events",
                table: "GuestBookings",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "EventId",
                schema: "thamco.events",
                table: "GuestBookings");

            migrationBuilder.DropColumn(
                name: "eventClassEventId",
                schema: "thamco.events",
                table: "GuestBookings");
        }
    }
}
