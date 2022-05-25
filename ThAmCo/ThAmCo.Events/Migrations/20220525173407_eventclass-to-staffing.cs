using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class eventclasstostaffing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EventClassEventId",
                schema: "thamco.events",
                table: "Staffings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Staffings_EventClassEventId",
                schema: "thamco.events",
                table: "Staffings",
                column: "EventClassEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffings_Events_EventClassEventId",
                schema: "thamco.events",
                table: "Staffings",
                column: "EventClassEventId",
                principalSchema: "thamco.events",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffings_Events_EventClassEventId",
                schema: "thamco.events",
                table: "Staffings");

            migrationBuilder.DropIndex(
                name: "IX_Staffings_EventClassEventId",
                schema: "thamco.events",
                table: "Staffings");

            migrationBuilder.DropColumn(
                name: "EventClassEventId",
                schema: "thamco.events",
                table: "Staffings");
        }
    }
}
