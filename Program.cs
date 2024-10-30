using Microsoft.EntityFrameworkCore;
using UserInfoApp.Model.Context;

namespace UserInfoApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           
            string connection = builder.Configuration.GetConnectionString("DefaultConnection");
         
            builder.Services.AddDbContext<MainContext>(options => options.UseSqlServer(connection));

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}