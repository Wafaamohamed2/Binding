

namespace Binding.Repository
{
    public interface IDepartmentRepository
    {
        public string Id { get; set; }
        public void Create(Department dept);


        public void Update(Department dept);


        public void Delete(Department dept);


        public List<Department> GetAll();


        public Department GetById(int id);


        public void Save();
       
    }
}
