using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegisterAPII.Migrations
{
    /// <inheritdoc />
    public partial class dattttttttttte : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$B2q7D2vRQry2e2hxv6JsduWKn7laMGfx0l9QPn11w5TsA7zhn.mVS");
        }
    }
}
