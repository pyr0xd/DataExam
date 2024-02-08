
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
            CustomerService customerService =new CustomerService(new Repo<CustomerEntity>());
            CustomerUI customerUI = new CustomerUI(customerService);
            ProductService productService = new ProductService();
            CategoryUI categoryUI = new CategoryUI();
            CartService cartService = new CartService(new Repo<CartEntity>()); // Create an instance of CartService
            CartUI cartUI = new CartUI(cartService); // Pass cartService to the constructor

            ProductUI productUI = new ProductUI(productService, categoryUI);

            DisplayMainMenu(productUI, categoryUI, cartUI, customerUI );
        }

        private static void DisplayMainMenu(ProductUI productUI, CategoryUI categoryUI ,CartUI cartUI, CustomerUI customerUI)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Product Management");
                Console.WriteLine("2. Category Management"); // Assuming you have similar functionality for categories
                Console.WriteLine("3. Cart Managment");
                Console.WriteLine("4. Customer Managment");
                Console.WriteLine("5. Exit");


                var choice = Console.ReadLine();
                Console.Clear();

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
                        customerUI.DisplayCustomerManagementMenu();
                        break; 
                    case "5":
                        exit = true;
                        break;
                    
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }


        static void InitializeDatabase()
        {

        }
    }
}

