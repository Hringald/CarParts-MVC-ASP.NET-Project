namespace CarParts.Data
{
    using CarParts.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class CarPartsDbContext : IdentityDbContext<ApplicationUser>
    {
        public CarPartsDbContext(DbContextOptions<CarPartsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
