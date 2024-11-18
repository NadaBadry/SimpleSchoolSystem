using System.ComponentModel.DataAnnotations;

namespace SimpleSchoolSystem.ServicesLayer.Dto.User
{
    public class updateUser
    {
        [Required]
        public string Id { get; set; }
        [Required]

        public string NameAr { get; set; }
        [Required]

        public string NameEn { get; set; }
        [Required]

        public string Address { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]
        public string userName { get; set; }


    }
}
