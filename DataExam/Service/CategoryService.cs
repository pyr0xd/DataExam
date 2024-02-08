using ConsoleApp1.Entities;

public class CategoryService
{
    private readonly Repo<CategoryEntity> _categoryRepository;

    public CategoryService(Repo<CategoryEntity> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public void CreateCategory(string name, string description)
    {
        var newCategory = new CategoryEntity { Name = name, Description = description };
        _categoryRepository.Add(newCategory);
        _categoryRepository.SaveChanges();
    }

    public IEnumerable<CategoryEntity> GetAllCategories()
    {
        return _categoryRepository.GetAll();
    }

    public CategoryEntity GetCategoryById(int id)
    {
        return _categoryRepository.GetById(id);
    }

    public void UpdateCategory(int id, string newName, string newDescription)
    {
        var category = _categoryRepository.GetById(id);
        if (category != null)
        {
            category.Name = newName;
            category.Description = newDescription;
            _categoryRepository.SaveChanges();
        }
    }

    public void DeleteCategory(int id)
    {
        var category = _categoryRepository.GetById(id);
        if (category != null)
        {
            _categoryRepository.Remove(category);
            _categoryRepository.SaveChanges();
        }
    }
}
