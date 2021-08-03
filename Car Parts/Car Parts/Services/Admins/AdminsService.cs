namespace Car_Parts.Services.Admins
{
    using Car_Parts.Areas.Admins.Models;
    using Car_Parts.Data;
    using Car_Parts.Data.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class AdminsService : IAdminsService
    {
        private readonly CarPartsDbContext data;
        public AdminsService(CarPartsDbContext data)
        {
            this.data = data;
        }

        public void AddAdmin(string adminName, string userId)
        {
            var adminData = new Admin
            {
                Name = adminName,
                UserId = userId
            };

            this.data.Admins.Add(adminData);
            this.data.SaveChanges();
        }

        public string GetAdminId(string userId)
            => this.data.Admins
                .Where(a => a.UserId == userId)
                .Select(d => d.Id)
                .FirstOrDefault();

        public ApplicationUser GetUserById(string userId)
        => this.data
               .Users
               .FirstOrDefault(u => u.Id == userId);

        public ICollection<UsersPartsViewModel> GetUsersInfo()
            => this.data
                .Users
                .Where(u => !this.data.Admins.Any(a => a.UserId == u.Id))
                .Select(u => new UsersPartsViewModel
                {
                    UserId = u.Id,
                    PartsCount = u.Parts.Count(),
                    UserName = u.UserName
                })
                .OrderByDescending(u => u.UserName)
                .ToList();

    public bool IsAdmin(string userId)
             => this.data.Admins
                .Any(d => d.UserId == userId);
    }
}
