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


        /// <summary>
        /// Converting Roman to Numeric
        /// Not working right now
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ConvertRomanNumberStringToNumeric(string str)
        {

            Dictionary<string, int> characterNumeralkeyValuePairs = new Dictionary<string, int>()
            {
                { "I", 1 },
                { "II",2 },
                { "III",3},
                { "IV", 4 },
                { "V", 5 },
                { "VI", 6 },
                { "VII", 7 },
                { "VIII", 8 },
                { "IX", 9 },
                { "X", 10 },
                { "L", 50},
                { "C", 100 },
                { "D", 500 },
                { "M", 1000 }

            };

            int previousNumer = int.MinValue;
            int result = 0;

            if(str.Length == 1)
            {
                return characterNumeralkeyValuePairs[str];
            }

            for(int i = 0; i <str.Length; i++)
            {
                int currentNumber = characterNumeralkeyValuePairs[str[i].ToString()];

                if(previousNumer!= int.MinValue)
                {
                    if (previousNumer >= currentNumber)
                    {
                        result = result + currentNumber;
                        previousNumer = currentNumber;
                        continue;
                    }
                    else 
                    { 
                        result = result - currentNumber;
                        previousNumer = currentNumber;
                        continue;
                    }
                }
                result = currentNumber;
                previousNumer = currentNumber;
            }

            return result;
        }
    }

    
}
