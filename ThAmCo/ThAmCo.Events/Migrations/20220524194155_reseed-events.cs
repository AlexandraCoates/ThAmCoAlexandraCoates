using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class reseedevents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "thamco.events",
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                column: "EventTitle",
                value: "Wedding");

            migrationBuilder.UpdateData(
                schema: "thamco.events",
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                column: "EventTitle",
                value: "Meeting");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "thamco.events",
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1,
                column: "EventTitle",
                value: null);

            migrationBuilder.UpdateData(
                schema: "thamco.events",
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2,
                column: "EventTitle",
                value: null);
        }
    }
}
