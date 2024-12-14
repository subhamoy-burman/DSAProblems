using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

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
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ConvertRomanNumberStringToNumeric(string str)
        {

            Dictionary<char, int> characterNumeralkeyValuePairs = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            int result = 0;

            if(str.Length == 1)
            {
                return characterNumeralkeyValuePairs[str.ToCharArray()[0]];
            }
            /*
             *  M (1000) - No pair yet, so add 1000.
                CM (1000 - 100 = 900) - Subtract 100 from 1000.
                MCM (1000 + 900 = 1900) - Add the result of CM to M.
                IV (5 - 1 = 4) - Subtract 1 from 5.
                MCMIV (1900 + 4 = 1904) - Add the result of IV to MCM.
            */
            int index = 0;
            while(index <str.Length)
            {
                int firstLetterValue = characterNumeralkeyValuePairs[str[index]];
                if (index + 1 < str.Length)
                {
                    int secondLetterValue = characterNumeralkeyValuePairs[str[index + 1]];
                    if (secondLetterValue > firstLetterValue)
                    {
                        result = result + (secondLetterValue - firstLetterValue);
                        index = index + 2;
                    }
                    else
                    {
                        result = result + firstLetterValue;
                        index = index + 1;

                    }
                    
                }
                else
                {
                    result = result + firstLetterValue;
                    index =  index + 1;
                }
            }

            return result;
        }

        public static int FindLongestSubstringWithoutRepeatingCharacter(string str)
        {
            int resultLength = int.MinValue;
            int startIndex = 0;

            int index = 0;
            Dictionary<char,int> charIndexes = new Dictionary<char,int>();

            while (index < str.Length) {
                if (charIndexes.ContainsKey(str[index]))
                {
                    if (charIndexes[str[index]] >= startIndex)
                    {
                        resultLength = Math.Max(index - startIndex, resultLength);
                        startIndex = charIndexes[str[index]] + 1;
                        charIndexes[str[index]] = index;
                    }
                    else
                    {
                        charIndexes[str[index]] = index;
                    }
                }
                else 
                { 
                    charIndexes.Add(str[index], index);
                }
                index++;
            }

            return Math.Max (resultLength, str.Length - startIndex);
        }

        static int max_length = Int32.MinValue;
        public static string LongestPalindrome(string str)
        {
            List<string> listOfSubstrings = new List<string>();
            for (int i = 0; i < str.Length; i++)
            {
                GenerateSubstring(i, str, listOfSubstrings);
            }
            return listOfSubstrings.OrderByDescending(x=>x.Length).FirstOrDefault()!;
        }

        private static void GenerateSubstring(int i, string str, List<string> listOfSubstrings)
        {
            var listOfSub = new List<string>();
            for (int j = i; j < str.Length; j++) { 

                var subString = str.Substring(i, j-i +1);
                if (isPalindrome(subString))
                {
                    max_length = Math.Max(max_length, j - i + 1);
                    listOfSub.Add(str.Substring(i, j - i +1));
                }
            }

            listOfSubstrings.AddRange(listOfSub);
        }

        private static bool isPalindrome(string subString)
        {
            var strLength = subString.Length;
            int i = 0;
            int j = strLength - 1;

            while (i <= j)
            {
                if (subString[i] != subString[j])
                {
                    return false;
                }
                i++;
                j--;
            }
            return true;
        }

        public static string LongestPlaindromeImproved(string str)
        {
            int[] longest = new int[2] { -1,-1};
            int[] oddStartEnd = new int[2];
            int[] evenStartEnd = new int[2];
            for (int i = 1; i< str.Length; i++)
            {
                oddStartEnd = GeneratePalindrome(str, i - 1, i);
                evenStartEnd = GeneratePalindrome(str, i - 1, i + 1);

                int oddlength = oddStartEnd[1] - oddStartEnd[0];
                int evenLength = evenStartEnd[1] - evenStartEnd[0];
                var currentLongest = oddlength > evenLength ? oddStartEnd : evenStartEnd;
                if (longest[1] - longest[0] < currentLongest[1] - currentLongest[0])
                {
                    longest = currentLongest;
                }
            }

            return str.Substring(longest[0], longest[1] - longest[0]+1);
        }

        private static int[] GeneratePalindrome(string str, int index1, int index2)
        {
            int[] indexes = new int[2] { -1,-1};
            while (index1 >= 0 && index2 < str.Length)
            {
                if(str[index1] != str[index2])
                {
                    break;
                }
                indexes[0] = index1;
                indexes[1] = index2;
                index1--;
                index2++;
            }
            return indexes;
        }


        public static string LongestSubstringWithoutDuplication(string str)
        {
            Dictionary<char,int> charIndexPairs = new Dictionary<char,int>();

            int startIndex = 0;
            int[] longest = {0,0};
            int[] startEnd = {0,0};

            if (str.Length == 0) { return str; }

            for(int i =0; i< str.Length; i++)
            {
                char c = str[i];
                startEnd = new int[] { startIndex, i };

                if (charIndexPairs.ContainsKey(c) && charIndexPairs[c] > startIndex)
                {
                    startEnd = new int[] { startIndex, i - 1 };
                    startIndex = charIndexPairs[c] + 1;
                    if (startEnd[1] - startEnd[0] > longest[1] - longest[0])
                    {
                        longest = startEnd;
                    }
                }

                charIndexPairs[c] = i;
            }

            if (startEnd[1] - startEnd[0] > longest[1] - longest[0])
            {
                longest = startEnd;
            }

            return str.Substring(longest[0], longest[1] - longest[0] + 1);
        }

        /// <summary>
        /// Pattern matching and under scoring
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UnderScorifySubstring(string str)
        {
            return string.Empty;
        }
    }
    
}
