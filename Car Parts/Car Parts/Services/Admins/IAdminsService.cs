namespace Car_Parts.Services.Admins
{
    public interface IAdminsService
    {
        public bool IsAdmin(string userId);
        public void AddAdmin(string adminName, string userId);
        public string GetAdminId(string userId);
    }
}
