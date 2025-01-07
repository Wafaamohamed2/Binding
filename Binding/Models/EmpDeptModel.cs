namespace Binding.Models
{

    // model for employee and department to make department list in edit view as drop down list
    public class EmpDeptModel
    {
        

            public int Id { get; set; }

        
            public string Name { get; set; }
            public int Salary { get; set; }

            public string? Address { get; set; }

            public string Image { get; set; }


            public int Dept_Id { get; set; }


            public virtual Department? Department { get; set; }

            public List<Department> DeptList { get; set; }
        
    }
}
