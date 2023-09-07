using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.API.Models
{
    public class EmployeeAttendance
    {
        [Key]
        public int employeeAttendanceId { get; set; }


        [Required]
        public DateTime attendanceDate { get; set; }

        [Required]
        public int employeeId { get; set; }

        [Required]
        public bool isPresent { get; set; }

        [Required]
        public bool isAbsent { get; set; }

        [Required]
        public bool isOffday { get; set; }


       
    }
}
