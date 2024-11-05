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
    }
}
