using Microsoft.AspNetCore.Mvc;

namespace Binding.Controllers
{
    public class StateController : Controller
    {

        // store data in session per user 
        public IActionResult SetSession(string name)
        {
            HttpContext.Session.SetString("Name", "Ahmed");

            HttpContext.Session.SetInt32("Age", 25);
            return Content("Session is set Successfly");


        }
        public IActionResult GetSession() { 
        

            string name = HttpContext.Session.GetString("Name");
            int age = HttpContext.Session.GetInt32("Age").Value;
            return Content($"Name = {name} , Age = {age}");
        }

        // store data in cookie per user
        public IActionResult SetCookie()
        {  
            CookieOptions option   = new CookieOptions();
            option.Expires = System.DateTime.Now.AddDays(1);
            // session cookie
            Response.Cookies.Append("Name", "Ahmed");

            // presistent cookie
            Response.Cookies.Append("Age", "25" ,option );
            return Content("Cookie is set Successfly");

        }
        public IActionResult GetCookie(string name) {

          

          string Name = HttpContext.Request.Cookies["Name"];
            string age = HttpContext.Request.Cookies["Age"];
            return Content($"Name = {name} , Age = {age}");
        }


    }
}
