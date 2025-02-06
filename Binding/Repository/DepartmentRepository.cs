using Binding.Models;
using MVC_1.Models;

namespace Binding.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        FristEntity context ;

      public string Id { get; set; }
        public DepartmentRepository()
        {
            context = new FristEntity();
            Id = Guid.NewGuid().ToString();  // unique id
        }


        //CRUD

        public void Create(Department dept)
        {
            context.departments.Add(dept);
           
        }
        public void Update(Department dept)
        {
            context.departments.Update(dept);
        }
        public void Delete(Department dept)
        {
            context.departments.Remove(dept);
        }
        public List<Department> GetAll()
        {
            return context.departments.ToList();
        }
        public Department GetById(int id)
        {
            return context.departments.FirstOrDefault(d => d.Id == id);
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
