using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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

        public class EqualList<T> : List<T>, IComparable<T>
        {
            public int CompareTo(T? other)
            {
                throw new NotImplementedException();
            }
        }
    }
}
