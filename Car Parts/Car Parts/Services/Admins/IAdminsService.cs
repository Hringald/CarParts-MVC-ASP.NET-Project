using Car_Parts.Areas.Admins.Models;
using Car_Parts.Data.Models;
using System.Collections.Generic;

namespace Car_Parts.Services.Admins
{
    public interface IAdminsService
    {
        public bool IsAdmin(string userId);
        public void AddAdmin(string adminName, string userId);
        public string GetAdminId(string userId);
        public ApplicationUser GetUserById(string userId);
        public ICollection<UsersPartsViewModel> GetUsersInfo();
    }
}
