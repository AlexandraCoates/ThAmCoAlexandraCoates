using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "thamco.events",
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "Attendance", "Email", "NameFirst", "NameLast", "Phone", "PostCode" },
                values: new object[,]
                {
                    { 1, "22 Upton Street", false, "alexandra@email.com", "Alex", "Coates", 7519, "TS13NE" },
                    { 2, "21 Some Street", false, "David@email.com", "David", "Hodson", 8765, "TS52NE" }
                });

            migrationBuilder.InsertData(
                schema: "thamco.events",
                table: "Events",
                columns: new[] { "EventId", "EventType" },
                values: new object[,]
                {
                    { 1, "WED" },
                    { 2, "MET" }
                });

            migrationBuilder.InsertData(
                schema: "thamco.events",
                table: "Staffs",
                columns: new[] { "StaffId", "Address", "Email", "FirstAider", "NameFirst", "NameLast", "Phone", "PostCode" },
                values: new object[,]
                {
                    { 1, "An Address", "personOne@gmail.com", false, "Person", "One", 0, "YO8" },
                    { 2, "A Place", "Human@gmail.com", true, "Human", "Two", 11111, "LS1" }
                });

            migrationBuilder.InsertData(
                schema: "thamco.events",
                table: "GuestBookings",
                columns: new[] { "GuestBookingId", "CustomerId", "EventId", "eventClassEventId" },
                values: new object[,]
                {
                    { 1, 1, 1, null },
                    { 2, 2, 2, null }
                });

            migrationBuilder.InsertData(
                schema: "thamco.events",
                table: "Staffings",
                columns: new[] { "StaffingId", "EventId", "StaffId", "eventClassEventId" },
                values: new object[,]
                {
                    { 1, 1, 1, null },
                    { 2, 2, 2, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "thamco.events",
                table: "Events",
                keyColumn: "EventId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "thamco.events",
                table: "Events",
                keyColumn: "EventId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "thamco.events",
                table: "GuestBookings",
                keyColumn: "GuestBookingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "thamco.events",
                table: "GuestBookings",
                keyColumn: "GuestBookingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "thamco.events",
                table: "Staffings",
                keyColumn: "StaffingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "thamco.events",
                table: "Staffings",
                keyColumn: "StaffingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "thamco.events",
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "thamco.events",
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "thamco.events",
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "thamco.events",
                table: "Staffs",
                keyColumn: "StaffId",
                keyValue: 2);
        }
    }
}
