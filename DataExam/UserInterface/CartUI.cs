using System;

public class CartUI
{
    public void DisplayCartManagementMenu()
    {
        Console.WriteLine("Cart Management");
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Add Item to Cart");
        Console.WriteLine("2. Remove Item from Cart");
        Console.WriteLine("3. View Cart");
        Console.WriteLine("4. Clear Cart");
        Console.WriteLine("5. Return to Main Menu");

        var option = Console.ReadLine();
        Console.Clear();

        switch (option)
        {
            case "1":
                AddItemToCartUI();
                break;
            case "2":
                RemoveItemFromCartUI();
                break;
            case "3":
                ViewCartUI();
                break;
            case "4":
                ClearCartUI();
                break;
            case "5":
                // Code to return to main menu
                break;
            default:
                Console.WriteLine("Invalid option, try again.");
                DisplayCartManagementMenu();
                break;
        }
    }
    private CartService cartService;

    public CartUI(CartService service)
    {
        cartService = service;

    }

    

    private void AddItemToCartUI()
    {
        // Implement UI logic to add an item to the cart
    }

    private void RemoveItemFromCartUI()
    {
        // Implement UI logic to remove an item from the cart
    }

    private void ViewCartUI()
    {
        // Implement UI logic to view the cart
    }

    private void ClearCartUI()
    {
        // Implement UI logic to clear the cart
    }

    // Add other methods as needed
}
