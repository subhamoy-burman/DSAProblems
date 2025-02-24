using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALibs
{
    public static class StackProblems
    {
        public class MinMaxStack
        {
            public int StackElement { get; set; }
            public int MinElement { get; set; } = int.MaxValue;
            public int MaxElement { get; set; } = int.MinValue;

            public Stack<Tuple<int, int, int>> MiniMaxStack { get; set; } = new Stack<Tuple<int, int, int>>();

            public void Push(int stackElement)
            {
                if (stackElement > MaxElement)
                    MaxElement = stackElement;
                if (stackElement < MinElement)
                    MinElement = stackElement;

                var tuple = new Tuple<int, int, int>(stackElement, MaxElement, MinElement);

                MiniMaxStack.Push(tuple);
            }

            public int Pop()
            {

                return MiniMaxStack.Pop().Item1;
            }

            public int GetMax()
            {
                return MiniMaxStack.Peek().Item2;
            }

            public int GetMin()
            {

                return MiniMaxStack.Peek().Item3;
            }
        }

        //path = "/foo/../test/../test/../foo//bar/./baz"
        public static string PathOutput(string inputPath)
        {
            var inputPathChar = inputPath.ToCharArray();
            List<string> output = new List<string>();
            string strValue = string.Empty;

            foreach (var item in inputPathChar)
            {
                if (item != '/')
                {
                    strValue = strValue + item;
                }
                else
                {
                    output.Add(strValue);
                    strValue = string.Empty;
                    continue;
                }
            }

            output.Add(strValue);
            //string[] arrayOfOutput = inputPath.Split('/');

            Stack<string> stackOfPath = new Stack<string>();

            for (int i = output.Count - 1; i >= 0; i--)
            {

                if (output[i] == "..")
                {
                    if (stackOfPath.Count > 0) stackOfPath.Pop();
                    continue;
                }

                if (output[i] == "." || output[i].Trim() == string.Empty)
                {
                    continue;
                }

                stackOfPath.Push(output[i]);
            }

            StringBuilder pathBuilder = new StringBuilder();

            foreach (var item in stackOfPath)
            {
                pathBuilder.Append("/");
                pathBuilder.Append(item);
            }

            return pathBuilder.ToString();
        }


        public static int LargestRectangleUnderSkyline(int[] heights)
        {
            int n = heights.Length;
            if (n == 0) return 0;

            int[] left = new int[n];  // Previous smaller indices
            int[] right = new int[n]; // Next smaller indices
            Stack<int> stack = new Stack<int>();

            // Compute previous smaller elements
            for (int i = 0; i < n; i++)
            {
                while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
                {
                    stack.Pop();
                }
                left[i] = stack.Count == 0 ? -1 : stack.Peek();
                stack.Push(i);
            }

            stack.Clear();

            // Compute next smaller elements
            for (int i = n - 1; i >= 0; i--)
            {
                while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
                {
                    stack.Pop();
                }
                right[i] = stack.Count == 0 ? n : stack.Peek();
                stack.Push(i);
            }

            // Calculate max area
            int maxArea = 0;
            for (int i = 0; i < n; i++)
            {
                int width = right[i] - left[i] - 1;
                maxArea = Math.Max(maxArea, heights[i] * width);
            }

            return maxArea;
        }

        public static int LargestPossibleNumber(string stringOfDigits, int numOfDigits)
        {
            Stack<int> stackOfNumbers = new Stack<int>();
            stackOfNumbers.Push(stringOfDigits[0] - '0');

            for (int i = 1; i < stringOfDigits.Length; i++) {

                int arrayNum = stringOfDigits[i] - '0';
                while (stackOfNumbers.Count>0 && arrayNum > stackOfNumbers.Peek() && numOfDigits>0)
                {
                    stackOfNumbers.Pop();
                    numOfDigits--;
                }
                stackOfNumbers.Push(arrayNum - '0');
            }

            // Remove remaining digits from the end if needed
            while (numOfDigits > 0 && stackOfNumbers.Count > 0)
            {
                stackOfNumbers.Pop();
                numOfDigits--;
            }

            int num = stackOfNumbers.Pop();
            int power = 1;

            while (stackOfNumbers.Count > 0)
            {
                num = num + Convert.ToInt32(stackOfNumbers.Pop()*Math.Pow(10,power));
                power++;
            }

            return num;
        }
    }
}
