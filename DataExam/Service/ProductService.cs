using ConsoleApp1.Entities;
using System;
using System.Linq;

public class ProductService
{
    private readonly Repo<ProductEntity> _productRepository;
    private readonly Repo<CategoryEntity> _categoryRepository;

    public ProductService(Repo<ProductEntity> productRepository, Repo<CategoryEntity> categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public ProductService()
    {
    }

    public bool AddProduct(string name, string description, decimal price, int quantity, string categoryName)
    {
        var category = _categoryRepository.Find(c => c.Name.ToLower() == categoryName.ToLower()).FirstOrDefault();
        if (category == null)
        {
           
            return false; 
        }

        var product = new ProductEntity
        {
            Name = name,
            Description = description,
            Price = price,
            StockQuantity = quantity,
            CategoryId = category.CategoryId
        };

        _productRepository.Add(product);
        _productRepository.SaveChanges();

        return true; // Product added successfully
    }

    public bool UpdateProduct(int id, string name, string description, decimal? price, int? quantity)
    {
        var product = _productRepository.GetById(id);
        if (product == null)
        {
            return false; // Product not found
        }

        if (!string.IsNullOrWhiteSpace(name)) product.Name = name;
        if (!string.IsNullOrWhiteSpace(description)) product.Description = description;
        if (price.HasValue) product.Price = price.Value;
        if (quantity.HasValue) product.StockQuantity = quantity.Value;

        _productRepository.SaveChanges();
        return true; // Product updated successfully
    }

    public ProductEntity ViewProduct(int id)
    {
        return _productRepository.GetAllIncluding(p => p.Category).FirstOrDefault(p => p.ProductId == id);
    }

    public bool DeleteProduct(int id)
    {
        var product = _productRepository.GetById(id);
        if (product == null)
        {
            return false; // Product not found
        }

        _productRepository.Remove(product);
        _productRepository.SaveChanges();
        return true; // Product deleted successfully
    }

    public IQueryable<ProductEntity> ViewAllProducts()
    {
        var result = _productRepository.GetAllIncluding(p => p.Category).AsQueryable();
        return result;
    }

    // Assuming CreateCategory is a requirement for your business logic
    public CategoryEntity CreateCategory(string name, string description)
    {
        var newCategory = new CategoryEntity { Name = name, Description = description };
        _categoryRepository.Add(newCategory);
        _categoryRepository.SaveChanges();
        return newCategory; // New category created successfully
    }
}
