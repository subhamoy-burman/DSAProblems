﻿using System.Runtime.CompilerServices;

namespace DSALibs;

public class Arrays
{
    public static void ReArrangeToZigZag(int[] arr)
    {
        for(int i=0;i<arr.Length;i=i+3)
        {
            int a = arr[i];
            

            int highest = GetHighest(a, (i+1<arr.Length-1)?arr[i+1]:Int32.MinValue, (i+2<arr.Length-1)?arr[i+2]:Int32.MinValue);
            int min = GetMin(arr[i], (i+1<arr.Length-1)?arr[i+1]:Int32.MaxValue, (i+2<arr.Length-1)?arr[i+2]:Int32.MaxValue);
            int secondHighest = Int32.MinValue;

            if(arr[i] != min && arr[i] != highest)
            {
                secondHighest = arr[i];
            }
            else if(i+1 < arr.Length && arr[i+1] != min && arr[i+1] != highest)
            {
                secondHighest = arr[i+1];
            }
            else if(i+2< arr.Length && arr[i+2]!= min && arr[i+2] != highest)
            {
                secondHighest = arr[i+2];
            }

            if(i%2 == 0)
            {
                arr[i] = min;
                if(i+1 < arr.Length) arr[i+1] = highest;
                if(i+2 < arr.Length) arr[i+2] = secondHighest;
            }
            else
            {
                arr[i] = highest;
                if(i+1 < arr.Length) arr[i+1] = min;
                if(i+2 < arr.Length)arr[i+2] = secondHighest;
            } 

        }

        
    }

    private static int GetMin(int a = Int32.MaxValue, int b = Int32.MaxValue, int c = Int32.MaxValue)
    {
        int min = Int32.MaxValue;

        if(a<min)
        {
            min = a;
        }
        if(b<min)
        {
            min = b;
        }
        if(c<min)
        {
            min = c;
        }

        return min;

    }

    public static int GetHighest(int a = Int32.MinValue, int b = Int32.MinValue, int c = Int32.MinValue)
    {
        int highest = Int32.MinValue;

        if(a>highest)
        {
            highest = a;
        }
        if(b>highest)
        {
            highest = b;
        }
        if(c>highest)
        {
            highest = c;
        }

        return highest;

    }

    public static int[] ReArrangeWithMaxMinAlternate(int[] arr)
    {
        int i=0;
        int j = arr.Length-1;
        int m = 0;

        int[] outputArr = new int[arr.Length];

        while(i<=j)
        {
            outputArr[m++] = arr[j--];
            outputArr[m++] = arr[i++];
        }

        return outputArr;
    }

    public static int FindKthMergedElement(int[] arr1, int[] arr2, int k)
    {   
        int i=0;
        int j=0;

        while(i<=arr1.Length-1 && j<=arr2.Length-1)
        {
            if(i+j == k-1) return Math.Min(arr1[i], arr2[j]);
            if(arr1[i] < arr2[j])
            {
                i++;
            }
            else
            {
                j++;
            }
        }

        while(i<arr1.Length-1)
        {
            if(i == k-1) return arr1[i];
            i++;
        }

        while(j<arr2.Length-1)
        {
            if(j == k-1) return arr2[j];
        }

        return -1;

    }

    public static int MinimumNoOfPlatforms(int[] arrivalTimes, int[] departureTimes)
    {
        List<int> departureListOfTrainsPresent = new List<int>();
        int minPlatforms = int.MinValue;

        for(int i=0; i<arrivalTimes.Length; i++)
        {
            if(departureListOfTrainsPresent.Count == 0)
            {
                departureListOfTrainsPresent.Add(departureTimes[i]);
            }
            else
            {
                List<int> itemsToBeRemoved = new List<int>();
                foreach(var item in departureListOfTrainsPresent)
                {
                    if(arrivalTimes[i]>item)
                    {
                        itemsToBeRemoved.Add(item);
                    }
                }
                departureListOfTrainsPresent.RemoveAll(x=>itemsToBeRemoved.Contains(x));
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
        return string.Join("",numbers);
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

}
