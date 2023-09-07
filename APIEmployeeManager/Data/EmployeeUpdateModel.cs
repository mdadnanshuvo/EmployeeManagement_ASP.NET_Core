using System.ComponentModel.DataAnnotations;

namespace EmployeeManager.API.Data
{
    public class EmployeeUpdateModel
    {
        [StringLength(50)]
         public string employeeName { get; set; }
         public string employeeCode { get; set; }
        

    }
}
