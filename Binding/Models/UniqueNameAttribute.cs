using MVC_1.Models;
using System.ComponentModel.DataAnnotations;

namespace Binding.Models
{
    // Custom Validator affect server side
    public class UniqueNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string Newname = value.ToString();
                FristEntity context = new FristEntity();
                Employee emp = context.Employees.FirstOrDefault(s=>s.Name == Newname);
                if (emp != null)
                {
                    return new ValidationResult("Name Must Be Unique");
                }
            }
            return ValidationResult.Success;
        }
    }
}
