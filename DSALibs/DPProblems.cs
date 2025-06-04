using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALibs
{
    internal class DPProblems
    {

        /// <summary>
        /// This is wrong implementation
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public static int EditDistance(string str1, string str2)
        {
            var strArr1 = str1.ToArray();
            Array.Sort(strArr1);

            var strArr2 = str2.ToArray();
            Array.Sort(strArr2);
            return EditDistanceFunc(strArr1, strArr2, 0, 0);
        }

        private static int EditDistanceFunc(char[] str1, char[] str2, int index1, int index2)
        {
            if (index1 >= str1.Length && index2 >= str2.Length)
            {
                return 0;
            }

            if (index1 < str1.Length && index2 < str2.Length)
            {
                if (str1[index1] == str2[index2])
                {
                    return EditDistanceFunc(str1, str2, index1 + 1, index2 + 1);
                }
                else
                {
                    return 1 + EditDistanceFunc(str1, str2, index1 + 1, index2 + 1);
                }
            }

            if (index1 < str1.Length)
            {
                return 1 + EditDistanceFunc(str1, str2, index1 + 1, index2);
            }
            else
            {
                return 1 + EditDistanceFunc(str1, str2, index1, index2 + 1);
            }
        }

        public static int EditDistanceImplementation(string str1, string str2)
        {
            return EditDistanceImplementationFunc(str1, str2, str1.Length, str2.Length);
        }

        private static int EditDistanceImplementationFunc(string str1, string str2, int index1, int index2)
        {
            if(index2 == 0)
                return index1;
            if(index1 == 0)
                return index2;

            if (str1[index1 - 1] == str2[index2 - 1])
            {
                return EditDistanceImplementationFunc(str1, str2, index1 - 1, index2 - 1);
            }
            else
            {
                return
                    Math.Min(
                        1 + EditDistanceImplementationFunc(str1, str2, index1 - 1, index2 - 1), // Replace
                            Math.Min(1 + EditDistanceImplementationFunc(str1, str2, index1 - 1, index2), // Delete
                                    1 + EditDistanceImplementationFunc(str1, str2, index1, index2 - 2))); //Insert
            }
        }
    }
}
