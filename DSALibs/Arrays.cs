using System.Runtime.CompilerServices;

namespace DSALibs;

public class Arrays
{
    public static void ReArrangeToZigZag(int[] arr)
    {
        for (int i = 0; i < arr.Length; i = i + 3)
        {
            int a = arr[i];


            int highest = GetHighest(a, (i + 1 < arr.Length - 1) ? arr[i + 1] : Int32.MinValue, (i + 2 < arr.Length - 1) ? arr[i + 2] : Int32.MinValue);
            int min = GetMin(arr[i], (i + 1 < arr.Length - 1) ? arr[i + 1] : Int32.MaxValue, (i + 2 < arr.Length - 1) ? arr[i + 2] : Int32.MaxValue);
            int secondHighest = Int32.MinValue;

            if (arr[i] != min && arr[i] != highest)
            {
                secondHighest = arr[i];
            }
            else if (i + 1 < arr.Length && arr[i + 1] != min && arr[i + 1] != highest)
            {
                secondHighest = arr[i + 1];
            }
            else if (i + 2 < arr.Length && arr[i + 2] != min && arr[i + 2] != highest)
            {
                secondHighest = arr[i + 2];
            }

            if (i % 2 == 0)
            {
                arr[i] = min;
                if (i + 1 < arr.Length) arr[i + 1] = highest;
                if (i + 2 < arr.Length) arr[i + 2] = secondHighest;
            }
            else
            {
                arr[i] = highest;
                if (i + 1 < arr.Length) arr[i + 1] = min;
                if (i + 2 < arr.Length) arr[i + 2] = secondHighest;
            }

        }


    }

    private static int GetMin(int a = Int32.MaxValue, int b = Int32.MaxValue, int c = Int32.MaxValue)
    {
        int min = Int32.MaxValue;

        if (a < min)
        {
            min = a;
        }
        if (b < min)
        {
            min = b;
        }
        if (c < min)
        {
            min = c;
        }

        return min;

    }

    public static int GetHighest(int a = Int32.MinValue, int b = Int32.MinValue, int c = Int32.MinValue)
    {
        int highest = Int32.MinValue;

        if (a > highest)
        {
            highest = a;
        }
        if (b > highest)
        {
            highest = b;
        }
        if (c > highest)
        {
            highest = c;
        }

        return highest;

    }

    public static int[] ReArrangeWithMaxMinAlternate(int[] arr)
    {
        int i = 0;
        int j = arr.Length - 1;
        int m = 0;

        int[] outputArr = new int[arr.Length];

        while (i <= j)
        {
            outputArr[m++] = arr[j--];
            outputArr[m++] = arr[i++];
        }

        return outputArr;
    }

    public static int FindKthMergedElement(int[] arr1, int[] arr2, int k)
    {
        int i = 0;
        int j = 0;

        while (i <= arr1.Length - 1 && j <= arr2.Length - 1)
        {
            if (i + j == k - 1) return Math.Min(arr1[i], arr2[j]);
            if (arr1[i] < arr2[j])
            {
                i++;
            }
            else
            {
                j++;
            }
        }

        while (i < arr1.Length - 1)
        {
            if (i == k - 1) return arr1[i];
            i++;
        }

        while (j < arr2.Length - 1)
        {
            if (j == k - 1) return arr2[j];
        }

        return -1;

    }

    public static int MinimumNoOfPlatforms(int[] arrivalTimes, int[] departureTimes)
    {
        List<int> departureListOfTrainsPresent = new List<int>();
        int minPlatforms = int.MinValue;

        for (int i = 0; i < arrivalTimes.Length; i++)
        {
            if (departureListOfTrainsPresent.Count == 0)
            {
                departureListOfTrainsPresent.Add(departureTimes[i]);
            }
            else
            {
                List<int> itemsToBeRemoved = new List<int>();
                foreach (var item in departureListOfTrainsPresent)
                {
                    if (arrivalTimes[i] > item)
                    {
                        itemsToBeRemoved.Add(item);
                    }
                }
                departureListOfTrainsPresent.RemoveAll(x => itemsToBeRemoved.Contains(x));
                departureListOfTrainsPresent.Add(departureTimes[i]);
            }

            minPlatforms = Math.Max(minPlatforms, departureListOfTrainsPresent.Count);
        }

        return minPlatforms;
    }

    public static string ArrangeMaximumSum(string[] stringOfNumbers)
    {
        List<Number> numbers = new List<Number>();
        foreach (var number in stringOfNumbers)
        {
            numbers.Add(new Number(number));
        }

        numbers.Sort();
        return string.Join("", numbers);
    }

    public class Number : IComparable<Number>
    {
        public string Value { get; set; }

        public Number(string value)
        {
            Value = value;
        }

        public int CompareTo(Number? other)
        {
            string first = this.Value + other.Value;
            string second = other.Value + this.Value;
            return second.CompareTo(first);
        }

        public override string ToString()
        {
            return Value;
        }
    }

    public static List<Tuple<int, int, int>> ThreeNumberSum(int[] numbers, int target)
    {
        // Step 1: Create a dictionary to store expected numbers and their corresponding pairs
        Dictionary<int, List<Tuple<int, int>>> keyValuePairs = new Dictionary<int, List<Tuple<int, int>>>();
        List<Tuple<int, int, int>> resultTuples = new List<Tuple<int, int, int>>();

        // Step 2: Populate the dictionary with all possible pairs (a, b) and their expected numbers
        for (int i = 0; i < numbers.Length - 1; i++)
        {
            for (int j = i + 1; j < numbers.Length; j++)
            {
                int expectedNumber = target - (numbers[i] + numbers[j]);

                if (!keyValuePairs.ContainsKey(expectedNumber))
                {
                    keyValuePairs[expectedNumber] = new List<Tuple<int, int>>();
                }

                keyValuePairs[expectedNumber].Add(Tuple.Create(numbers[i], numbers[j]));
            }
        }

        // Step 3: Iterate through the array to find triplets
        for (int k = 0; k < numbers.Length; k++)
        {
            if (keyValuePairs.ContainsKey(numbers[k]))
            {
                foreach (var pair in keyValuePairs[numbers[k]])
                {
                    // Ensure the triplet uses distinct elements
                    if (pair.Item1 != numbers[k] && pair.Item2 != numbers[k])
                    {
                        resultTuples.Add(Tuple.Create(numbers[k], pair.Item1, pair.Item2));
                    }
                }
            }
        }

        return resultTuples;

    }

    public static (int, int) LargestSetOfIntegars(int[] numbers)
    {
        HashSet<int> uniqueElements = new HashSet<int>();
        if (numbers.Length == 0)
        {

            return (-1, -1);
        }
        var pairedTuples = Tuple.Create(numbers[0], numbers[0]);

        foreach (int number in numbers)
        {
            uniqueElements.Add(number);
        }

        for (int i = 1; i < numbers.Length - 1; i++)
        {
            if (numbers[i] >= pairedTuples.Item1 && numbers[i] <= pairedTuples.Item2)
            {
                continue;
            }

            int leftNumber = numbers[i];
            int rightNumber = numbers[i];

            while (uniqueElements.Contains(leftNumber - 1)) leftNumber--;
            while (uniqueElements.Contains(rightNumber + 1)) rightNumber++;

            if (Math.Abs(rightNumber - leftNumber) > Math.Abs(pairedTuples.Item2 - pairedTuples.Item1))
            {
                pairedTuples = Tuple.Create(leftNumber, rightNumber);
            }

        }
        return (pairedTuples.Item1, pairedTuples.Item2);
    }

    public int[] MoveElementsToEnd(int[] numbers, int targetElement)
    {
        int targetOccuranceIndex = -1;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (targetOccuranceIndex == -1)
            {
                if (numbers[i] == targetElement)
                {
                    targetOccuranceIndex = i;
                    break;
                }

            }
        }

        for (int i = 0; i < numbers.Length; i++)
        {
            // Swap
            if (numbers[i] != numbers[targetOccuranceIndex])
            {
                var temp = numbers[i];
                numbers[i] = numbers[targetOccuranceIndex];
                numbers[targetOccuranceIndex] = temp;

                var startIndex = 0;

                while (startIndex < numbers.Length) {
                    if (numbers[startIndex] == targetElement)
                    {
                        targetOccuranceIndex = startIndex;
                        break;
                    }
                    startIndex++;
                }

            }

        }
        return numbers;
    }

    public bool IsMonotonicArray(int[] numbers)
    {
        // Edge case: empty or single-element arrays are monotonic
        if (numbers.Length <= 1)
        {
            return true;
        }

        bool isNonDecreasing = true;
        bool isNonIncreasing = true;

        for (int i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] > numbers[i - 1])
            {
                // If current element is greater than previous, it can't be non-increasing
                isNonIncreasing = false;
            }
            else if (numbers[i] < numbers[i - 1])
            {
                // If current element is less than previous, it can't be non-decreasing
                isNonDecreasing = false;
            }

            // If neither is true, it's not monotonic
            if (!isNonDecreasing && !isNonIncreasing)
            {
                return false;
            }
        }

        return isNonDecreasing || isNonIncreasing;
    }


    public int GetTheLongestPeak(int[] numbers)
    {
        int maxLength = int.MinValue;    
        for (int i = 0; i < numbers.Length - 2; i++)
        {
            int k = i;
            bool isIncreasing = false;
            bool isDecreasing = false;
            bool increaseCompleted = false;
            bool decreaseCompleted = false;

            while (k < numbers.Length - 2) {

                if (numbers[k + 1] == numbers[k])
                {
                    break;
                }

                if (numbers[k+1] - numbers[k] > 0)
                {
                    if(increaseCompleted) { break; }
                    if (isIncreasing == false && isDecreasing == false)
                    {
                        isIncreasing = true;
                        k++;
                        continue;
                    }
                    else if(isDecreasing == true)
                    {
                        decreaseCompleted = true;
                        isIncreasing = true;
                        k++;
                        continue;
                    }
                }
                else if (numbers[k+1] - numbers[k] < 0)
                {
                    if(decreaseCompleted) { break; }
                    if(isIncreasing == true && isDecreasing == false)
                    {
                        increaseCompleted = true;
                        isDecreasing = true;
                        k++;
                        continue;
                    }

                    if(isIncreasing == false)
                    {
                        isDecreasing=true;
                        k++;
                        continue ;
                    }
                }
            
            }

            maxLength = Math.Max(maxLength, k-i);

        }

        return maxLength;
    }
}


