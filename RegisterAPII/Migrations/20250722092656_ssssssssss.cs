using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RegisterAPII.Migrations
{
    /// <inheritdoc />
    public partial class ssssssssss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GradeId",
                table: "ClassRooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StudentProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DaysAbsent = table.Column<int>(type: "int", nullable: false),
                    GoodNotesJson = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "[]"),
                    BadNotesJson = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "[]"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClassId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentProfiles_ClassRooms_ClassId",
                        column: x => x.ClassId,
                        principalTable: "ClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Wheeler" },
                    { 2, "Senior" },
                    { 3, "Junior" }
                });

            migrationBuilder.InsertData(
                table: "ClassRooms",
                columns: new[] { "Id", "GradeId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Wheeler 1" },
                    { 2, 1, "Wheeler 2" },
                    { 3, 1, "Wheeler 3" },
                    { 4, 1, "Wheeler 4" },
                    { 5, 2, "Senior 1" },
                    { 6, 2, "Senior 2" },
                    { 7, 2, "Senior 3" },
                    { 8, 2, "Senior 4" },
                    { 9, 3, "Junior 1" },
                    { 10, 3, "Junior 2" },
                    { 11, 3, "Junior 3" },
                    { 12, 3, "Junior 4" }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "ClassId", "FromDate", "ToDate", "sessionNo" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 6, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 7, 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 8, 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 }
                });

            migrationBuilder.InsertData(
                table: "StudentProfiles",
                columns: new[] { "Id", "Age", "City", "ClassId", "Country", "CreatedAt", "DaysAbsent", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 0, null, 2, null, new DateTime(2025, 7, 22, 9, 26, 55, 768, DateTimeKind.Utc).AddTicks(5534), 0, null, "Student 1", null },
                    { 2, 0, null, 2, null, new DateTime(2025, 7, 22, 9, 26, 55, 768, DateTimeKind.Utc).AddTicks(5537), 0, null, "Student 2", null },
                    { 3, 0, null, 3, null, new DateTime(2025, 7, 22, 9, 26, 55, 768, DateTimeKind.Utc).AddTicks(5538), 0, null, "Student 3", null },
                    { 4, 0, null, 3, null, new DateTime(2025, 7, 22, 9, 26, 55, 768, DateTimeKind.Utc).AddTicks(5539), 0, null, "Student 4", null },
                    { 5, 0, null, 4, null, new DateTime(2025, 7, 22, 9, 26, 55, 768, DateTimeKind.Utc).AddTicks(5540), 0, null, "Student 5", null },
                    { 6, 0, null, 4, null, new DateTime(2025, 7, 22, 9, 26, 55, 768, DateTimeKind.Utc).AddTicks(5541), 0, null, "Student 6", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_ClassId",
                table: "Sessions",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_GradeId",
                table: "ClassRooms",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentProfiles_ClassId",
                table: "StudentProfiles",
                column: "ClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRooms_Grades_GradeId",
                table: "ClassRooms",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_ClassRooms_ClassId",
                table: "Sessions",
                column: "ClassId",
                principalTable: "ClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRooms_Grades_GradeId",
                table: "ClassRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_ClassRooms_ClassId",
                table: "Sessions");

            migrationBuilder.DropTable(
                name: "StudentProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_ClassId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_ClassRooms_GradeId",
                table: "ClassRooms");

            migrationBuilder.DeleteData(
                table: "ClassRooms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ClassRooms",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ClassRooms",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ClassRooms",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sessions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ClassRooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ClassRooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ClassRooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ClassRooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ClassRooms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ClassRooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ClassRooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ClassRooms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "ClassRooms");
        }
    }
}
