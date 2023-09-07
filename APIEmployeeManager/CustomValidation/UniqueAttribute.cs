using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class UniqueAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            var propertyName = validationContext.MemberName;
            var dbContext = (MyDbContext)validationContext.GetService(typeof(MyDbContext));

            
            if (dbContext.Employees.Any(x => x.employeeCode == value))
            {
                return new ValidationResult($"{propertyName} must be unique.");
            }
        }

        return ValidationResult.Success;
    }
}
