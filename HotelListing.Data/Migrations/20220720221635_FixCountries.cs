using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.API.Migrations
{
    public partial class FixCountries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08eb4958-6725-43d4-ab20-99ad1b8598dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e17e4a9-86dd-4357-afcb-90b4f6f9ffbf");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b108e2f5-ddd2-4a9d-b101-1d61b86d0a40", "03413904-cba1-40c8-ae9a-52d443a39a82", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c93e6c0b-fe69-42b1-8284-a6b9024dbe92", "b771d4ba-0443-4909-9001-3c0d07fae894", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "08eb4958-6725-43d4-ab20-99ad1b8598dd", "ddf3a245-785f-486f-bc70-884b4bc59920", "Administrator", "ADMINISTRATOR" },
                    { "4e17e4a9-86dd-4357-afcb-90b4f6f9ffbf", "18510f1d-bd57-4dc9-84a1-f10b87f53694", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { 4, "Canada", "CA" },
                    { 5, "Netherlands", "NL" }
                });
        }
    }
}
