using Domain.Models;

namespace MovieApp.DAL.Interfaces.Repositories;

public interface ICategoryRepository
{
    IEnumerable<Category> GetAllCategories();
}