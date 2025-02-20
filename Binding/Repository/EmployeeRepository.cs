using Binding.Models;
using MVC_1.Models;

namespace Binding.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        FristEntity context;

        public EmployeeRepository(FristEntity context)
        {
            this.context = context;
        }

        //CRUD

        public void Create(Employee emp)
        {
            context.Employees.Add(emp);

        }
        public void Update(Employee emp)
        {
            context.Employees.Update(emp);
        }
        public void Delete(Employee emp)
        {
            context.Employees.Remove(emp);
        }
        public List<Employee> GetAll()
        {
            return context.Employees.ToList();
        }
        public Employee GetById(int id)
        {
            return context.Employees.FirstOrDefault(e => e.Id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        public List<Employee> GetEmpsByDeptId(int deptid)
        {
            return context.Employees.Where(e => e.Dept_Id == deptid).ToList();
        }
    }
}
