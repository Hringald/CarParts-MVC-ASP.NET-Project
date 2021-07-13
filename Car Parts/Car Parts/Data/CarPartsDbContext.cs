﻿using Car_Parts.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Car_Parts.Data
{
    public class CarPartsDbContext : IdentityDbContext
    {
        public CarPartsDbContext(DbContextOptions<CarPartsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
