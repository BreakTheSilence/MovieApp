using Domain.Models;
using MovieApp.DAL.Interfaces.Repositories;
using MovieBackend.Interfaces.Services;

namespace MovieBackend.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    
    public IEnumerable<Category> GetCategories()
    {
        return _categoryRepository.GetAllCategories();
    }
}