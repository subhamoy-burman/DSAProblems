using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework.Legacy;

namespace DSALibs.Tests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        int[] input = { 4, 3, 7, 8, 6, 2, 1 };
        int[] expected = { 3, 7, 4, 8, 2, 6, 1 };
        Arrays.ReArrangeToZigZag(input);
        Assert.That(input, Is.EqualTo(expected));
    }

    [Test]
    public void TestReArrangementOfArray()
    {
        //Input: arr[] = {1, 2, 3, 4, 5, 6} 
        //Output: arr[] = {6, 1, 5, 2, 4, 3} 

        int[] input = {1, 2, 3, 4, 5, 6} ;
        int[] expected = {6, 1, 5, 2, 4, 3};

        var output = Arrays.ReArrangeWithMaxMinAlternate(input);
        Assert.That(output.SequenceEqual(expected)); 
    }

    [Test]
    public void TestReturnKthElement()
    {
        int[] arr1 = {2, 3, 6, 7, 9} ;
        int[] arr2 = {1, 4, 8, 10};

        int k = 5;
        var output = Arrays.FindKthMergedElement(arr1, arr2, k);

        Assert.That(output,Is.EqualTo(6));

    }

    [Test]
    public void TestMinimumPlatforms()
    {
        int[] arr1 = {900, 940, 950, 1100, 1500, 1800} ;
        int[] arr2 = {910, 1200, 1120, 1130, 1900, 2000};

        int minPlatforms = Arrays.MinimumNoOfPlatforms(arr1, arr2);

        Assert.That(minPlatforms, Is.EqualTo(3));

    }

    [Test]
    public void TestGetMaxReArrangeSum()
    {
        string[] arr = {"3", "30", "34", "5", "9" };
        string output = Arrays.ArrangeMaximumSum(arr);

        Assert.That(output, Is.EqualTo("9534330"));
    }

    [Test]
    public void TestQuickSort()
    {
        int[] arr = { 4,3,1,2,5,9,7,10,6 };
        var output = SortingSearching.PerformQuickSort(arr);

        Assert.That(output.SequenceEqual([1, 2, 3, 4, 5, 6, 7, 9, 10]));
    }

    [Test]
    public void TestFindKthSmallestElement()
    {
        int[] arr = { 7, 10, 4, 3, 20, 15 };
        int k = 3;

        Assert.That(SortingSearching.FindKthSmallestElement(arr,k), Is.EqualTo(7));
    }

    [Test]
    public void TestFindPowerPairsCount()
    {
        int[] arr1 = { 2, 1, 6 };
        int[] arr2 = { 1, 5 };

        Assert.That(HashingGFG.CountPowerPairs(arr1,arr2), Is.EqualTo(3));



        int[] arr3 = { 10, 19, 18 };
        int[] arr4 = { 11, 15, 9 };

        Assert.That(HashingGFG.CountPowerPairs(arr3, arr4), Is.EqualTo(2));


    }

    [Test]
    public void TestFindDistinctElementsInKSizedWindows()
    {
        int[] arr1 = { 1, 2, 1, 3, 4, 2, 3 };
        int[] arr2 = { 1, 2, 4, 4 };

        Assert.That(HashingGFG.FindDistinctElementsInKSizedWindows(arr1, 4).SequenceEqual(new List<int> { 3,4,4,3}), Is.True );


        Assert.That(HashingGFG.FindDistinctElementsInKSizedWindows(arr2, 2).SequenceEqual(new List<int> { 2,2,1}), Is.True);


    }

    [Test]
    public void CountSubArraysWithSumZero()
    {
        int[] arr1 = { 6, 3, -1, -3, 4, -2, 2, 4, 6, -12, -7 };

        Assert.That(HashingGFG.CountSubArraysWithSumZero(arr1).Equals(5));
    }

    [Test]
    public void TestCheckIfAnyArrayPairElement()
    {
        int[] arr1 = { 9, 7, 5, 3 };

        Assert.That(HashingGFG.CheckIfArrayPairSumDivisibleByK(arr1, 6), Is.True);

    }


    [Test]
    public void SpiralTraversal_ShouldReturnCorrectSequence()
    {
        // Arrange
        int[,] inputMatrix = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
        List<int> expected = new List<int> { 1, 2, 3, 6, 9, 8, 7, 4, 5 };

        // Act
        List<int> result = MatrixSets.SpiralTraversal(inputMatrix);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void TestElementExistsInFirstRow()
    {
        int[,] matrix = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };
        int element = 2;
        bool result = MatrixSets.IsElementExistsIn2DMatrix(matrix, element);
        Assert.That(result, Is.True);
    }

    [Test]
    public void TestElementExistsInMiddleRow()
    {
        int[,] matrix = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };
        int element = 5;
        bool result = MatrixSets.IsElementExistsIn2DMatrix(matrix, element);
        Assert.That(result, Is.True);
    }

    [Test]
    public void TestElementExistsInLastRow()
    {
        int[,] matrix = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };
        int element = 9;
        bool result = MatrixSets.IsElementExistsIn2DMatrix(matrix, element);
        Assert.That(result, Is.True);
    }

    [Test]
    public void TestElementDoesNotExist()
    {
        int[,] matrix = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };
        int element = 10;
        bool result = MatrixSets.IsElementExistsIn2DMatrix(matrix, element);
        Assert.That(result, Is.False);
    }


    [Test]
    public void TestGetAllPathFromTopToBottomIn2dMatrix()
    {
        // Arrange
        char[,] matrix = {
            { 'A', 'B', 'C' },
            { 'D', 'E', 'F' },
            { 'G', 'H', 'I' }
        };
        var expectedPaths = new List<List<char>>
        {
            new List<char> { 'A', 'B', 'C', 'F', 'I' },
            new List<char> { 'A', 'B', 'E', 'F', 'I' },
            new List<char> { 'A', 'B', 'E', 'H', 'I' },
            new List<char> { 'A', 'D', 'E', 'F', 'I' },
            new List<char> { 'A', 'D', 'E', 'H', 'I' },
            new List<char> { 'A', 'D', 'G', 'H', 'I' }
        };

        // Act
        var result = MatrixSets.GetAllPathFromTopToBottomIn2dMatrix(matrix);

        // Assert
        Assert.That(expectedPaths.Count == result.Count);
    }


    [Test]
    public void Test_Rotation_AntiClockwise()
    {
        string str1 = "amazon";
        string str2 = "azonam";
        bool result = StringGFG.IsRotatedByTwoPlaces(str1, str2);
        Assert.That(result == true);
    }

    [Test]
    public void Test_Rotation_Clockwise()
    {
        string str1 = "amazon";
        string str2 = "onamaz";
        bool result = StringGFG.IsRotatedByTwoPlaces(str1, str2);
        Assert.That(result == true);
    }

    [Test]
    public void ConvertRomanNumberStringToNumeric_SingleRomanNumeral_ReturnsCorrectValue_1()
    {
        int result = StringGFG.ConvertRomanNumberStringToNumeric("V");
        Assert.That(5 == result);
    }

    [Test]
    public void ConvertRomanNumberStringToNumeric_SingleRomanNumeral_ReturnsCorrectValue_2()
    {
        int result = StringGFG.ConvertRomanNumberStringToNumeric("XII");
        Assert.That(12 == result);
    }

    [Test]
    public void ConvertRomanNumberStringToNumeric_SingleRomanNumeral_ReturnsCorrectValue_3()
    {
        int result = StringGFG.ConvertRomanNumberStringToNumeric("MCMIV");
        Assert.That(1904 == result);
    }

    [Test]
    public void Test_ABCBC()
    {
        string input = "ABCBC";
        int expectedOutput = 3;
        int actualOutput = StringGFG.FindLongestSubstringWithoutRepeatingCharacter(input);
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void Test_AAA()
    {
        string input = "AAA";
        int expectedOutput = 1;
        int actualOutput = StringGFG.FindLongestSubstringWithoutRepeatingCharacter(input);
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void Test_GEEKSFORGEEKS()
    {
        string input = "GEEKSFORGEEKS";
        int expectedOutput = 7;
        int actualOutput = StringGFG.FindLongestSubstringWithoutRepeatingCharacter(input);
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    // Additional test cases
    [Test]
    public void Test_EmptyString()
    {
        string input = "";
        int expectedOutput = 0;
        int actualOutput = StringGFG.FindLongestSubstringWithoutRepeatingCharacter(input);
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void Test_SingleCharacter()
    {
        string input = "A";
        int expectedOutput = 1;
        int actualOutput = StringGFG.FindLongestSubstringWithoutRepeatingCharacter(input);
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void Test_AllUniqueCharacters()
    {
        string input = "ABCDEFG";
        int expectedOutput = 7;
        int actualOutput = StringGFG.FindLongestSubstringWithoutRepeatingCharacter(input);
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    /*
    [TestCase("abaxyzzyxf", ExpectedResult = "xyzzyx")]
    [TestCase("a", ExpectedResult = "a")]
    [TestCase("it's highnoon", ExpectedResult = "noon")]
    [TestCase("noon high it is", ExpectedResult = "noon")]
    [TestCase("abccbait's highnoon", ExpectedResult = "abccba")]
    [TestCase("abcdefgfedcbazzzzzzzzzzzzzzzzzzzz", ExpectedResult = "abcdefgfedcba")]
    [TestCase("abcdefgfedcba", ExpectedResult = "abcdefgfedcba")]
    [TestCase("abcdefghfedcbaa", ExpectedResult = "aa")]
    [TestCase("abcdefggfedcba", ExpectedResult = "abcdefggfedcba")]
    [TestCase("zzzzzzz2345abbbba5432zzbbababa", ExpectedResult = "zzzzzzz")]
    [TestCase("z234a5abbbba54a32z", ExpectedResult = "a5abbbba5a")]
    [TestCase("z234a5abbba54a32z", ExpectedResult = "a5abbba5a")]
    [TestCase("ab12365456321bb", ExpectedResult = "12365456321")]
    [TestCase("aca", ExpectedResult = "aca")]
    public string TestLongestPalindrome(string str)
    {
        return StringGFG.LongestPalindrome(str);
    }*/

    [Test]
    public void TestLongestPalindrome() {

        Assert.That(StringGFG.LongestPlaindromeImproved("abaxyzzyxf"), Is.EqualTo("xyzzyx"));
    }

    [Test]
    public void TestSampleInput()
    {
        string input = "clementisacap";
        string expectedOutput = "mentisac";
        string actualOutput = StringGFG.LongestSubstringWithoutDuplication(input);
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void TestEmptyString()
    {
        string input = "";
        string expectedOutput = "";
        string actualOutput = StringGFG.LongestSubstringWithoutDuplication(input);
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void TestSingleCharacterString()
    {
        string input = "a";
        string expectedOutput = "a";
        string actualOutput = StringGFG.LongestSubstringWithoutDuplication(input);
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }

    [Test]
    public void TestStringWithAllUniqueCharacters()
    {
        string input = "abcdef";
        string expectedOutput = "abcdef";
        string actualOutput = StringGFG.LongestSubstringWithoutDuplication(input);
        Assert.That(actualOutput, Is.EqualTo(expectedOutput));
    }


}