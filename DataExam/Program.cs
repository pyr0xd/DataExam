using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ConsoleApp1.Entities;
using System.Threading.Tasks;

namespace CandyStoreConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            // Assuming you have logic to initialize the database or perform startup tasks
            // await InitializeDatabaseAsync(host.Services);
            // For demonstration purposes, directly running an example method
            await RunApplicationAsync(host);
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddDbContext<CandyStoreContext>(options =>
                        options.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\School02\DataExam\DataExam\Data\CandyDataBase.mdf;Integrated Security=True;Connect Timeout=30"));

                    // Assuming Repo<> is correctly implemented to accept a DbContext
                    services.AddScoped(typeof(IRepo<>), typeof(Repo<>));

                    // Correctly register your services with dependency injection
                    services.AddScoped<ProductService>();
                    services.AddScoped<CategoryService>();
                    // Assuming CartService and CartUI are also correctly implemented
                    services.AddScoped<CartService>();
                    services.AddScoped<CartUI>();
                    services.AddScoped<ProductUI>();
                    services.AddScoped<CategoryUI>();
                });

        static async Task RunApplicationAsync(IHost host)
        {
            // Resolve services from the DI container
            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            var productService = services.GetRequiredService<ProductService>();
            var categoryUI = services.GetRequiredService<CategoryUI>();
            var productUI = services.GetRequiredService<ProductUI>();
            var cartUI = services.GetRequiredService<CartUI>();

            // Your main menu or other startup logic here
            DisplayMainMenu(productUI, categoryUI, cartUI);
        }

        private static void DisplayMainMenu(ProductUI productUI, CategoryUI categoryUI, CartUI cartUI)
        {
            bool exit = false;
            while (!exit)
            {
                System.Console.WriteLine("Main Menu");
                System.Console.WriteLine("1. Product Management");
                System.Console.WriteLine("2. Category Management");
                System.Console.WriteLine("3. Cart Management");
                System.Console.WriteLine("4. Exit");

                var choice = System.Console.ReadLine();
                System.Console.Clear();

                switch (choice)
                {
                    case "1":
                        productUI.DisplayProductManagementMenu();
                        break;
                    case "2":
                        categoryUI.DisplayCategoryManagementMenu();
                        break;
                    case "3":
                        cartUI.DisplayCartManagementMenu();
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        System.Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}
