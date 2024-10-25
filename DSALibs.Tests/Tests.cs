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
}