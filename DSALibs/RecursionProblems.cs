using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALibs
{
    public class RecursionProblems
    {

        public List<List<int>> GetPermutations(int[] inputArr) { 
        
            List<List<int>> permCollection = new List<List<int>>();
            List<int> perm = new List<int>();
            Permutations(inputArr, perm,  permCollection);
            return permCollection;
        }

        private void Permutations(int[] inputArr, List<int> perm, List<List<int>> permCollection)
        {
            if(perm.Count == 3)
            {
                permCollection.Add([.. perm]);
            }

            for (int i = 0; i < inputArr.Length; i++) { 
            
                if(perm.Contains(inputArr[i]))
                {
                    continue;
                }
                perm.Add(inputArr[i]);
                Permutations(inputArr, perm, permCollection);
                perm.Remove(inputArr[i]);
            }
        }

        //Powerset
    }
}
