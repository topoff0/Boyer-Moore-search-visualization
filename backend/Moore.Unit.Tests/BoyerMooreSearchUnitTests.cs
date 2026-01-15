using Moore.Core.Entities;
using Moore.Core.RequestDtos;
using Moore.Services.Services;

namespace Moore.Unit.Tests;

public class BoyerMooreSearchUnitTests
{
    private readonly MooreService _mooreService;

    public BoyerMooreSearchUnitTests()
    {
        _mooreService = new MooreService();
    }
     

    [Fact]
    public void Search_PatternExists_ReturnsCorrectData()
    {
        // Arrange
        SearchRequest request = new("substbsatsuttrstr", "str");
        MooreAlgorithm algorithm = new(request); 

        // Act
        var result = _mooreService.Search(algorithm);
        
        // Assert
        Assert.True(result.IsFound);
        Assert.Equal(14, result.Position);
        Assert.NotEmpty(result.Steps);
        Assert.True(result.Steps.Count > 0);
        
        Assert.Contains(result.Steps, s => s.IsMatch);
        Assert.Contains(result.Steps, s => !s.IsMatch);
    }
}
