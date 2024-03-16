using Domain.Models;
using MovieApp.DAL.Interfaces.Repositories;

namespace MovieApp.DAL.Repositories;

public class CategoryRepository : ICategoryRepository
{
    public IEnumerable<Category> GetAllCategories()
    {
        return GenerateCategories();
    }

    private IEnumerable<Category> GenerateCategories()
    {
        return new List<Category>
        {
            new() { Id = 1, Name = "Drama" },
            new() { Id = 2, Name = "Action" },
            new() { Id = 3, Name = "Comedy" },
            new() { Id = 4, Name = "Sci-Fi" },
            new() { Id = 5, Name = "Fantasy" },
            new() { Id = 6, Name = "Adventure" },
            new() { Id = 7, Name = "Thriller" },
            new() { Id = 8, Name = "Animation" },
            new() { Id = 9, Name = "Romance" },
            new() { Id = 10, Name = "Mystery" }
        };
    }
}