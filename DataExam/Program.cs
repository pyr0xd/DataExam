
using ConsoleApp1.Entities;
using System;
using System.Data;
using System.Diagnostics;


namespace CandyStoreConsoleApp
{

    class Program
    {
        static void Main(string[] args)
        {
            using var context = new CandyStoreContext();
            var productRepository = new Repo<ProductEntity>(context);
            var categoryRepository = new Repo<CategoryEntity>(context);


            var productService = new ProductService(productRepository, categoryRepository);
            var categoryService = new CategoryService(categoryRepository);

            InitializeDatabase();

            while (true)
            {
                ConsoleUI.DisplayMainMenu();
                var option = Console.ReadLine();
                Console.Clear();

                switch (option)
                {
                    case "1":
                        productService.AddProduct();
                        break;
                    case "2":
                        productService.ViewProduct();
                        break;
                    case "3":
                        productService.UpdateProduct();
                        break;
                    case "4":
                        productService.DeleteProduct();
                        break;
                    case "5":
                        productService.ViewAllProducts();
                        break;
                    case "6":
                        categoryService.CreateCategory();
                        break;
                    case "7":
                        return;
                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
        }

        static void InitializeDatabase()
        {

        }
    }


}