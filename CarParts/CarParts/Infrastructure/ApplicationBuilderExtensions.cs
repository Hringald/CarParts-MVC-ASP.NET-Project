namespace CarParts.Infrastructure
{
    using CarParts.Data.Models;
    using CarParts.Data;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
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
                new Category {Name ="Main Parts",ImageUrl="MainCarParts.jpg"},
                 new Category {Name ="Electronics",ImageUrl="CarElectronics.jpg"},
                  new Category {Name ="Interior",ImageUrl="CarInterior.jpg"},
                   new Category {Name ="Power-train and chassis",ImageUrl="powerTrainAndChassis.jpg"},
                    new Category {Name ="Miscellaneous",ImageUrl="Miscellaneous.jpg"}
            });

            data.SaveChanges();
        }

    }
}