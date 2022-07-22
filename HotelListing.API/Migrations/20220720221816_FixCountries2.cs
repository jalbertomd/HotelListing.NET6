using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.API.Migrations
{
    public partial class FixCountries2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b108e2f5-ddd2-4a9d-b101-1d61b86d0a40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c93e6c0b-fe69-42b1-8284-a6b9024dbe92");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "24627b97-3d26-4d01-af9b-5c3651d43de5", "3fe85351-60d9-4316-a9a6-99ff367aa646", "User", "USER" },
                    { "c854decd-4d44-47dc-b3dc-0b881d936533", "a8a80a8f-c4d7-4ff5-88b6-c417838990d9", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { 6, "Netherlands", "NL" },
                    { 7, "Canada", "CA" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "24627b97-3d26-4d01-af9b-5c3651d43de5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c854decd-4d44-47dc-b3dc-0b881d936533");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b108e2f5-ddd2-4a9d-b101-1d61b86d0a40", "03413904-cba1-40c8-ae9a-52d443a39a82", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c93e6c0b-fe69-42b1-8284-a6b9024dbe92", "b771d4ba-0443-4909-9001-3c0d07fae894", "User", "USER" });
        }
    }
}
