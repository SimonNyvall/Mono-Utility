namespace LevenshteinDistance.Tests;

public class Search_Tests
{
    [Fact]
    public void Returns_StringArray_WithSearchScore()
    {
        // Arrange
        string firstSearchTerm = "ant";
        string[] searchList = { "aunt", "Samantha" };

        // Act
        var result = Levenshtein.Search(firstSearchTerm, searchList);
        
        // Assert
        Assert.IsType<string[]>(result);
        Assert.Equal(2, result.Length);
        Assert.Equal("aunt", result[0]);
        Assert.Equal("Samantha", result[1]);
    }
}