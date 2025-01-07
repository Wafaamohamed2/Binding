using Binding.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_1.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Instructor_Name { get; set; }

        public string  Courses { get; set; }

        [Column("dept_Id")]
        public int? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

    }
}