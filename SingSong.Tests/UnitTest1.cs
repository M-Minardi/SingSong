using Xunit;
using SingSong.App;

namespace SingSong.Tests;

public class SingSongTests
{

    [Fact]
    public void ShouldGenerateFirstVerse()
    {
        // Arrange
        var animals = new[] { "fly", "spider", "bird", "cat", "dog", "cow", "horse" };
        var songGenerator = new SongGenerator(animals);
        
        // Act
        var result = songGenerator.GenerateVerse(1);
        
        // Assert
        var expected = "There was an old lady who swallowed a fly.\nI don't know why she swallowed a fly - perhaps she'll die!";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldGenerateSecondVerse()
    {
        // Arrange
        var animals = new[] { "fly", "spider", "bird", "cat", "dog", "cow", "horse" };
        var songGenerator = new SongGenerator(animals);
        
        // Act
        var result = songGenerator.GenerateVerse(2);
        
        // Assert
        var expected = "There was an old lady who swallowed a spider.\nThat wriggled and wiggled and tickled inside her.\nShe swallowed the spider to catch the fly;\nI don't know why she swallowed a fly - perhaps she'll die!";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldGenerateCompleteSong()
    {
        // Arrange
        var animals = new[] { "fly", "spider", "bird", "cat", "dog", "cow", "horse" };
        var songGenerator = new SongGenerator(animals);
        
        // Act
        var result = songGenerator.GenerateCompleteSong();
        
        // Assert
        Assert.Contains("There was an old lady who swallowed a fly", result);
        Assert.Contains("There was an old lady who swallowed a spider", result);
        Assert.Contains("There was an old lady who swallowed a horse", result);
        Assert.Contains("She's dead, of course!", result);
    }

    [Fact]
    public void ShouldWorkWithDifferentAnimalList()
    {
        // Arrange - Película infantil con diferentes animales
        var movieAnimals = new[] { "mouse", "cat", "dog", "elephant" };
        var songGenerator = new SongGenerator(movieAnimals);
        
        // Act
        var result = songGenerator.GenerateVerse(1);
        
        // Assert
        var expected = "There was an old lady who swallowed a mouse.\nI don't know why she swallowed a mouse - perhaps she'll die!";
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldHandleVariableNumberOfAnimals()
    {
        // Arrange - Lista corta de animales
        var shortAnimalList = new[] { "fly", "spider" };
        var songGenerator = new SongGenerator(shortAnimalList);
        
        // Act
        var result = songGenerator.GenerateCompleteSong();
        
        // Assert
        Assert.Contains("There was an old lady who swallowed a fly", result);
        Assert.Contains("There was an old lady who swallowed a spider", result);
        Assert.Contains("She's dead, of course!", result);
    }
}