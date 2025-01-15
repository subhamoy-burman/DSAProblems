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

    [Test]
    public void TestFrameGroupAnagrams()
    {
        // Arrange
        var words = new List<string> { "yo", "act", "flop", "tac", "foo", "cat", "oy", "olfp" };
        var expected = new List<List<string>>
        {
            new List<string> { "yo", "oy" },
            new List<string> { "flop", "olfp" },
            new List<string> { "act", "tac", "cat" },
            new List<string> { "foo" }
        };

        // Act
        var result = StringGFG.FrameGroupAnagrams(words);

        // Assert
        Assert.That(expected.Count.Equals(result.Count));
        foreach (var group in expected)
        {
            Assert.That(result.Exists(r => new HashSet<string>(r).SetEquals(group)));
        }
    }

    [Test] 
    public void TestValidIpAddresses()
    {
        var input = "1921680";
        var expectedOutput = new List<string>
        {
            "1.9.216.80",
            "1.92.16.80",
            "1.92.168.0",
            "19.2.16.80",
            "19.2.168.0",
            "19.21.6.80",
            "19.21.68.0",
            "19.216.8.0",
            "192.1.6.80",
            "192.1.68.0",
            "192.16.8.0"
        };

        var result = StringGFG.GetIpAddressList(input);
        CollectionAssert.AreEquivalent(expectedOutput, result);
    }

    [Test]
    public void TestCase1()
    {
        // Arrange
        var input = "AlgoExpert is the best!";
        var expected = "best! the is AlgoExpert";

        // Act
        var result = StringGFG.ReverseWords(input);

        // Assert
        Assert.That(expected.Equals(result));
    }

    [Test]
    public void TestCase2()
    {
        // Arrange
        var input = "Reverse These Words";
        var expected = "Words These Reverse";

        // Act
        var result = StringGFG.ReverseWords(input);

        // Assert
        Assert.That(expected.Equals(result));
    }

    [Test]
    public void TestCase3()
    {
        // Arrange
        var input = "..H,, hello 678";
        var expected = "678 hello ..H,,";

        // Act
        var result = StringGFG.ReverseWords(input);

        // Assert
        Assert.That(expected.Equals(result));
    }

    [Test]
    public void TestCase4()
    {
        // Arrange
        var input = "this this words this this this words this";
        var expected = "this words this this this words this this";

        // Act
        var result = StringGFG.ReverseWords(input);

        // Assert
        Assert.That(expected.Equals(result));
    }

    [Test]
    public void TestMinimumCharacterForWord()
    {
        string[] words = { "this", "that", "did", "deed", "them!", "a" };
        List<char> expected = new List<char> { 't', 't', 'h', 'i', 's', 'a', 'd', 'd', 'e', 'e', 'm', '!' };
        List<char> result =  StringGFG.ReturnMinimumCharactersForWord(words);
        CollectionAssert.AreEquivalent(expected, result);
    }

    [Test]
    public void Test_SameSingleCharacter()
    {
        Assert.That(StringGFG.EditDistance("a", "a").Equals(true));
    }

    [Test]
    public void Test_SameMultipleCharacters()
    {
        Assert.That(StringGFG.EditDistance("aaa", "aaa").Equals(true));
    }

    [Test]
    public void Test_SingleCharacterReplace()
    {
        Assert.That(StringGFG.EditDistance("a", "b").Equals(true));
    }

    [Test]
    public void Test_SingleCharacterRemove()
    {
        Assert.That(StringGFG.EditDistance("ab", "b").Equals(true));
    }

    [Test]
    public void Test_MultipleCharactersRemove()
    {
        Assert.That(StringGFG.EditDistance("abc", "b").Equals(false));
    }

    [Test]
    public void Test_SingleCharacterRemoveFromEnd()
    {
        Assert.That(StringGFG.EditDistance("ab", "a").Equals(true));
    }

    [Test]
    public void Test_SingleCharacterAdd()
    {
        Assert.That(StringGFG.EditDistance("b", "ab").Equals(true));
    }

    [Test]
    public void Test_MultipleCharactersReplace()
    {
        Assert.That(StringGFG.EditDistance("bb", "a").Equals(false));
    }

    [Test]
    public void Test_SingleCharacterAddToEnd()
    {
        Assert.That(StringGFG.EditDistance("a", "ab").Equals(true));
    }

    [Test]
    public void Test_SingleCharacterReplaceInMiddle()
    {
        Assert.That(StringGFG.EditDistance("bb", "ab").Equals(true));
    }

    [Test]
    public void Test_SingleCharacterReplaceAtStart()
    {
        Assert.That(StringGFG.EditDistance("ab", "bb").Equals(true));
    }

    [Test]
    public void Test_SingleCharacterRemoveFromMiddle()
    {
        Assert.That(StringGFG.EditDistance("hello", "helo").Equals(true));
    }

    [Test]
    public void Test_MultipleCharactersRemoveFromMiddle()
    {
        Assert.That(StringGFG.EditDistance("hello", "heo").Equals(false));
    }

    [Test]
    public void Test_SingleCharacterAddToMiddle()
    {
        Assert.That(StringGFG.EditDistance("hello", "heloo").Equals(true));
    }

    [Test]
    public void Test_MultipleCharactersAddToEnd()
    {
        Assert.That(StringGFG.EditDistance("hello", "heloos").Equals(false));
    }

    [Test]
    public void Test_MultipleCharactersAddToEndAgain()
    {
        Assert.That(StringGFG.EditDistance("hello", "heloos").Equals(false));
    }

    [Test]
    public void Test_SingleCharacterAddToMiddleAgain()
    {
        Assert.That(StringGFG.EditDistance("hello", "helllo").Equals(true));
    }

    [Test]
    public void Test_MultipleCharactersAddToMiddle()
    {
        Assert.That(StringGFG.EditDistance("hello", "helllos").Equals(false));
    }

    [Test]
    public void Test_SingleCharacterRemoveFromStart()
    {
        Assert.That(StringGFG.EditDistance("hello", "ello").Equals(true));
    }

    [Test]
    public void Test_MultipleCharactersRemoveFromStart()
    {
        Assert.That(StringGFG.EditDistance("hello", "llo").Equals(false));
    }

    [Test]
    public void TestDFSTraversal()
    {
        var dfsTravelList = GraphProblems.GetDFSTraversal();
        Assert.That(dfsTravelList.SequenceEqual(new List<int> { 1, 2, 3, 4, 5 }));
    }
}