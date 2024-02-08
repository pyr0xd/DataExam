using ConsoleApp1.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

public class ProductService
{
    private readonly Repo<ProductEntity> _productRepository;
    private readonly Repo<CategoryEntity> _categoryRepository;

    public ProductService(Repo<ProductEntity> productRepository, Repo<CategoryEntity> categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<bool> AddProductAsync(string name, string description, decimal price, int stockQuantity, string categoryName)
    {
        var category = _categoryRepository.Find(c => c.Name.ToLower() == categoryName.ToLower()).FirstOrDefault();
        if (category == null)
        {
            return false; // Category not found
        }

        var product = new ProductEntity
        {
            Name = name,
            Description = description,
            Price = price,
            StockQuantity = stockQuantity, // Corrected from 'quantity' to 'stockQuantity'
            CategoryId = category.CategoryId
        };

        await _productRepository.AddAsync(product);
        await _productRepository.SaveChangesAsync();

        return true; // Product added successfully
    }

    public async Task<bool> UpdateProductAsync(int productId, string? name, string? description, decimal? price, int? stockQuantity)
    {
        var product = await _productRepository.GetByIdAsync(productId); // Corrected from 'id' to 'productId'
        if (product == null)
        {
            return false; // Product not found
        }

        if (!string.IsNullOrWhiteSpace(name)) product.Name = name;
        if (!string.IsNullOrWhiteSpace(description)) product.Description = description;
        if (price.HasValue) product.Price = price.Value;
        if (stockQuantity.HasValue) product.StockQuantity = stockQuantity.Value; // Corrected from 'quantity'

        await _productRepository.SaveChangesAsync();
        return true; // Product updated successfully
    }

    public async Task<ProductEntity?> ViewProductAsync(int productId)
    {
        return await _productRepository.GetAllIncluding(p => p.Category).FirstOrDefaultAsync(p => p.ProductId == productId); // Corrected 'id' to 'productId'
    }

    public async Task<bool> DeleteProductAsync(int productId)
    {
        var product = await _productRepository.GetByIdAsync(productId); // Corrected from 'id' to 'productId'
        if (product == null)
        {
            return false; // Product not found
        }

        _productRepository.Remove(product);
        await _productRepository.SaveChangesAsync();
        return true; // Product deleted successfully
    }

    public async Task<IEnumerable<ProductEntity>> ViewAllProductsAsync()
    {
        return await _productRepository.GetAllIncluding(p => p.Category).ToListAsync();
    }
}
