namespace MovieApp.Tests;

[TestClass]
public class CategoryServiceTests
{
    [TestMethod]
    public void GetCategories_ShouldReturnListOfCategories()
    {
        // Arrange
        var mockRepository = new Mock<ICategoryRepository>();
        mockRepository.Setup(repo => repo.GetAllCategories()).Returns(new List<Category> { new(), new() });

        var movieService = new CategoryService(mockRepository.Object);

        // Act
        var result = movieService.GetCategories();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Count());
    }
}