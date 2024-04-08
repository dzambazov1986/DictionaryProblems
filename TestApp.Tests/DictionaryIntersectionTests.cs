using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{
    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        // Arrange
        var dict1 = new Dictionary<string, int>();
        var dict2 = new Dictionary<string, int>();

        // Act
        var result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        // Arrange
        var dict1 = new Dictionary<string, int>();
        var dict2 = new Dictionary<string, int> { { "key1", 1 }, { "key2", 2 } };

        // Act
        var result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {
        // Arrange
        var dict1 = new Dictionary<string, int> { { "key1", 1 }, { "key2", 2 } };
        var dict2 = new Dictionary<string, int> { { "key3", 3 }, { "key4", 4 } };

        // Act
        var result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        // Arrange
        var dict1 = new Dictionary<string, int> { { "key1", 1 }, { "key2", 2 } };
        var dict2 = new Dictionary<string, int> { { "key1", 1 }, { "key3", 3 } };

        // Act
        var result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result.ContainsKey("key1"), Is.True);
        Assert.That(result["key1"], Is.EqualTo(1));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        // Arrange
        var dict1 = new Dictionary<string, int> { { "key1", 1 }, { "key2", 2 } };
        var dict2 = new Dictionary<string, int> { { "key1", 3 }, { "key3", 3 } };

        // Act
        var result = DictionaryIntersection.Intersect(dict1, dict2);

        // Assert
        Assert.That(result, Is.Empty);
    }
}
