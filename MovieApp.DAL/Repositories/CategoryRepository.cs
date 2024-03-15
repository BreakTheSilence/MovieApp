using Domain.Models;
using MovieApp.DAL.Interfaces.Repositories;

namespace MovieApp.DAL.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public IEnumerable<Category> GetAllCategories()
    {
        throw new NotImplementedException();
    }
}