using Domain.Models;

namespace MovieBackend.Interfaces.Services;

public interface ICategoryService
{
    IEnumerable<Category> GetCategories();
}