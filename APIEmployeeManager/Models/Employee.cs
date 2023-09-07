using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.API.Models
{
    public class Employee
    {
        [Key]
        public int employeeId { get; set; }

        [Required]
        [StringLength(50)]
        public string employeeName { get; set; }

        [Required]
        [Unique]
        public string employeeCode { get; set; }

        [Required]
        [Range(3,10)]
        public int employeeSalary { get; set; }

        [Required]
        public int supervisorId { get; set; }
    }
}
