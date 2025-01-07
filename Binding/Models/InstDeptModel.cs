using System.ComponentModel.DataAnnotations.Schema;

namespace Binding.Models
{
    public class InstDeptModel
    {
        public int Id { get; set; }
        public string Instructor_Name { get; set; }

        public string Courses { get; set; }

        [Column("dept_Id")]
        public int? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }


     

        public List<Department> DeptList { get; set; }
    }
}
