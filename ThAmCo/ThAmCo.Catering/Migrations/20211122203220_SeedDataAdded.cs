using Microsoft.EntityFrameworkCore.Migrations;

namespace ThAmCo.Catering.Migrations
{
    public partial class SeedDataAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "thamco.catering",
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "Fish", 3.5f },
                    { 2, "Chips", 1.2f }
                });

            migrationBuilder.InsertData(
                schema: "thamco.catering",
                table: "Menus",
                columns: new[] { "MenuId", "MenuName" },
                values: new object[,]
                {
                    { 1, "Dinner" },
                    { 2, "Lunch" }
                });

            migrationBuilder.InsertData(
                schema: "thamco.catering",
                table: "FoodBookings",
                columns: new[] { "FoodBookingId", "ClientReferenceId", "MenuId", "NumberOfGuests" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                schema: "thamco.catering",
                table: "MenuFoodItems",
                columns: new[] { "MenuId", "FoodItemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "thamco.catering",
                table: "FoodBookings",
                keyColumn: "FoodBookingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "thamco.catering",
                table: "FoodBookings",
                keyColumn: "FoodBookingId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "thamco.catering",
                table: "MenuFoodItems",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                schema: "thamco.catering",
                table: "MenuFoodItems",
                keyColumns: new[] { "MenuId", "FoodItemId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                schema: "thamco.catering",
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "thamco.catering",
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "thamco.catering",
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "thamco.catering",
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 2);
        }
    }
}
