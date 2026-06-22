using GymMangement.DAL.Context;
using GymMangement.DAL.Repositories.Classes;
using GymMangment.DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GEAM_CORE.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped <IPlanRepository, PlanRepository>();
            builder.Services.AddDbContext<GymDbContexts>(Options => { Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });
       
        var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }

        private static int PlanRepository()
        {
            throw new NotImplementedException();
        }
    }
}
