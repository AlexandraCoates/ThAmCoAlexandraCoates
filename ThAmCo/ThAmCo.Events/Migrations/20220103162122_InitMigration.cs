using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Events.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "thamco.events");

            migrationBuilder.CreateTable(
                name: "Customers",
                schema: "thamco.events",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFirst = table.Column<string>(nullable: true),
                    NameLast = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    Attendance = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                schema: "thamco.events",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Staffs",
                schema: "thamco.events",
                columns: table => new
                {
                    StaffId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFirst = table.Column<string>(nullable: true),
                    NameLast = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    FirstAider = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "GuestBookings",
                schema: "thamco.events",
                columns: table => new
                {
                    GuestBookingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestBookings", x => x.GuestBookingId);
                    table.ForeignKey(
                        name: "FK_GuestBookings_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "thamco.events",
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Staffings",
                schema: "thamco.events",
                columns: table => new
                {
                    StaffingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    eventClassEventId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffings", x => x.StaffingId);
                    table.ForeignKey(
                        name: "FK_Staffings_Staffs_StaffId",
                        column: x => x.StaffId,
                        principalSchema: "thamco.events",
                        principalTable: "Staffs",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Staffings_Events_eventClassEventId",
                        column: x => x.eventClassEventId,
                        principalSchema: "thamco.events",
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestBookings_CustomerId",
                schema: "thamco.events",
                table: "GuestBookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffings_StaffId",
                schema: "thamco.events",
                table: "Staffings",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffings_eventClassEventId",
                schema: "thamco.events",
                table: "Staffings",
                column: "eventClassEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestBookings",
                schema: "thamco.events");

            migrationBuilder.DropTable(
                name: "Staffings",
                schema: "thamco.events");

            migrationBuilder.DropTable(
                name: "Customers",
                schema: "thamco.events");

            migrationBuilder.DropTable(
                name: "Staffs",
                schema: "thamco.events");

            migrationBuilder.DropTable(
                name: "Events",
                schema: "thamco.events");
        }
    }
}
