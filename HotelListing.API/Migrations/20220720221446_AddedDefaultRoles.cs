using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.API.Migrations
{
    public partial class AddedDefaultRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
