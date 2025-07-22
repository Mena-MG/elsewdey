using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegisterAPII.Migrations
{
    /// <inheritdoc />
    public partial class ddddddddddddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "batolmagdy092@gmail.com");

            migrationBuilder.UpdateData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "batolmagdy092@gmail.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "user1.role1@example.com");

            migrationBuilder.UpdateData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "user1.role1@example.com");
        }
    }
}
