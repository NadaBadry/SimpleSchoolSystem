using System.ComponentModel.DataAnnotations;

namespace SimpleSchoolSystem.ServicesLayer.Dto.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your password")]

        public string Password { get; set; }
        [Display(Name = "Remmember Me")]
        public bool RemmemberMe { get; set; } = false;
        public string? ReturnUrl {  get; set; }
    }
}
