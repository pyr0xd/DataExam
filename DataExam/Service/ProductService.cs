using ConsoleApp1.Entities;

public class ProductService
{
    private Repo<ProductEntity> _productRepository;
    private Repo<CategoryEntity> _categoryRepository;

    public ProductService(Repo<ProductEntity> productRepository, Repo<CategoryEntity> categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public void AddProduct()
    {

        Console.WriteLine("Enter product name:");
        var name = Console.ReadLine();

        Console.WriteLine("Enter product description:");
        var description = Console.ReadLine();

        Console.WriteLine("Enter product price:");
        var price = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter stock quantity:");
        var quantity = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Category Name:");
        var categoryName = Console.ReadLine();

        var category = _categoryRepository.Find(c => c.Name.ToLower() == categoryName.ToLower()).FirstOrDefault();
        if (category == null)
        {
            Console.WriteLine("Category not found. Do you want to create a new category with this name? (yes/no)");
            var createCategory = Console.ReadLine().Trim().ToLower();
            if (createCategory == "yes" || createCategory == "y")
            {
                category = CreateCategory(_categoryRepository, categoryName);
                if (category == null)
                {
                    Console.WriteLine("Failed to create a new category.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Product not added. Category is required.");
                return;
            }
        }

        var product = new ProductEntity { Name = name, Description = description, Price = price, StockQuantity = quantity, CategoryId = category.CategoryId };
        _productRepository.Add(product);
        _productRepository.SaveChanges();

        Console.WriteLine("Product added successfully.");

    }

    public void UpdateProduct()
    {

        Console.WriteLine("Enter product ID to update:");
        var id = int.Parse(Console.ReadLine());

        var product = _productRepository.GetById(id);
        if (product != null)
        {
            Console.WriteLine("Enter new name (leave blank to keep current):");
            var name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name)) product.Name = name;

            Console.WriteLine("Enter new description (leave blank to keep current):");
            var description = Console.ReadLine();
            if (!string.IsNullOrEmpty(description)) product.Description = description;

            Console.WriteLine("Enter new price (leave blank to keep current):");
            var priceInput = Console.ReadLine();
            if (decimal.TryParse(priceInput, out var price)) product.Price = price;

            Console.WriteLine("Enter new stock quantity (leave blank to keep current):");
            var quantityInput = Console.ReadLine();
            if (int.TryParse(quantityInput, out var quantity)) product.StockQuantity = quantity;

            _productRepository.SaveChanges();
            Console.WriteLine("Product updated successfully.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }

    }



    static CategoryEntity CreateCategory(Repo<CategoryEntity> categoryRepository, string categoryName)
    {
        Console.WriteLine("Enter category description:");
        var categoryDescription = Console.ReadLine();

        var newCategory = new CategoryEntity { Name = categoryName, Description = categoryDescription };
        categoryRepository.Add(newCategory);
        categoryRepository.SaveChanges();

        Console.WriteLine("New category created successfully.");
        return newCategory;
    }
  


    public void ViewProduct()
    {
        Console.WriteLine("Enter product ID to view:");
        var id = int.Parse(Console.ReadLine());

        var product = _productRepository.GetAllIncluding(p => p.Category).FirstOrDefault(p => p.ProductId == id);

        if (product != null)
        {
            Console.WriteLine($"ID: {product.ProductId}, Name: {product.Name}, Price: {product.Price}, Stock: {product.StockQuantity}, CategoryName: {product.Category?.Name}");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
  
    public void DeleteProduct()
    {
        Console.WriteLine("Enter product ID to delete:");
        var id = int.Parse(Console.ReadLine());

        var product = _productRepository.GetById(id);
        if (product != null)
        {
            _productRepository.Remove(product);
            _productRepository.SaveChanges();
            Console.WriteLine("Product deleted successfully.");
        }
        else
        {
            Console.WriteLine("Product not found.");
        }
    }
    public void ViewAllProducts()
    {
        var products = _productRepository.GetAllProductsIncludingCategory();

        if (products.Any())
        {
            // Header
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,-10} | {1,-20} | {2,-10} | {3,-10} | {4,-15} |", "ID", "Name", "Price", "Stock", "Category");
            Console.WriteLine(new string('-', 74));

            // Rows
            foreach (var product in products)
            {
                Console.WriteLine("| {0,-10} | {1,-20} | {2,-10} | {3,-10} | {4,-15} |",
                    product.ProductId,
                    product.Name,
                    $"{product.Price} SEK", // Assuming Price is a numeric type
                    product.StockQuantity,
                    product.Category?.Name ?? "N/A");
                Console.WriteLine(new string('-', 74));
            }
        }
        else
        {
            Console.WriteLine("No products available.");
        }

        Console.WriteLine("press anything to return");
        Console.ReadKey();
    }
    






}
