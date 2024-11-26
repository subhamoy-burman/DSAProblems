using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALibs
{
    public class MatrixSets
    {

        public static List<int> SpiralTraversal(int[,] inputMatrix)
        {
            List<int> result = new List<int>();

            int rowStart = 0;
            int colStart = 0;
            int rowEnd = inputMatrix.GetLength(0) - 1;
            int colEnd = inputMatrix.GetLength(1) - 1;


            while (rowStart <= rowEnd && colStart <= colEnd)
            {
                if (colStart <= colEnd)
                {
                    for (int i = colStart; i <= colEnd; i++)
                    {
                        result.Add(inputMatrix[rowStart, i]);
                    }
                    rowStart++;
                }

                if (rowStart <= rowEnd)
                {
                    for (int i = rowStart; i <= rowEnd; i++)
                    {
                        result.Add(inputMatrix[i, colEnd]);
                    }
                    colEnd--;
                }

                if (colStart <= colEnd && rowStart<=rowEnd)
                {
                    for (int i = colEnd; i >= colStart; i--)
                    {
                        result.Add(inputMatrix[rowEnd, i]);
                    }
                    rowEnd--;
                }

                if (rowStart <= rowEnd && colStart<=colEnd)
                {
                    for (int i = rowEnd; i >= rowStart; i--)
                    {
                        result.Add(inputMatrix[i, colStart]);
                    }
                    colStart++;
                }

            }


            return result;

        }
    }
}
