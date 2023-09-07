using EmployeeManager.API.Models;
using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeAttendance> EmployeeAttendances { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>().HasData(

     new Employee
      {
         employeeId = 502030,
         employeeName = "Mehedi Hasan",
         employeeCode = "EMP320",
         employeeSalary = 50000,
         supervisorId = 502036
            },
    new Employee
    {
        employeeId = 502031,
        employeeName = "Ashikur Rahman",
        employeeCode = "EMP321",
        employeeSalary = 45000,
        supervisorId = 502036
    },
    new Employee
    {
        employeeId = 502032,
        employeeName = "Rakibul Islam",
        employeeCode = "EMP322",
        employeeSalary = 52000,
        supervisorId = 502030
    },
    new Employee
    {
        employeeId = 502033,
        employeeName = "Hasan Abdullah",
        employeeCode = "EMP323",
        employeeSalary = 46000,
        supervisorId = 502031
    },
    new Employee
    {
        employeeId = 502034,
        employeeName = "Akib Khan",
        employeeCode = "EMP324",
        employeeSalary = 66000,
        supervisorId = 502032
    },
    new Employee
    {
        employeeId = 502035,
        employeeName = "Rasel Shikder",
        employeeCode = "EMP325",
        employeeSalary = 53500,
        supervisorId = 502033
    },
    new Employee
    {
        employeeId = 502036,
        employeeName = "Selim Reja",
        employeeCode = "EMP326",
        employeeSalary = 59000,
        supervisorId = 502035
    }

            );


        modelBuilder.Entity<EmployeeAttendance>().HasData(
            
            new EmployeeAttendance
            {
                employeeAttendanceId = 1,
                employeeId = 502030,
                attendanceDate = new DateTime(2023,06,24),
                isPresent = true,
                isAbsent = false,
                isOffday = false,
            },

            new EmployeeAttendance
            {
                employeeAttendanceId = 2,
                employeeId = 502030,
                attendanceDate = new DateTime(2023, 06, 24),
                isPresent = false,
                isAbsent = true,
                isOffday = false
            },
            new EmployeeAttendance
            {
               employeeAttendanceId = 3,
               employeeId = 502031,
               attendanceDate = new DateTime(2023, 06, 25),
               isPresent = true,
               isAbsent = false,
               isOffday = false
    }


            );

    }


    
}
