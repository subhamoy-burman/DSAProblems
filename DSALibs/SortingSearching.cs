using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DSALibs
{
    public class SortingSearching
    {

        public static int[] PerformQuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
            return array;
        }
        private static void QuickSort(int[] array, int start, int end)
        {
            if (start <= end)
            {
                int pivot = array[end];

                int i = start - 1;

                for (int j = start; j < end; j++)
                {
                    if (array[j] < pivot)
                    {
                        i = i + 1;
                        swap(array, i, j);
                    }
                }
                swap(array, i + 1, end);

                QuickSort(array, start, i);
                QuickSort(array, i + 2, end);

            }
        }

        private static void swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }


        public static int FindKthSmallestElement(int[] arr, int k)
        {
            var maxHeapComparer = Comparer<int>.Create((x, y) => y.CompareTo(x));
            PriorityQueue<int, int> priorityQueue = new PriorityQueue<int, int>(maxHeapComparer);


            foreach (var item in arr)
            {
                if (priorityQueue.Count == k)
                {
                    if (item < priorityQueue.Peek())
                    {
                        priorityQueue.Enqueue(item, item);
                    }
                    else
                    {
                        continue;
                    }

                }
                else
                {
                    priorityQueue.Enqueue(item, item);
                }
            }

            return priorityQueue.Dequeue();
        }

        public (int, int) SearchInSortedMatrix(int[,] arr, int target)
        {
            int rowLength = arr.GetLength(0);
            int columnLength = arr.GetLength(1);
            int possibleRow = -1;

            for (int i = 0; i < rowLength; i++)
            {
                if (target >= arr[i, 0] && target <= arr[i, columnLength-1])
                {
                    possibleRow = i;
                    break;
                }
            }

            if (possibleRow == -1)
            {
                return (-1, -1);
            }


            int start = 0;
            int end = columnLength-1;

            while (start < end) {
                int mid = start + (end - start) / 2;

                if (arr[possibleRow, mid] == target) { 
                
                    return (possibleRow, mid);
                }
                if (arr[possibleRow, mid] > target)
                {
                    end = mid - 1;
                }
                else if (arr[possibleRow, end] < target)
                {
                    start = mid + 1;
                }
            }

            return (-1, -1);
        }
    }
}
