public class ConsoleUI
{




    public static void DisplayMainMenu()
    {
        Console.WriteLine("Candy Store");
        Console.WriteLine("Choose a category:");
        Console.WriteLine("1. Product Management");
        Console.WriteLine("2. Order and OrderItems Management");
        Console.WriteLine("3. Customer Management");
        Console.WriteLine("4. Exit");
    }

    public static void HandleUserInput(ProductUI productUI, CategoryUI categoryUI, OrderUI orderUI, CustomerService customerService /* Add other services as needed */)
    {
        var option = Console.ReadLine();
        Console.Clear();

        switch (option)
        {
            case "1":
                productUI.DisplayProductManagementMenu();
                break;
            case "2":
                orderUI.DisplayOrderManagementMenu( );
                break;
            case "3":
               /* DisplayCustomerManagementMenu(customerService);*/
                break;
            case "4":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option, try again.");
                DisplayMainMenu();
                break;
        }
    }

    
    }

    

    



