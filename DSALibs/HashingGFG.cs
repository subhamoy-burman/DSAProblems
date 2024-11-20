using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DSALibs
{
    public class HashingGFG
    {
        public static int CountPowerPairs(int[] arr1, int[] arr2)
        {
            Array.Sort(arr1);
            Array.Sort(arr2);

            int count = 0;

            for (int i = 0; i < arr2.Length; i++)
            {
                int findIndexOfElementInArr1 = FindIndexOfElementInArr2(arr2[i], arr1);

                if (findIndexOfElementInArr1 < 0) continue;
                count = count + findIndexOfElementInArr1;
            }

            return count;
        }

        private static int FindIndexOfElementInArr2(int v, int[] arr)
        {

            int low = 0;
            int high = arr.Length - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (arr[mid] == v)
                {
                    return mid + 1;
                }
                else if (arr[mid] > v)
                {
                    if (mid != 0 && arr[mid - 1] < v)
                    {
                        return mid;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
                else
                {
                    low = mid + 1;
                }
            }

            return -1;
        }

        /*Given an array of size N and an integer K, return the count of distinct numbers in all windows of size K. 

        Examples: 

        Input: arr[] = {1, 2, 1, 3, 4, 2, 3}, K = 4
        Output: 3 4 4 3
        Explanation: First window is {1, 2, 1, 3}, count of distinct numbers is 3
                              Second window is {2, 1, 3, 4} count of distinct numbers is 4
                              Third window is {1, 3, 4, 2} count of distinct numbers is 4
                              Fourth window is {3, 4, 2, 3} count of distinct numbers is 3


        Input: arr[] = {1, 2, 4, 4}, K = 2
        Output: 2 2 1
        Explanation: First window is {1, 2}, count of distinct numbers is 2
                              First window is {2, 4}, count of distinct numbers is 2
                              First window is {4, 4}, count of distinct numbers is 1*/


        /// <summary>
        /// Given an array of integers and a number k, write a function that returns true if the given array can be divided 
        /// into pairs such that the sum of every pair is divisible by k.
        /// Input: arr[] = {9, 7, 5, 3}, k = 6 
        ///Output: Truee the array into(9, 3) and(7, 5). Sum of both of these pairs is a multiple of 6.
        ///Input: arr[] = {92, 75, 65, 48, 45, 35}, k = 10 
        ///Output: True
        ///We can divide the array into(92, 48), (75, 65) and(45, 35). The sum of all these pairs are multiples of 10.


        /// Input: arr[] = {91, 74, 66, 48}, k = 10 
        /// Output: False
        /// </summary>
        /// <param name="inputArray"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static List<int> FindDistinctElementsInKSizedWindows(int[] inputArray, int k)
        {
            Dictionary<int,int> elements = new Dictionary<int, int>();

            List<int> result = new List<int>();

            int distinctCount = 0;
            for (int i = 0; i < k; i++)
            {
                if (elements.ContainsKey(inputArray[i]))
                {   
                    elements[inputArray[i]] = elements[inputArray[i]] + 1;
                }
                else
                {
                    elements[inputArray[i]] = 1;
                    distinctCount++;
                }

            }

            result.Add(distinctCount);

            for (int i = 1; i <= inputArray.Length-k; i++)
            {
                if(elements.ContainsKey(inputArray[i-1]))
                {
                    elements[inputArray[i-1]] = elements[inputArray[i-1]] - 1;
                    if (elements[inputArray[i - 1]] == 0)
                    {
                        elements.Remove(inputArray[i - 1]);
                        distinctCount--;
                    }
                }

                if (elements.ContainsKey(inputArray[i+k-1]))
                {   
                    elements[inputArray[i + k -1]] = elements[inputArray[i + k - 1]] + 1;
                }
                else
                {
                    elements[inputArray[i + k - 1]] = 1;
                    distinctCount++;
                }

                result.Add(distinctCount);
            }

            return result;


        }


        public static bool CheckIfArrayPairSumDivisibleByK(int[] inputArray, int k)
        {
            Dictionary<int,int> result = new Dictionary<int,int>();
            int index = 1;
            foreach (var item in inputArray)
            {
                if (!result.ContainsKey(k - item % k))
                {
                    result.Add(k - item % k, index++);
                }
            }

            for(int i = 0; i<inputArray.Length; i++)
            {
                if (!result.ContainsKey(inputArray[i] %k) && result[inputArray[i]]!= i)
                {
                    return false;    
                }
            }

            return true;
        }


        /*Given an array arr[] of size n, the task is to print all subarrays in the array which has sum 0.

            Examples: 

            Input: arr = [6, 3, -1, -3, 4, -2, 2, 4, 6, -12, -7]
            Output:


            Subarray found from Index 2 to 4
            Subarray found from Index 2 to 6
            Subarray found from Index 5 to 6
            Subarray found from Index 6 to 9
            Subarray found from Index 0 to 10
            Input: arr = [1, 2, -3, 3, -1, -1]
            Output:


            Subarray found from Index 0 to 2
            Subarray found from Index 2 to 3
            Subarray found from Index 3 to 5
        */

        public static int CountSubArraysWithSumZero(int[] inputArray)
        {

            Dictionary<int,int> keyCounts = new Dictionary<int,int>();

            int totalCount = 0;

            keyCounts.Add(0, 1);
            int sumSoFar = 0;

            for (int i = 0; i < inputArray.Length; i++) {

                sumSoFar += inputArray[i];
                if (keyCounts.ContainsKey(sumSoFar))
                {
                    totalCount = totalCount + keyCounts[sumSoFar];
                    keyCounts[sumSoFar] = keyCounts[sumSoFar] + 1;
                }
                else
                {
                    keyCounts.Add(sumSoFar, 1);
                }
            } 

            return totalCount;
        }

        public class EqualList<T> : List<T>, IComparable<T>
        {
            public int CompareTo(T? other)
            {
                throw new NotImplementedException();
            }
        }
    }
}
