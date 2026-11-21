using MVC_01.CustomMiddleware;
using System.Runtime.ConstrainedExecution;

namespace MVC_01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //Add Services for API Application
            //builder.Services.AddControllers();

            //builder.Services.AddMvc();

            //builder.Services.AddMvcCore();

            //builder.Services.AddRazorPages();

            var app = builder.Build();
            app.UseMiddleware<RequestTimmingMiddlewarw>();
            //app.Use(async(conext , next) => 
            //{
            //    Console.WriteLine("Hello"); //Request
            //    next.Invoke(conext);
            //    Console.WriteLine("Bye"); //Response

            //});
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
            //app.UseAuthentication();
            app.MapStaticAssets();

            app.MapControllerRoute(
                name: "shop ",
                pattern: "shop/{id}",
                defaults: new
                {
                    controller = "Product",
                    action = "GetProductById",
                });
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id=int?}")
                .WithStaticAssets();
            

            app.Run();
        }
    }
}
