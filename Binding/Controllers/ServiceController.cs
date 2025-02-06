using Binding.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Binding.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IDepartmentRepository deptRepo;

        public ServiceController(IDepartmentRepository deptRepo )
        {
            this.deptRepo = deptRepo;
        }
        public IActionResult Index()// [FromServices]IDepartmentRepository deptrepo)
        {
            ViewBag.Id = deptRepo.Id;
            return View("Index");
        }
    }
}
