using Domain.Models;

namespace Domain.DTO;

public class MovieDto
{
    public int Id { get; init; }
    public string Title { get; init; }
    public int Rating { get; init; }
    
    public int Year { get; init; }
    public Category Category { get; init; }
}

public class MovieDetailsDto : MovieDto
{
    public string Description { get; init; }
}