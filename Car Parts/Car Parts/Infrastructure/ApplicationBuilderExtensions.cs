namespace Car_Parts.Infrastructure
{
    using Car_Parts.Data.Models;
    using Car_Parts.Data;
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
                new Category {Name ="Main Parts",ImageUrl="https://sites.google.com/site/gearsexhausts/_/rsrc/1472776806685/car-parts/car-parts.jpeg"},
                 new Category {Name ="Electronics",ImageUrl="http://www.aecouncil.com/vehicle.jpg"},
                  new Category {Name ="Interior",ImageUrl="http://carpartsfellas.wwwsrc2.supercp.com/wp-content/uploads/2015/05/interior-car-parts-page.jpg"},
                   new Category {Name ="Power-train and chassis",ImageUrl="https://wieck-honda-production.s3.amazonaws.com/photos/acef12836806c9b71e7bd0803100bff7dfd3e2c7/preview-928x522.jpg"},
                    new Category {Name ="Miscellaneous",ImageUrl="https://www.gundies.com/wp-content/uploads/2017/10/misc-auto-parts-300x225.jpg"}
            });

            data.SaveChanges();
        }

    }
}