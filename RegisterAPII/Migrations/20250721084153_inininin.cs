using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RegisterAPII.Migrations
{
    /// <inheritdoc />
    public partial class inininin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FullName", "NationalID" },
                values: new object[] { "user1.role1@example.com", "User 1 (Role 1)", "30101010000001" });

            migrationBuilder.UpdateData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "NationalID" },
                values: new object[] { "user1.role1@example.com", "30101010000001" });

            migrationBuilder.InsertData(
                table: "LoginAccounts",
                columns: new[] { "Id", "AccountId", "Email", "NationalID", "Password" },
                values: new object[,]
                {
                    { 2, 2, "user2.role1@example.com", "30101010000002", "StrongPassword123" },
                    { 3, 3, "user3.role1@example.com", "30101010000003", "StrongPassword123" },
                    { 4, 4, "user4.role1@example.com", "30101010000004", "StrongPassword123" },
                    { 5, 5, "user5.role1@example.com", "30101010000005", "StrongPassword123" },
                    { 6, 6, "user6.role2@example.com", "30101010000006", "StrongPassword123" },
                    { 7, 7, "user7.role2@example.com", "30101010000007", "StrongPassword123" },
                    { 8, 8, "user8.role2@example.com", "30101010000008", "StrongPassword123" },
                    { 9, 9, "user9.role2@example.com", "30101010000009", "StrongPassword123" },
                    { 10, 10, "user10.role2@example.com", "30101010000010", "StrongPassword123" },
                    { 11, 11, "user11.role3@example.com", "30101010000011", "StrongPassword123" },
                    { 12, 12, "user12.role3@example.com", "30101010000012", "StrongPassword123" },
                    { 13, 13, "user13.role3@example.com", "30101010000013", "StrongPassword123" },
                    { 14, 14, "user14.role3@example.com", "30101010000014", "StrongPassword123" },
                    { 15, 15, "user15.role3@example.com", "30101010000015", "StrongPassword123" },
                    { 16, 16, "user16.role4@example.com", "30101010000016", "StrongPassword123" },
                    { 17, 17, "user17.role4@example.com", "30101010000017", "StrongPassword123" },
                    { 18, 18, "user18.role4@example.com", "30101010000018", "StrongPassword123" },
                    { 19, 19, "user19.role4@example.com", "30101010000019", "StrongPassword123" },
                    { 20, 20, "user20.role4@example.com", "30101010000020", "StrongPassword123" },
                    { 21, 21, "user21.role5@example.com", "30101010000021", "StrongPassword123" },
                    { 22, 22, "user22.role5@example.com", "30101010000022", "StrongPassword123" },
                    { 23, 23, "user23.role5@example.com", "30101010000023", "StrongPassword123" },
                    { 24, 24, "user24.role5@example.com", "30101010000024", "StrongPassword123" },
                    { 25, 25, "user25.role5@example.com", "30101010000025", "StrongPassword123" },
                    { 26, 26, "user26.role6@example.com", "30101010000026", "StrongPassword123" },
                    { 27, 27, "user27.role6@example.com", "30101010000027", "StrongPassword123" },
                    { 28, 28, "user28.role6@example.com", "30101010000028", "StrongPassword123" },
                    { 29, 29, "user29.role6@example.com", "30101010000029", "StrongPassword123" },
                    { 30, 30, "user30.role6@example.com", "30101010000030", "StrongPassword123" },
                    { 31, 31, "user31.role7@example.com", "30101010000031", "StrongPassword123" },
                    { 32, 32, "user32.role7@example.com", "30101010000032", "StrongPassword123" },
                    { 33, 33, "user33.role7@example.com", "30101010000033", "StrongPassword123" },
                    { 34, 34, "user34.role7@example.com", "30101010000034", "StrongPassword123" },
                    { 35, 35, "user35.role7@example.com", "30101010000035", "StrongPassword123" }
                });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "IsActive", "LoginId", "NationalID", "PasswordHash", "ResetToken", "ResetTokenExpiry", "RoleId" },
                values: new object[,]
                {
                    { 2, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user2.role1@example.com", "User 2 (Role 1)", true, 2, "30101010000002", "$2a$11$u3f.mJ4FvGgB3Oa8n.dJ9eA.a9K.L4k5b2mC6n7o8pQ9r0sT1uV2w", null, null, 1 },
                    { 3, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user3.role1@example.com", "User 3 (Role 1)", true, 3, "30101010000003", "$2a$11$xY1z.a2B3c4D5e6F7g8H9iJ0kL1mN2oP3qR4sT5uV6wX7yZ8A9b0c", null, null, 1 },
                    { 4, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user4.role1@example.com", "User 4 (Role 1)", true, 4, "30101010000004", "$2a$11$C1d2E3f4G5h6I7j8K9l0M1n2O3p4Q5r6S7t8U9v0W1x2Y3z4A5b6c", null, null, 1 },
                    { 5, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user5.role1@example.com", "User 5 (Role 1)", true, 5, "30101010000005", "$2a$11$dE4fG5h6I7j8K9l0M1n2O3p4Q5r6S7t8U9v0W1x2Y3z4A5b6c7D8e", null, null, 1 },
                    { 6, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user6.role2@example.com", "User 6 (Role 2)", true, 6, "30101010000006", "$2a$11$fG6hI7j8K9l0M1n2O3p4Q5r6S7t8U9v0W1x2Y3z4A5b6c7D8e9F0g", null, null, 2 },
                    { 7, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user7.role2@example.com", "User 7 (Role 2)", true, 7, "30101010000007", "$2a$11$hI8jK9l0M1n2O3p4Q5r6S7t8U9v0W1x2Y3z4A5b6c7D8e9F0g1H2i", null, null, 2 },
                    { 8, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user8.role2@example.com", "User 8 (Role 2)", true, 8, "30101010000008", "$2a$11$jK0lM1n2O3p4Q5r6S7t8U9v0W1x2Y3z4A5b6c7D8e9F0g1H2i3J4k", null, null, 2 },
                    { 9, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user9.role2@example.com", "User 9 (Role 2)", true, 9, "30101010000009", "$2a$11$lM2nO3p4Q5r6S7t8U9v0W1x2Y3z4A5b6c7D8e9F0g1H2i3J4k5L6m", null, null, 2 },
                    { 10, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user10.role2@example.com", "User 10 (Role 2)", true, 10, "30101010000010", "$2a$11$nO4pQ5r6S7t8U9v0W1x2Y3z4A5b6c7D8e9F0g1H2i3J4k5L6m7N8o", null, null, 2 },
                    { 11, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user11.role3@example.com", "User 11 (Role 3)", true, 11, "30101010000011", "$2a$11$pQ6rS7t8U9v0W1x2Y3z4A5b6c7D8e9F0g1H2i3J4k5L6m7N8o9P0q", null, null, 3 },
                    { 12, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user12.role3@example.com", "User 12 (Role 3)", true, 12, "30101010000012", "$2a$11$rS8tU9v0W1x2Y3z4A5b6c7D8e9F0g1H2i3J4k5L6m7N8o9P0q1R2s", null, null, 3 },
                    { 13, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user13.role3@example.com", "User 13 (Role 3)", true, 13, "30101010000013", "$2a$11$tU0vW1x2Y3z4A5b6c7D8e9F0g1H2i3J4k5L6m7N8o9P0q1R2s3T4u", null, null, 3 },
                    { 14, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user14.role3@example.com", "User 14 (Role 3)", true, 14, "30101010000014", "$2a$11$vW2xY3z4A5b6c7D8e9F0g1H2i3J4k5L6m7N8o9P0q1R2s3T4u5V6w", null, null, 3 },
                    { 15, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user15.role3@example.com", "User 15 (Role 3)", true, 15, "30101010000015", "$2a$11$xY4zA5b6c7D8e9F0g1H2i3J4k5L6m7N8o9P0q1R2s3T4u5V6w7X8y", null, null, 3 },
                    { 16, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user16.role4@example.com", "User 16 (Role 4)", true, 16, "30101010000016", "$2a$11$zA6bC7d8E9f0G1h2I3j4K5l6M7n8O9p0Q1r2S3t4U5v6W7x8Y9z0a", null, null, 4 },
                    { 17, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user17.role4@example.com", "User 17 (Role 4)", true, 17, "30101010000017", "$2a$11$bC8dE9f0G1h2I3j4K5l6M7n8O9p0Q1r2S3t4U5v6W7x8Y9z0a1B2c", null, null, 4 },
                    { 18, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user18.role4@example.com", "User 18 (Role 4)", true, 18, "30101010000018", "$2a$11$dE0fG1h2I3j4K5l6M7n8O9p0Q1r2S3t4U5v6W7x8Y9z0a1B2c3D4e", null, null, 4 },
                    { 19, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user19.role4@example.com", "User 19 (Role 4)", true, 19, "30101010000019", "$2a$11$fG2hI3j4K5l6M7n8O9p0Q1r2S3t4U5v6W7x8Y9z0a1B2c3D4e5F6g", null, null, 4 },
                    { 20, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user20.role4@example.com", "User 20 (Role 4)", true, 20, "30101010000020", "$2a$11$hI4jK5l6M7n8O9p0Q1r2S3t4U5v6W7x8Y9z0a1B2c3D4e5F6g7H8i", null, null, 4 },
                    { 21, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user21.role5@example.com", "User 21 (Role 5)", true, 21, "30101010000021", "$2a$11$jK6lM7n8O9p0Q1r2S3t4U5v6W7x8Y9z0a1B2c3D4e5F6g7H8i9J0k", null, null, 5 },
                    { 22, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user22.role5@example.com", "User 22 (Role 5)", true, 22, "30101010000022", "$2a$11$lM8nO9p0Q1r2S3t4U5v6W7x8Y9z0a1B2c3D4e5F6g7H8i9J0k1L2m", null, null, 5 },
                    { 23, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user23.role5@example.com", "User 23 (Role 5)", true, 23, "30101010000023", "$2a$11$nO0pQ1r2S3t4U5v6W7x8Y9z0a1B2c3D4e5F6g7H8i9J0k1L2m3N4o", null, null, 5 },
                    { 24, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user24.role5@example.com", "User 24 (Role 5)", true, 24, "30101010000024", "$2a$11$pQ2rS3t4U5v6W7x8Y9z0a1B2c3D4e5F6g7H8i9J0k1L2m3N4o5P6q", null, null, 5 },
                    { 25, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user25.role5@example.com", "User 25 (Role 5)", true, 25, "30101010000025", "$2a$11$rS4tU5v6W7x8Y9z0a1B2c3D4e5F6g7H8i9J0k1L2m3N4o5P6q7R8s", null, null, 5 },
                    { 26, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user26.role6@example.com", "User 26 (Role 6)", true, 26, "30101010000026", "$2a$11$tU6vW7x8Y9z0a1B2c3D4e5F6g7H8i9J0k1L2m3N4o5P6q7R8s9T0u", null, null, 6 },
                    { 27, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user27.role6@example.com", "User 27 (Role 6)", true, 27, "30101010000027", "$2a$11$vW8xY9z0a1B2c3D4e5F6g7H8i9J0k1L2m3N4o5P6q7R8s9T0u1V2w", null, null, 6 },
                    { 28, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user28.role6@example.com", "User 28 (Role 6)", true, 28, "30101010000028", "$2a$11$xY0zA1b2C3d4E5f6G7h8I9j0K1l2M3n4O5p6Q7r8S9t0U1v2W3x4y", null, null, 6 },
                    { 29, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user29.role6@example.com", "User 29 (Role 6)", true, 29, "30101010000029", "$2a$11$zA2bC3d4E5f6G7h8I9j0K1l2M3n4O5p6Q7r8S9t0U1v2W3x4y5Z6a", null, null, 6 },
                    { 30, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user30.role6@example.com", "User 30 (Role 6)", true, 30, "30101010000030", "$2a$11$bC4dE5f6G7h8I9j0K1l2M3n4O5p6Q7r8S9t0U1v2W3x4y5Z6a7B8c", null, null, 6 },
                    { 31, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user31.role7@example.com", "User 31 (Role 7)", true, 31, "30101010000031", "$2a$11$dE6fG7h8I9j0K1l2M3n4O5p6Q7r8S9t0U1v2W3x4y5Z6a7B8c9D0e", null, null, 7 },
                    { 32, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user32.role7@example.com", "User 32 (Role 7)", true, 32, "30101010000032", "$2a$11$fG8hI9j0K1l2M3n4O5p6Q7r8S9t0U1v2W3x4y5Z6a7B8c9D0e1F2g", null, null, 7 },
                    { 33, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user33.role7@example.com", "User 33 (Role 7)", true, 33, "30101010000033", "$2a$11$hI0jK1l2M3n4O5p6Q7r8S9t0U1v2W3x4y5Z6a7B8c9D0e1F2g3H4i", null, null, 7 },
                    { 34, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user34.role7@example.com", "User 34 (Role 7)", true, 34, "30101010000034", "$2a$11$jK2lM3n4O5p6Q7r8S9t0U1v2W3x4y5Z6a7B8c9D0e1F2g3H4i5J6k", null, null, 7 },
                    { 35, new DateTime(2025, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "user35.role7@example.com", "User 35 (Role 7)", true, 35, "30101010000035", "$2a$11$lM4nO5p6Q7r8S9t0U1v2W3x4y5Z6a7B8c9D0e1F2g3H4i5J6k7L8m", null, null, 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FullName", "NationalID" },
                values: new object[] { "sara.mohamed.123456@example.com", "Sara Mohamed", "30101011234567" });

            migrationBuilder.UpdateData(
                table: "LoginAccounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "NationalID" },
                values: new object[] { "sara.mohamed.123456@example.com", "30101011234567" });
        }
    }
}
