namespace SimpleSchoolSystem.ServicesLayer.Dto.Identity
{
    public class ManageUserInRoleModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }=false;
    }
}
