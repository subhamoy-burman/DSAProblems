using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALibs
{
    internal class DPProblems
    {

        public static int EditDistance(string str1, string str2)
        {
            var strArr1 = str1.ToArray();
            Array.Sort(strArr1);

            var strArr2 = str2.ToArray();
            Array.Sort (strArr2);
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
                return 1 + EditDistanceFunc(str1, str2, index1, index2+1);
            }
        }
    }
}
