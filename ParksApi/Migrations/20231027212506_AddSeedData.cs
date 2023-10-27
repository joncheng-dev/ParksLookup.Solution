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
                columns: new[] { "ParkId", "CampingAllowed", "Description", "DogsAllowed", "Fee", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "yes", "Crater Lake inspires awe.", "yes", 30, "Crater Lake", "open" },
                    { 2, "yes", "No agates, but a great place to see the sunset.", "yes", 0, "Agate Beach State Recreation Site", "open" },
                    { 3, "yes", "This park has great birdwatching and tidepools to explore.", "yes", 0, "Fogarty Creek State Recreation Area", "open" },
                    { 4, "no", "Eons of acidic water seeping into marble rock created and decorated these wondrous marble halls.", "no", 5, "Oregon Caves National Monument", "closed" },
                    { 5, "no", "Colorful rock formations preserve a world class record of plant and animal evolution, changing climate, and past ecosystems that span over 40 million years.", "no", 0, "John Day Fossil Beds National Monument", "open" },
                    { 6, "yes", "This convergence of three geologically distinct mountain ranges has resulted in an area with unparalleled biological diversity and a tremendously varied landscape.", "yes", 0, "Cascade-Siskiyou National Monument", "open" }
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
