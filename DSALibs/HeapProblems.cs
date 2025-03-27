using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALibs
{
    public class HeapProblems
    {
        public int[] CreateMinHeap(int[] inputArr)
        {
            int length = inputArr.Length;

            for (int i = length / 2 - 1; i >= 0; i--)
            {
                Heapify(inputArr, i);
            }

            return inputArr;
        }

        private void Heapify(int[] inputArr, int i)
        {
            int leftIndex = 2 * i + 1;
            int rightIndex = 2 * i + 2;

            //Find the smallest index among these 3

            int smallestIndex = i;

            if (leftIndex < inputArr.Length && inputArr[smallestIndex] > inputArr[leftIndex]) 
            { 
                smallestIndex = leftIndex;
            }

            if (rightIndex < inputArr.Length && inputArr[smallestIndex] > inputArr[rightIndex])
            {
                smallestIndex = rightIndex;
            }

            if (smallestIndex != i)
            {
                var temp = inputArr[smallestIndex];
                inputArr[smallestIndex] = inputArr[i];
                inputArr[i] = temp;
                Heapify(inputArr, smallestIndex);
            }

        }

        private int[] InsertInMinHeap(int[] inputArr, int element)
        {
            int length = inputArr.Length;
            int[] resultArray = new int[length + 1];

            for (int i = 0; i < length; i++) { 
            
                resultArray[i] = inputArr[i];
            }
            resultArray[length] = element;

            HandleHeapInsertion(resultArray, resultArray.Length - 1);
            return resultArray;

        }

        private void HandleHeapInsertion(int[] arr, int finalIndex)
        {
            if (finalIndex <= 0) return;
            var parentIndex = (finalIndex - 1) / 2;
            if (arr[parentIndex] > arr[finalIndex]) {

                int temp = arr[parentIndex];
                arr[parentIndex] = arr[finalIndex];
                arr[finalIndex] = temp;
                HandleHeapInsertion(arr, parentIndex);
            }
        }
    }
}
