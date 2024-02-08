


using ConsoleApp1.Entities;

public class CategoryUI
{
    private  CategoryService _categoryService;
    private Repo<CategoryEntity> categoryRepository;

    public CategoryUI(CategoryService categoryService)
    {
        _categoryService = categoryService;
       
    }
    public void DisplayCategoryManagementMenu()
    {
        bool keepRunning = true;
        while (keepRunning)
        {
            Console.WriteLine("\nCategory Management");
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Add Category");
            Console.WriteLine("2. View All Categories");
            Console.WriteLine("3. Update Category");
            Console.WriteLine("4. Delete Category");
            Console.WriteLine("5. Return to Main Menu");

            string option = Console.ReadLine();
            Console.Clear();

            switch (option)
            {
                case "1":
                    AddCategoryUI();
                    break;
                case "2":
                    ListCategoriesUI();
                    break;
                case "3":
                    UpdateCategoryUI();
                    break;
                case "4":
                    DeleteCategoryUI();
                    break;
                case "5":
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }


   
 
    public CategoryUI()
    {
    }

    public void AddCategoryUI()
    {
        Console.WriteLine("Enter category name:");
        var name = Console.ReadLine();

        Console.WriteLine("Enter category description:");
        var description = Console.ReadLine();

        _categoryService.CreateCategory(name, description);
        Console.WriteLine("New category created successfully.");
    }

    public void ListCategoriesUI()
    {
        var categories = _categoryService.GetAllCategories();
        foreach (var category in categories)
        {
            Console.WriteLine($"ID: {category.CategoryId}, Name: {category.Name}, Description: {category.Description}");
        }
    }

    public void UpdateCategoryUI()
    {
        Console.WriteLine("Enter category ID to update:");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter new category name:");
        var name = Console.ReadLine();

        Console.WriteLine("Enter new category description:");
        var description = Console.ReadLine();

        _categoryService.UpdateCategory(id, name, description);
        Console.WriteLine("Category updated successfully.");
    }

    public void DeleteCategoryUI()
    {
        Console.WriteLine("Enter category ID to delete:");
        int id = int.Parse(Console.ReadLine());

        _categoryService.DeleteCategory(id);
        Console.WriteLine("Category deleted successfully.");
    }
}
