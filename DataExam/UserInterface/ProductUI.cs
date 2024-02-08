
public class ProductUI
{
    private ProductService _productService;
    private CategoryUI _categoryUI; // Assuming CategoryUI is another class you have for category-related operations

    public ProductUI(ProductService productService, CategoryUI categoryUI)
    {
        _productService = productService;
        _categoryUI = categoryUI;
    }

    public void DisplayProductManagementMenu()
    {
        Console.WriteLine("Product Management");
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Add Product");
        Console.WriteLine("2. View Product");
        Console.WriteLine("3. Update Product");
        Console.WriteLine("4. Delete Product");
        Console.WriteLine("5. View All Products");
        Console.WriteLine("6. Manage Categories");
        Console.WriteLine("7. Return to Main Menu");

        var option = Console.ReadLine();
        Console.Clear();

        switch (option)
        {
            case "1":
                AddProductUI();
                break;
            case "2":
                ViewProductUI();
                break;
            case "3":
                UpdateProductUI();
                break;
            case "4":
                DeleteProductUI();
                break;
            case "5":
                ViewAllProductsUI();
                break;
            case "6":
               // Assuming you have a similar method in CategoryUI
                break;
            case "7":
                // DisplayMainMenu(); // This needs to be implemented or called correctly if it exists elsewhere
                break;
            default:
                Console.WriteLine("Invalid option, try again.");
                DisplayProductManagementMenu();
                break;
        }
    }

    public void AddProductUI()
    {
        Console.WriteLine("Enter product name:");
        var name = Console.ReadLine();

        Console.WriteLine("Enter product description:");
        var description = Console.ReadLine();

        decimal price = 0;
        Console.WriteLine("Enter product price:");
        if (!decimal.TryParse(Console.ReadLine(), out price))
        {
            Console.WriteLine("Invalid price format.");
            return;
        }

        int quantity = 0;
        Console.WriteLine("Enter stock quantity:");
        if (!int.TryParse(Console.ReadLine(), out quantity))
        {
            Console.WriteLine("Invalid quantity format.");
            return;
        }

        Console.WriteLine("Enter Category Name:");
        var categoryName = Console.ReadLine();

        var categoryExists = _productService.AddProduct(name, description, price, quantity, categoryName);
        if (!categoryExists)
        {
            Console.WriteLine("Category not found. Product not added.");
        }
        else
        {
            Console.WriteLine("Product added successfully.");
        }
    }

    public void UpdateProductUI()
    {
        Console.WriteLine("Enter product ID to update:");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID format.");
            return;
        }

        Console.WriteLine("Enter new name (leave blank to keep current):");
        var name = Console.ReadLine();

        Console.WriteLine("Enter new description (leave blank to keep current):");
        var description = Console.ReadLine();

        Console.WriteLine("Enter new price (leave blank to keep current):");
        var priceInput = Console.ReadLine();
        decimal? price = string.IsNullOrWhiteSpace(priceInput) ? null : decimal.Parse(priceInput);

        Console.WriteLine("Enter new stock quantity (leave blank to keep current):");
        var quantityInput = Console.ReadLine();
        int? quantity = string.IsNullOrWhiteSpace(quantityInput) ? null : int.Parse(quantityInput);

        var success = _productService.UpdateProduct(id, name, description, price, quantity);
        if (success)
        {
            Console.WriteLine("Product updated successfully.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void ViewProductUI()
    {
        Console.WriteLine("Enter product ID to view:");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID format.");
            return;
        }

        var product = _productService.ViewProduct(id);
        if (product != null)
        {
            Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Description: {product.Description}, Price: {product.Price}, Stock: {product.StockQuantity}, Category: {product.Category?.Name}");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void DeleteProductUI()
    {
        Console.WriteLine("Enter product ID to delete:");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Invalid ID format.");
            return;
        }

        var success = _productService.DeleteProduct(id);
        if (success)
        {
            Console.WriteLine("Product deleted successfully.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }

    public void ViewAllProductsUI()
    {
        var products = _productService.ViewAllProducts();
        if (products.Any())
        {
            Console.WriteLine("Available Products:");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Price: {product.Price}, Stock: {product.StockQuantity}, Category: {product.Category?.Name}");
            }
        }
        else
        {
            Console.WriteLine("No products available.");
        }
    }

    internal void DeleteuserUI()
    {
        throw new NotImplementedException();
    }
}

