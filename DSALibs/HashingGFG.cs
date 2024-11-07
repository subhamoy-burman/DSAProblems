using System;
using System.Collections.Generic;
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

                if(findIndexOfElementInArr1 < 0) continue;
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
                    if (mid!=0 && arr[mid - 1] < v)
                    {
                        return mid;
                    }
                    else { 
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
    }
}
