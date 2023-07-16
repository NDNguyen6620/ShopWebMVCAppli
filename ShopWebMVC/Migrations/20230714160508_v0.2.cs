using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopWebMVC.Migrations
{
    /// <inheritdoc />
    public partial class v02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_At", "Password" },
                values: new object[] { new DateTime(2023, 7, 14, 23, 5, 8, 76, DateTimeKind.Local).AddTicks(5056), "827CCB0EEA8A706C4C34A16891F84E7B" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Admin",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_At", "Password" },
                values: new object[] { new DateTime(2023, 7, 14, 18, 57, 22, 288, DateTimeKind.Local).AddTicks(453), "7A031016A73B550AEA96F6C9378E0BF5" });
        }
    }
}
