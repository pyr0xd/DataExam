using ConsoleApp1.Entities;


public class CategoryService
{
    private Repo<CategoryEntity> _categoryRepository;

    public CategoryService(Repo<CategoryEntity> categoryRepository)
    {
        IRepo<CategoryEntity> _categoryRepository;
        _categoryRepository = categoryRepository;

    }

    public void CreateCategory()
    {
        Console.WriteLine("Enter category name:");
        var categoryName = Console.ReadLine();

        Console.WriteLine("Enter category description:");
        var categoryDescription = Console.ReadLine();

        var newCategory = new CategoryEntity { Name = categoryName, Description = categoryDescription };
        _categoryRepository.Add(newCategory);
        _categoryRepository.SaveChanges();

        Console.WriteLine("New category created successfully.");
    }

  
}
