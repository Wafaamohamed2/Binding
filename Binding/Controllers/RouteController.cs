using Microsoft.AspNetCore.Mvc;
using Binding.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Binding.Controllers
{
    public class RouteController : Controller
    {
        //Default route
        //Route/Method1?name=Ali


        //naming route  

        //R1/Ali/12  ... R1 called littral and name called place holder
        
        [Route("R1/{name}/{age}")]  // route attribute
        public IActionResult Method1()/*string name ,int age*/
        {
            return Content("M1");
        }

        //R2
        public IActionResult Method2()
        {
            return Content("M2");
        }
    }
}
