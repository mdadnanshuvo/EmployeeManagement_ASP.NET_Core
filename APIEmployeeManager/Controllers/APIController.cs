using EmployeeManager.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManager.API.Controllers
{



    public class APIController : Controller
    {
        private readonly MyDbContext _context;

        public APIController(MyDbContext db)
        {
            _context = db;
        }



        [HttpGet]
        public IActionResult Hierarchy(int id)
        {
            var hierarchy = new List<string>();

            var employee = _context.Employees.FirstOrDefault(e => e.employeeId == id);

            int totalEmployees = _context.Employees.Count();

            for (int i = 0; i < totalEmployees; i++)
            {
                if (hierarchy.Contains(employee.employeeName))
                {
                    break;
                }
                hierarchy.Add(employee.employeeName);

                employee = _context.Employees.FirstOrDefault(x => x.employeeId == employee.supervisorId);
            }


            if (hierarchy.Count > 0)
            {
                var hierarchyString = string.Join(" -> ", hierarchy);
                return Ok(hierarchyString);
            }
            else
            {
                return NotFound("Insufficient Data to show Hierarch.");
            }
        }


        [HttpGet]
        public IActionResult AttendanceReport()
        {
            var attendanceReport = _context.Employees
                .Select(x => new
                {
                    EmployeeName = x.employeeName,
                    MonthName = DateTime.Now.ToString("MMMM"),

                    PayableSalary = x.employeeSalary,

                    TotalPresent = _context.EmployeeAttendances.Count(y => y.employeeId == x.employeeId && y.isPresent == true),

                    TotalAbsent = _context.EmployeeAttendances.Count(y => y.employeeId == x.employeeId && y.isPresent == false),


                    TotalOffday = _context.EmployeeAttendances.Count(y => y.employeeId == x.employeeId && y.isOffday == true)
                })


                .ToList();

            return Ok(attendanceReport);
        }





        [HttpGet]
        public IActionResult EmployeesWithNoAbsence()
        {
            var employeesWithoutAbsence = _context.Employees.Where(x => !_context.EmployeeAttendances
            .Any(y => y.employeeId == x.employeeId && y.isPresent == false))
            .OrderByDescending(e => e.employeeSalary)
            .ToList();


            return Ok(employeesWithoutAbsence);
        }




        [HttpGet]
        public IActionResult ThirdHighestSalary()
        {

            var salary = _context.Employees.OrderByDescending(x => x.employeeSalary).ToList();


            if (salary.Count >= 3)
            {
                var thirdHighest = salary[2];
                return Ok(thirdHighest);
            }
            else
            {
                return NotFound("Insufficient Data to show the third highest salary");
            }

        }




        [HttpPut]
        public IActionResult UpdateEmployee(int id, [FromBody] EmployeeUpdateModel updateData)
        {
            
            var existedEmployee = _context.Employees.FirstOrDefault(e => e.employeeId == id);

            if (existedEmployee == null)
            {
                return NotFound("Employee not found.");
            }

            
            if (_context.Employees.Any(e => e.employeeId != id && e.employeeCode == updateData.employeeCode))
            {
                return Conflict("Employee Code must be unique.");
            }

            if (ModelState.IsValid)
            {
                existedEmployee.employeeName = updateData.employeeName;
                existedEmployee.employeeCode = updateData.employeeCode;

            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Error updating employee.");
            }

            return Ok("Employee updated successfully.");
        }


    }
}

