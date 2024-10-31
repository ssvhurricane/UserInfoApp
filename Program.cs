using Microsoft.EntityFrameworkCore;
using UserInfoApp.Middleware;
using UserInfoApp.Model.Context;
using UserInfoApp.Service;

namespace UserInfoApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           
            string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
         
            builder.Services.AddDbContext<MainContext>(options => options.UseSqlServer(connection));

            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton<ValidationService>();

            var app = builder.Build(); 
            
            app.UseMiddleware<ValidationMiddleware>();

            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}