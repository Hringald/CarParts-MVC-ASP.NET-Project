using Car_Parts.Data.Models;
using Car_Parts.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Car_Parts.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var data = scopedServices.ServiceProvider.GetService<CarPartsDbContext>();

            data.Database.Migrate();
            SeedCategories(data);

            return app;
        }

        private static void SeedCategories(CarPartsDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category {Name ="Main Parts",ImageUrl="~/Images/Car/CarPartsCategories/MainCarParts.jpg"},
                 new Category {Name ="Electronics",ImageUrl="~/Images/Car/CarPartsCategories/CarElectronics.jpg"},
                  new Category {Name ="Interior",ImageUrl="~/Images/Car/CarPartsCategories/CarInterior.jpg"},
                   new Category {Name ="Power-train and chassis",ImageUrl="~/Images/Car/CarPartsCategories/powerTrainAndChassis.jpg"},
                    new Category {Name ="Miscellaneous",ImageUrl="~/Images/Car/CarPartsCategories/Miscellaneous.jpg"}
            });

            data.SaveChanges();
        }

    }
}