using MVC_1.Models;

namespace Binding.Repository
{
    public interface IEmployeeRepository
    {
        public void Create(Employee emp);


        public void Update(Employee emp);


        public void Delete(Employee emp);


        public List<Employee> GetAll();


        public Employee GetById(int id);


        public void Save();

        public List<Employee> GetEmpsByDeptId(int deptid);
        
    }
}
