// SimpleCustomCalculator/Program.cs
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SimpleCustomCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Check for external appsettings
            var externalAppSettingsPath = Environment.GetEnvironmentVariable("APPSETTINGS_PATH");
            if (!string.IsNullOrEmpty(externalAppSettingsPath) && File.Exists(externalAppSettingsPath))
            {
                builder.Configuration.AddJsonFile(externalAppSettingsPath, optional: false, reloadOnChange: true);
            }

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Calculator}/{action=Index}/{id?}");

            // Configure the port
            var port = app.Configuration.GetValue<int>("Deployment:Port");
            app.Run($"http://*:{port}");
        }
    }
}
