using Binding.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Binding.Controllers
{

    [Authorize(Roles="Admin")]  // only admin can access this controller
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
          this.roleManager = roleManager;

        }

        public IActionResult AddRole()
        {
            return View("AddRole");
        }
        [HttpPost]
        public async Task<IActionResult> SaveRole(RoleViewModel roleViewModel) {
        
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = roleViewModel.RoleName;
                IdentityResult resulst=   await roleManager.CreateAsync(role);
                if(resulst.Succeeded == true)
                {

                    ViewBag.Success = "Role Created Successfully";
                    return View("AddRole");
                }
                foreach(var er in resulst.Errors)
                {
                    ModelState.AddModelError("", er.Description);
                }
            }
            return View("AddRole" ,roleViewModel);
        }
    }
}
