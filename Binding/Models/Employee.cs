using Binding.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]

        [UniqueName]
        // Custom validation client side
      [Remote(action:"checkName" ,controller: "EmployeeController1", ErrorMessage ="Nmae must contain Eg")]
        public string Name { get; set; }
        [Range(1000, 100000 ,ErrorMessage ="Must be between 1000 , 10000") ] // 1000 is min and 100000 is max
        public int Salary { get; set; }

        public string? Address {  get; set; }

        [Required]
        public string Image { get; set; }

        [ForeignKey("Department")]
        [Display(Name = "Department")]
        [Required(ErrorMessage = "Department is required")]
        public int Dept_Id { get; set; }

        // virtual to make refrence of last one not new object
        public virtual Department? Department { get; set; }
    }
}
