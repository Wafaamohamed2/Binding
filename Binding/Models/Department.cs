using MVC_1.Models;

namespace Binding.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }


        public virtual List<Employee>? Employees { get; set; }

    }
}
