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

        /// <summary>
        /// This logic won't work
        /// Unit TC are failing
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="element"></param>
        /// <returns></returns>

        public static bool IsElementExistsIn2DMatrix(int[,] matrix, int element)
        {
            int dimension = matrix.GetLength(0);

            int low = 0;
            int high = dimension - 1;
            int rowIndex = -1;

            while (low <= high)
            {
                int mid = (low + high) / 2;

                if (matrix[0, mid] == element)
                {
                    return true;
                }

                if (matrix[0, mid] > element)
                {
                    high = mid - 1;
                }
                else { 
                    rowIndex = mid;
                    low = mid + 1;
                }
            }

            low = 0;
            high = dimension - 1;
            int colIndex = -1;

            while (low <= high) {

                int mid = (low + high) / 2;

                if(matrix[mid, 0] == element)
                {
                    return true;
                }

                if(matrix[mid, 0] > element)
                {
                    high = mid - 1;
                }
                else
                {
                    colIndex = mid;
                    low = mid + 1;
                }

            }

            if (matrix[rowIndex,colIndex] == element)
            {
                return true;
            }

            return false;
        }

        public static List<List<char>> GetAllPathFromTopToBottomIn2dMatrix(char[,] matrix)
        {
            List<List<char>> endResult = new List<List<char>>();

            List<char> localList = new List<char>();

            GetAllPathFunc(0,0,matrix, localList, endResult);

            return endResult;
        }

        private static void GetAllPathFunc(int i, int j, char[,] matrix, List<char> localList, List<List<char>> endResult)
        {
            if(i>=matrix.GetLength(0) || j>=matrix.GetLength(0))
            {
                return;
            }

            localList.Add(matrix[i,j]);

            if (i == matrix.GetLength(0) - 1 && j == matrix.GetLength(1) - 1)
            {
                endResult.Add(new List<char>(localList));
            }
            else 
            {
                GetAllPathFunc(i + 1, j, matrix, localList, endResult);
                GetAllPathFunc(i, j + 1, matrix, localList, endResult);
            }

            localList.RemoveAt(localList.Count - 1);

        }
    }
}
