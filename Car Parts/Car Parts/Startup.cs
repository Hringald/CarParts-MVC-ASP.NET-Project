namespace Car_Parts
{
    using Car_Parts.Data;
    using Car_Parts.Data.Models;
    using Car_Parts.Infrastructure;
    using Car_Parts.Services.Admins;
    using Car_Parts.Services.Home;
    using Car_Parts.Services.Makes;
    using Car_Parts.Services.Models;
    using Car_Parts.Services.Offers;
    using Car_Parts.Services.Parts;
    using Car_Parts.Services.Shop;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CarPartsDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
             .AddEntityFrameworkStores<CarPartsDbContext>();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
            });

            services.AddTransient<IAdminsService, AdminsService>();
            services.AddTransient<IHomeService, HomeService>();
            services.AddTransient<IMakesService, MakesService>();
            services.AddTransient<IModelsService, ModelsService>();
            services.AddTransient<IOffersService, OffersService>();
            services.AddTransient<IPartsService, PartsService>();
            services.AddTransient<IShopService, ShopService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
