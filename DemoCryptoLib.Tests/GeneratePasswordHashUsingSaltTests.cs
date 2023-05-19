using System.Text;

namespace DemoCryptoLib.Tests;

public class GeneratePasswordHashUsingSaltTests
{
    [Fact]
    public void BaseAlgo_Returns_ValidData()
    {
        // Arrange
        const string password = "dummyPassword";
        byte[] salt = Encoding.UTF8.GetBytes("dummySalt01234567890");

        // Act
        string hash = DemoCryptoLib.GeneratePasswordHashUsingSalt(password, salt);

        // Assert
        Assert.Equal("ZHVtbXlTYWx0MDEyMzQ1Nm0y6KxqqBgqY9lp8+BiuXtPGoT2", hash);
    }
    
    [Fact]
    public void OptimizedAlgo_Returns_ValidData()
    {
        // Arrange
        const string password = "dummyPassword";
        byte[] salt = Encoding.UTF8.GetBytes("dummySalt01234567890");

        // Act
        string hash = DemoCryptoLib.GeneratePasswordHashUsingSaltOptimized(password, salt);

        // Assert
        Assert.Equal("ZHVtbXlTYWx0MDEyMzQ1Nm0y6KxqqBgqY9lp8+BiuXtPGoT2", hash);
    }
}