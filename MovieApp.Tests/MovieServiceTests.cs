namespace MovieApp.Tests;

[TestClass]
public class MovieServiceTests
{
    [TestMethod]
    public void GetMovies_ShouldReturnListOfMovies()
    {
        // Arrange
        var mockRepository = new Mock<IMovieRepository>();
        mockRepository.Setup(repo => repo.GetAllMovies()).Returns(new List<Movie> { new(), new() });

        var movieService = new MovieService(mockRepository.Object);

        // Act
        var result = movieService.GetMovies();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count());
    }

    [TestMethod]
    public void GetMovieById_ShouldReturnMovieDetails()
    {
        // Arrange
        var movieId = 1;
        var mockRepository = new Mock<IMovieRepository>();
        mockRepository.Setup(repo => repo.GetMovieById(movieId))
            .Returns(new Movie { Id = movieId, Title = "Test Movie" });

        var movieService = new MovieService(mockRepository.Object);

        // Act
        var result = movieService.GetMovieById(movieId);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(movieId, result.Id);
        Assert.AreEqual("Test Movie", result.Title);
    }

    [TestMethod]
    public void GetMovieById_WithInvalidId_ShouldReturnNull()
    {
        // Arrange
        var invalidMovieId = -1;
        var mockRepository = new Mock<IMovieRepository>();
        mockRepository.Setup(repo => repo.GetMovieById(invalidMovieId)).Returns((Movie)null);

        var movieService = new MovieService(mockRepository.Object);

        // Act
        var result = movieService.GetMovieById(invalidMovieId);

        // Assert
        Assert.IsNull(result);
    }
}