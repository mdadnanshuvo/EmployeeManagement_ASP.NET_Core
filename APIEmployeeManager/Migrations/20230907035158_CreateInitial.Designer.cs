﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeManager.API.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20230907035158_CreateInitial")]
    partial class CreateInitial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeManager.API.Models.Employee", b =>
                {
                    b.Property<int>("employeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("employeeId"));

                    b.Property<string>("employeeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("employeeName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("employeeSalary")
                        .HasColumnType("int");

                    b.Property<int>("supervisorId")
                        .HasColumnType("int");

                    b.HasKey("employeeId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            employeeId = 502030,
                            employeeCode = "EMP320",
                            employeeName = "Mehedi Hasan",
                            employeeSalary = 50000,
                            supervisorId = 502036
                        },
                        new
                        {
                            employeeId = 502031,
                            employeeCode = "EMP321",
                            employeeName = "Ashikur Rahman",
                            employeeSalary = 45000,
                            supervisorId = 502036
                        },
                        new
                        {
                            employeeId = 502032,
                            employeeCode = "EMP322",
                            employeeName = "Rakibul Islam",
                            employeeSalary = 52000,
                            supervisorId = 502030
                        },
                        new
                        {
                            employeeId = 502033,
                            employeeCode = "EMP323",
                            employeeName = "Hasan Abdullah",
                            employeeSalary = 46000,
                            supervisorId = 502031
                        },
                        new
                        {
                            employeeId = 502034,
                            employeeCode = "EMP324",
                            employeeName = "Akib Khan",
                            employeeSalary = 66000,
                            supervisorId = 502032
                        },
                        new
                        {
                            employeeId = 502035,
                            employeeCode = "EMP325",
                            employeeName = "Rasel Shikder",
                            employeeSalary = 53500,
                            supervisorId = 502033
                        },
                        new
                        {
                            employeeId = 502036,
                            employeeCode = "EMP326",
                            employeeName = "Selim Reja",
                            employeeSalary = 59000,
                            supervisorId = 502035
                        });
                });

            modelBuilder.Entity("EmployeeManager.API.Models.EmployeeAttendance", b =>
                {
                    b.Property<int>("employeeAttendanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("employeeAttendanceId"));

                    b.Property<DateTime>("attendanceDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("employeeId")
                        .HasColumnType("int");

                    b.Property<bool>("isAbsent")
                        .HasColumnType("bit");

                    b.Property<bool>("isOffday")
                        .HasColumnType("bit");

                    b.Property<bool>("isPresent")
                        .HasColumnType("bit");

                    b.HasKey("employeeAttendanceId");

                    b.ToTable("EmployeeAttendances");

                    b.HasData(
                        new
                        {
                            employeeAttendanceId = 1,
                            attendanceDate = new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            employeeId = 502030,
                            isAbsent = false,
                            isOffday = false,
                            isPresent = true
                        },
                        new
                        {
                            employeeAttendanceId = 2,
                            attendanceDate = new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            employeeId = 502030,
                            isAbsent = false,
                            isOffday = false,
                            isPresent = true
                        },
                        new
                        {
                            employeeAttendanceId = 3,
                            attendanceDate = new DateTime(2023, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            employeeId = 502031,
                            isAbsent = false,
                            isOffday = false,
                            isPresent = true
                        });
                });
#pragma warning restore 612, 618
        }
    }
}