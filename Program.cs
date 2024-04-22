using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CIT_195_RazorPagesMovie.Data;
using CIT_195_RazorPagesMovie.Models;
namespace CIT_195_RazorPagesMovie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CIT_195_RazorPagesMovieContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("CIT_195_RazorPagesMovieContext") ?? throw new InvalidOperationException("Connection string 'CIT_195_RazorPagesMovieContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                SeedData.Initialize(services);
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
