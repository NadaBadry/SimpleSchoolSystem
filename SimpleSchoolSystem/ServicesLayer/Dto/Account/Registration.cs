using System.ComponentModel.DataAnnotations;

namespace SimpleSchoolSystem.ServicesLayer.Dto.Account
{
    public class Registration
    {
        [Required]
        [EmailAddress]
        public string Email {  get; set; }
      //  [Required]

       public string UserName {  get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="The Password and ConfirmedPassword do not match")]
        public string ConfirmPassword {  get; set; }

    }
}
