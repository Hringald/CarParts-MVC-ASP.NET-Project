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
                new Category {Name ="Main Parts",ImageUrl="https://www.moogparts.com/content/loc-na/loc-us/fmmp-moog/en_US/parts-matter/parts-of-a-car/_jcr_content/article/article-par/image.img.jpg/car-parts-diagram-front-with-callouts-1613147443990.jpg"},
                 new Category {Name ="Electronics",ImageUrl="http://www.aecouncil.com/vehicle.jpg"},
                  new Category {Name ="Interior",ImageUrl="http://carpartsfellas.wwwsrc2.supercp.com/wp-content/uploads/2015/05/interior-car-parts-page.jpg"},
                   new Category {Name ="Power-train and chassis",ImageUrl="https://wieck-honda-production.s3.amazonaws.com/photos/acef12836806c9b71e7bd0803100bff7dfd3e2c7/preview-928x522.jpg"},
                    new Category {Name ="Miscellaneous",ImageUrl="https://d2414e50-a-62cb3a1a-s-sites.googlegroups.com/site/usedoldcarparts/home/products/High-Performance-Car-Parts.jpg?attachauth=ANoY7co1hvbQrLSXQyktLSU6dBPgY3mFvjZFxwJEVi6xjMuZNpepckTXZ6RtMg4O3vAPRwTRp6NN8cNJXYkqfOQQYL7iU7FVwWYoHy-JZ6pZiyKpNF_k7maHqUbT3RssrwPajWosu_UBHUlm6UD44XqqHHGp7AzSlWVDI_gmwNz-XkUbm2PXtJtqS34CcYO4sNbNBB9rtkxfl3n2C8GiB5hr1WjDbLxe60t2753DFycxvSDsJ3_bDjGvFEAZ49KPd0rDwZbxsGDG&attredirects=0"}
            });

            data.SaveChanges();
        }

    }
}