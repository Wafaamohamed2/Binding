using Binding.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Binding.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signIn;

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signIn  /*IOC for cookies */)
        {
            this.userManager = userManager;
            this.signIn = signIn;
        }


        [HttpGet]
        public IActionResult Register()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveRegister(RegisterUserViewModel UserViewModel)
        {
            if (ModelState.IsValid) {

                //mapping
                ApplicationUser appuser = new ApplicationUser();

                appuser.Address = UserViewModel.Address;
                appuser.UserName = UserViewModel.UserName;
                appuser.PasswordHash = UserViewModel.Password;



                //save database
                // UserManager<ApplicationUser> manager = new UserManager<ApplicationUser>();
                IdentityResult result=  await userManager.CreateAsync(appuser ,UserViewModel.Password /* for hashing password*/);


                if (result.Succeeded)
                {
                    //Cookie 
                   await signIn.SignInAsync(appuser , false);

                    return RedirectToAction("Index", "Department");
                }
                foreach (var er in result.Errors) {

                    ModelState.AddModelError("", er.Description);
                }
                  
            }
            return View("Register" , UserViewModel);
        }



        public IActionResult LogIn()
        {
            // username  , password , persistant cookie (remember me)



            return View("LogIn");
        }

        [HttpPost]
        public async Task<IActionResult> SaveLogIn(LoginUserViewModel userViewModel , string returnUrl =null)
        {
            if (ModelState.IsValid)
            {
                //check found
                ApplicationUser appUser = await userManager.FindByNameAsync(userViewModel.UserName);


                if (appUser != null)
                {
                    //check password
                    bool isPasswordValid = await userManager.CheckPasswordAsync(appUser, userViewModel.Password);// for hashing password and check it 

                    if (isPasswordValid == true) {
                       //create cookie

                        await signIn.SignInAsync(appUser, userViewModel.RememberMe);

                        if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Department");
                        }
                    }
                    
                   

                }  
                ModelState.AddModelError("", "Invalid UserName or Password");
              
                

            }
            return View("LogIn", userViewModel);
        }

        public async Task<IActionResult> LogOut()
        {
           await  signIn.SignOutAsync();
            return View("LogIn");
        }
    }
}
