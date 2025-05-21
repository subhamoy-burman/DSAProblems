using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALibs
{
    public class RecursionProblems
    {

        public List<List<int>> GetPermutations(int[] inputArr)
        {

            List<List<int>> permCollection = new List<List<int>>();
            List<int> perm = new List<int>();
            Permutations(inputArr, perm, permCollection);
            return permCollection;
        }

        private void Permutations(int[] inputArr, List<int> perm, List<List<int>> permCollection)
        {
            if (perm.Count == 3)
            {
                permCollection.Add([.. perm]);
            }

            for (int i = 0; i < inputArr.Length; i++)
            {

                if (perm.Contains(inputArr[i]))
                {
                    continue;
                }
                perm.Add(inputArr[i]);
                Permutations(inputArr, perm, permCollection);
                perm.Remove(inputArr[i]);
            }
        }

        //Powerset

        public List<List<int>> PowerSets(int[] inputArr)
        {

            List<List<int>> result = new List<List<int>>();
            List<int> localList = new List<int>();
            int startIndex = 0;

            PreparePowerSets(inputArr, result, localList, startIndex);
            return result;
        }

        private void PreparePowerSets(int[] inputArr, List<List<int>> result, List<int> localList, int startIndex)
        {
            if (startIndex == inputArr.Length)
            {
                result.Add(new List<int>(localList));
                return;
            }

            localList.Add(inputArr[startIndex]);
            PreparePowerSets(inputArr, result, localList, startIndex + 1);
            localList.Remove(inputArr[startIndex]);
            PreparePowerSets(inputArr, result, localList, startIndex + 1);

        }

        public bool IsInterleavedString(string input1, string input2, string target)
        {
            string result = string.Empty;
            GenerateInterleavingString(input1, 0, input2, 0, target, result);
        }

        private void GenerateInterleavingString(string input1, int index1, string input2, int index2, string target, string result)
        {
            while (index1 < input1.Length && index2 < input2.Length) { 
            
                result += input1[index1];
                result += input2[index2];
                GenerateInterleavingString(input1, index1 + 1, input2, index2 + 1, target, result);


            }

        }
    }
}
