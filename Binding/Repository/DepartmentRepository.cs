using Binding.Models;
using MVC_1.Models;

namespace Binding.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
      private readonly  FristEntity _context ;

      public string Id { get; set; }
        public DepartmentRepository(FristEntity context)
        {
            _context = context; 
            Id = Guid.NewGuid().ToString();  // unique id
        }


        //CRUD

        public void Create(Department dept)
        {
            _context.departments.Add(dept);
           
        }
        public void Update(Department dept)
        {
            _context.departments.Update(dept);
        }
        public void Delete(Department dept)
        {
            _context.departments.Remove(dept);
        }
        public List<Department> GetAll()
        {
            return _context.departments.ToList();
        }
        public Department GetById(int id)
        {
            return _context.departments.FirstOrDefault(d => d.Id == id);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
