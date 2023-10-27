using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParksApi.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Description", "Fee", "Name" },
                values: new object[,]
                {
                    { 1, "Crater Lake inspires awe.", 30, "Crater Lake" },
                    { 2, "No agates, but a great place to see the sunset.", 0, "Agate Beach State Recreation Site" },
                    { 3, "This park has great birdwatching and tidepools to explore.", 0, "Fogarty Creek State Recreation Area" },
                    { 4, "Eons of acidic water seeping into marble rock created and decorated these wondrous marble halls.", 5, "Oregon Caves National Monument" },
                    { 5, "Colorful rock formations preserve a world class record of plant and animal evolution, changing climate, and past ecosystems that span over 40 million years.", 0, "John Day Fossil Beds National Monument" },
                    { 6, "This convergence of three geologically distinct mountain ranges has resulted in an area with unparalleled biological diversity and a tremendously varied landscape.", 0, "Cascade-Siskiyou National Monument" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 6);
        }
    }
}
