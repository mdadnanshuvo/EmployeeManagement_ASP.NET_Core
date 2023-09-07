using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EmployeeManager.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeAttendances",
                columns: table => new
                {
                    employeeAttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    attendanceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    employeeId = table.Column<int>(type: "int", nullable: false),
                    isPresent = table.Column<bool>(type: "bit", nullable: false),
                    isAbsent = table.Column<bool>(type: "bit", nullable: false),
                    isOffday = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAttendances", x => x.employeeAttendanceId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    employeeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeSalary = table.Column<int>(type: "int", nullable: false),
                    supervisorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employeeId);
                });

            migrationBuilder.InsertData(
                table: "EmployeeAttendances",
                columns: new[] { "employeeAttendanceId", "attendanceDate", "employeeId", "isAbsent", "isOffday", "isPresent" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 2, new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 502030, false, false, true },
                    { 3, new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 502031, false, false, true }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "employeeId", "employeeCode", "employeeName", "employeeSalary", "supervisorId" },
                values: new object[,]
                {
                    { 502030, "EMP320", "Mehedi Hasan", 50000, 502036 },
                    { 502031, "EMP321", "Ashikur Rahman", 45000, 502036 },
                    { 502032, "EMP322", "Rakibul Islam", 52000, 502030 },
                    { 502033, "EMP323", "Hasan Abdullah", 46000, 502031 },
                    { 502034, "EMP324", "Akib Khan", 66000, 502032 },
                    { 502035, "EMP325", "Rasel Shikder", 53500, 502033 },
                    { 502036, "EMP326", "Selim Reja", 59000, 502035 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAttendances");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
