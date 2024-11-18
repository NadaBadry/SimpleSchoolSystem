namespace SimpleSchoolSystem.ServicesLayer.Dto.User
{
    public class ManageRoleInUserViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }=false;
    }
}
