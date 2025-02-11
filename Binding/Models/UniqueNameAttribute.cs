using MVC_1.Models;
using System.ComponentModel.DataAnnotations;

namespace Binding.Models
{
    // Custom Validator affect server side
    public class UniqueNameAttribute : ValidationAttribute
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public UniqueNameAttribute(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<FristEntity>();
                if (context.Employees.Any(s => s.Name == value.ToString()))
                {
                    return new ValidationResult("Name Must Be Unique");
                }
            }
            return ValidationResult.Success;
        }
    }

}
