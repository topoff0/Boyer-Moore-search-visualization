using AutoFixture.Xunit2;
using Moore.Core.Entities;
using Moore.Core.RequestDtos;
using Moore.Services.Services;
using Xunit.Abstractions;

namespace Moore.Unit.Tests;

public class BoyerMooreSearchUnitTests(ITestOutputHelper outputHelper)
{
    private readonly MooreService _sut = new(); // System Under Test

    private readonly ITestOutputHelper _outputHelper = outputHelper;

    [Fact]
    public void Search_PatternExists_ReturnsCorrectData()
    {
        // Arrange
        SearchRequest request = new("substbsatsuttrstr", "str");
        MooreAlgorithm algorithm = new(request);

        _outputHelper.WriteLine("Testing with text: {0}", request.Text);
        _outputHelper.WriteLine("Testing with pattern: {0}", request.Pattern);

        // Act
        var result = _sut.Search(algorithm);

        // Assert
        Assert.True(result.IsFound);
        Assert.Equal(14, result.Position);
        Assert.NotEmpty(result.Steps);
        Assert.True(result.Steps.Count > 0);

        Assert.Contains(result.Steps, s => s.IsMatch);
        Assert.Contains(result.Steps, s => !s.IsMatch);
    }

    [Theory]
    [AutoData]
    public void Search_WithValidData_ReturnsValidSearchResult(string text, string pattern)
    {
        //Arrange
        SearchRequest request = new(text, pattern);
        MooreAlgorithm algorithm = new(request);

        _outputHelper.WriteLine("Text: {0}", text);
        _outputHelper.WriteLine("Pattern : {0}", pattern);

        //Act
        var result = _sut.Search(algorithm);

        //Assert
        Assert.NotNull(result);
    }

    [Theory]
    [InlineData("abcdefgh", "def", 3)]
    [InlineData("hello world", "world", 6)]
    [InlineData("mississippi", "issi", 1)]
    [InlineData("aaaaab", "aaab", 2)]
    public void Search_KnownPatterns_ReturnsCorrectPosition(string text, string pattern, int expectedPosition)
    {
        // Arrange
        var request = new SearchRequest(text, pattern);
        var algorithm = new MooreAlgorithm(request);

        _outputHelper.WriteLine("Text: {0}", text);
        _outputHelper.WriteLine("Pattern: {0}", pattern);

        // Act
        var result = _sut.Search(algorithm);

        // Assert
        Assert.True(result.IsFound);
        Assert.Equal(expectedPosition, result.Position);
    }
}
