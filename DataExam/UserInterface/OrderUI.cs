using ConsoleApp1.Entities;

public class OrderUI
{
    private OrderService _orderService;

    public OrderUI(OrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task DisplayOrderManagementMenuAsync()
    {
        Console.WriteLine("Order Management");
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Add Order");
        Console.WriteLine("2. View Order");
        Console.WriteLine("3. Update Order");
        Console.WriteLine("4. Delete Order");
        Console.WriteLine("5. View All Orders");
        Console.WriteLine("6. Return to Main Menu");

        var option = Console.ReadLine();
        Console.Clear();

        switch (option)
        {
            case "1":
                AddOrderUIAsync();
                break;
            case "2":
                ViewOrderUIAsync();
                break;
            case "3":
                UpdateOrderUIAsync();
                break;
            case "4":
                DeleteOrderUIAsync();
                break;
            case "5":
                ViewAllOrdersUIAsync();
                break;
            case "6":
              
                break;
            default:
                Console.WriteLine("Invalid option, try again.");
                DisplayOrderManagementMenuAsync();
                break;
        }
    }

    public async Task AddOrderUIAsync()
    {
        Console.WriteLine("Enter Customer Name:");
        int customerId = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Total Amount:");
        decimal totalAmount = decimal.Parse(Console.ReadLine());

        // Assuming Product Name is part of the OrderEntity or related logic
        Console.WriteLine("Enter Product Name:");
        var productName = Console.ReadLine();

        var orderDate = DateTime.Now; // Assuming order date is always the current date for simplicity

        var order = new OrderEntity
        {
            CustomerId = customerId,
            Date = DateTime.Now,
            TotalAmount = totalAmount,
            Status = OrderStatus.Pending
        };
        await _orderService.CreateOrderAsync(order);
        Console.WriteLine("Order added successfully.");

    }


    public async Task ViewOrderUIAsync()
    {
        Console.WriteLine("Enter Order ID to view:");
        int orderId = int.Parse(Console.ReadLine());

        var order = await _orderService.GetOrderByIdAsync(orderId);
        if (order != null)
        {
            Console.WriteLine($"Order ID: {order.OrderId}, Customer ID: {order.CustomerId}, Date: {order.Date}, Total Amount: {order.TotalAmount}, Status: {order.Status}");
        }
        else
        {
            Console.WriteLine("Order not found.");
        }
    }

    public async Task UpdateOrderUIAsync()
    {
        Console.WriteLine("Enter Order ID to update:");
        int orderId = int.Parse(Console.ReadLine());

        var order = await _orderService.GetOrderByIdAsync(orderId);
        if (order == null)
        {
            Console.WriteLine("Order not found.");
            return;
        }

        Console.WriteLine("Enter new Total Amount (leave blank to keep current):");
        var totalAmountInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(totalAmountInput))
        {
            order.TotalAmount = decimal.Parse(totalAmountInput);
        }

        Console.WriteLine("Select new Status (Pending, Processing, Shipped, Delivered, Cancelled):");
        var statusInput = Console.ReadLine();
        if (Enum.TryParse(statusInput, out OrderStatus newStatus))
        {
            order.Status = newStatus;
        }

        await _orderService.UpdateOrderAsync(order);
        Console.WriteLine("Order updated successfully.");
    }

    public async Task DeleteOrderUIAsync()
    {
        Console.WriteLine("Enter Order ID to delete:");
        int orderId = int.Parse(Console.ReadLine());

        await _orderService.DeleteOrderAsync(orderId);
        Console.WriteLine("Order deleted successfully.");
    }

    public async Task ViewAllOrdersUIAsync()
    {
        var orders = await _orderService.GetAllOrdersAsync();
        if (orders.Any())
        {
            foreach (var order in orders)
            {
                Console.WriteLine($"Order ID: {order.OrderId}, Customer ID: {order.CustomerId}, Date: {order.Date.ToShortDateString()}, Total Amount: {order.TotalAmount}, Status: {order.Status}");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("No orders found.");
        }
    }
}
