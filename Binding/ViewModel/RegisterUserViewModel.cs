using System.ComponentModel.DataAnnotations;

namespace Binding.ViewModel
{

   //which is used to register a user in view of the application (end user)
    public class RegisterUserViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
          public string UserName { get; set; }


        [DataType(DataType.Password)]
         public string Password { get; set; }


        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        public string Address { get; set; }
    }
}
