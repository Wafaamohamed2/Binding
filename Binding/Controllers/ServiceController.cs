using Binding.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Binding.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IDepartmentRepository deptRepo;

        public IActionResult TestAutho()
        {

            if(User.Identity.IsAuthenticated)
            {

                // return cliems of user depend on the type of claim
             Claim IDClaim =  User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
                string id = IDClaim.Value;


               string name = User.Identity.Name;
                return Content("Welcome " + name + "ID = " + id);
            }
            return Content("Welcome Guest");
        }

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
