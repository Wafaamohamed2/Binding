using Binding.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_1.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }

        public string? Address {  get; set; }

        public string Image { get; set; }

        [ForeignKey("Department")] 
        public int Dept_Id { get; set; }

        // virtual to make refrence of last one not new object
        public virtual Department? Department { get; set; }
    }
}
