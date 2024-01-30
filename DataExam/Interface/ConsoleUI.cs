using System;

public class ConsoleUI
{
    public static void DisplayMainMenu()
    {
        Console.WriteLine("Candy Store");
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. View Product");
        Console.WriteLine("3. Update Product");
        Console.WriteLine("4. Delete Product");
        Console.WriteLine("5. View All Products");
        Console.WriteLine("6. Create Category");
        Console.WriteLine("7. Exit");
    }

    public static void HandleUserInput(ProductService productService, CategoryService categoryService)
    {
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
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option, try again.");
                break;
        }
    }
}
