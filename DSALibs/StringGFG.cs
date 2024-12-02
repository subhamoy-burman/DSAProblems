using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALibs
{
    public class StringGFG
    {
        public static bool IsRotatedByTwoPlaces(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }

            bool isLastTwoCharacterRotated = true;

            for(int i = 0; i< str2.Length; i++)
            {
                if (str2[i] != str1[(i + 2) % (str2.Length)])
                {
                    isLastTwoCharacterRotated = false;
                    break;
                }
            }

            if (isLastTwoCharacterRotated) { return true; }

            bool isFirstTwoCharacterRotated = true;

            for (int i = 0; i < str2.Length; i++)
            {
                if(str1[i] != str2[(i+2) % (str2.Length)])
                {
                    isLastTwoCharacterRotated = false;
                    break;
                }

            }


             return isLastTwoCharacterRotated || isFirstTwoCharacterRotated;
        }
    }
}
