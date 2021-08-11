namespace CarParts.Services.Admins
{            
    using CarParts.Data.Models;
    using CarParts.Models.Admins;
    using System.Collections.Generic;
    public interface IAdminsService
    {
        public bool IsAdmin(string userId);
        public void AddAdmin(string adminName, string userId);
        public string GetAdminId(string userId);
        public ApplicationUser GetUserById(string userId);
        public ICollection<UsersPartsViewModel> GetUsersInfo();
    }
}
