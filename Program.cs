using Microsoft.EntityFrameworkCore;
using Session2.AppDbContext;
using Session2.Configurations;
using Session2.Repository;
using Session2.Services;

namespace Session2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            string con = builder.Configuration.GetConnectionString("LocalConnectionString");
            builder.Services.AddDbContext<UserDbContext>(p => p.UseSqlServer(con));
            builder.Services.AddAutoMapper(typeof(MapperConfig));            
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Users}/{action=Index}/{id?}");

            app.Run();
        }
    }
}