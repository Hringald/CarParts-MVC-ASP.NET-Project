namespace Car_Parts.Services.Admins
{
    using Car_Parts.Data;
    using Car_Parts.Data.Models;
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

        public bool IsAdmin(string userId)
             => this.data.Admins
                .Any(d => d.UserId == userId);
    }
}
