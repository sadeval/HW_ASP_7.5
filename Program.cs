namespace HW_ASP_7._5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
