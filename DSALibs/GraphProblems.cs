using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSALibs
{
    public class GraphProblems
    {
        public static List<List<int>> GetAdjanceyList() { 
        
            List<List<int>> adjList = new List<List<int>>();

            // Initialize the adjacency list with empty lists for each node
            for (int i = 0; i <= 5; i++)
            {
                adjList.Add(new List<int>());
            }


            adjList[1].Add(2);
            adjList[1].Add(3);
            adjList[1].Add(5);

            adjList[2].Add(1);
            adjList[2].Add(3);
            adjList[2].Add(4);

            adjList[3].Add(1);
            adjList[3].Add(2);
            adjList[3].Add(4);
            adjList[3].Add(5);

            adjList[4].Add(2);
            adjList[4].Add(3);

            adjList[5].Add(1);
            adjList[5].Add(3);

            return adjList;

        }

        public static void DFS(int vertex, bool[] visited, List<int> dfsList)
        {
            var adjList = GetAdjanceyList();
            dfsList.Add(vertex);
            visited[vertex] = true;

            foreach (var item in adjList[vertex])
            {
                if (!visited[item])
                {
                    DFS(item, visited, dfsList);
                }
            }
        }

        public static List<int> GetDFSTraversal()
        {
            int numberOfNodes = 5;
            bool[] visited = new bool[numberOfNodes+1];
            List<int> dfsList = new List<int>();


            DFS(1, visited, dfsList);

            return dfsList;
        }

        public static bool IsCycleVisitedOnce(int[] arr)
        {
            //[2, 3, 1, -4, -4, 2]
            int targetIndex = 0;
            int[] visitedCount = new int[arr.Length];
            int count = 0;
            while(count<arr.Length) {

                visitedCount[targetIndex] = visitedCount[targetIndex]+1; //0 visited //2 visited
                targetIndex = targetIndex + arr[targetIndex]; //0 + arr[0] = 2 //2 + arr[2] = 3

                if (targetIndex < 0)
                {
                    targetIndex = (targetIndex + arr.Length) % arr.Length;
                }
                else 
                {
                    targetIndex = targetIndex%arr.Length;
                }

                count++;
            }

            foreach (var item in visitedCount) { 
            
                if(item!=1) return false;
            }

            return targetIndex == 0;
        }

        public static List<int> BFSTraversal(List<List<int>> graph)
        {
            Queue<int> stringBfsQueue = new Queue<int>();
            List<int> bfsOutput = new List<int>();
            HashSet<int> visited = new HashSet<int>();

            stringBfsQueue.Enqueue(1);
            visited.Add(1);

            while (stringBfsQueue.Count > 0)
            {
                var queueLength = stringBfsQueue.Count;

                for (int i = 0; i < queueLength; i++) {

                    var dequeuedItem = stringBfsQueue.Dequeue();
                    bfsOutput.Add(dequeuedItem);
                    foreach (var neighbour in graph[dequeuedItem])
                    {
                        if(visited.Contains(neighbour)) continue;
                        stringBfsQueue.Enqueue(neighbour);
                        visited.Add(neighbour);
                    }
                }
            }

            return bfsOutput;
        }

        /*
        You're given a two-dimensional array (a matrix) of potentially unequal height and width 
        containing only 0s and 1s. Each 0 represents land, and each 1 represents part of a river.
        A river consists of any number of 1s that are either horizontally or vertically adjacent 
        (but not diagonally adjacent). The number of adjacent 1s forming a river determine its size.

        Note that a river can twist. In other words, 
        it doesn't have to be a straight vertical line or a 
        straight horizontal line; it can be L-shaped, for example.

        Write a function that returns an array of the sizes of all rivers represented 
        in the input matrix. The sizes don't need to be in any particular order.

        Sample Input
        matrix = [
          [1, 0, 0, 1, 0],
          [1, 0, 1, 0, 0],
          [0, 0, 1, 0, 1],
          [1, 0, 1, 0, 1],
          [1, 0, 1, 1, 0],
        ]
        Sample Output
        [1, 2, 2, 2, 5] // The numbers could be ordered differently.
        */

        public static List<int> NumberOfIslands(int[,] riverLands)
        {
            int riverCount = 0;
            List<int> listOfRivers = new List<int>();
            bool[,] visited = new bool [riverLands.GetLength(0), riverLands.GetLength(1)];
            for(int i = 0; i<riverLands.GetLength(0); i++)
            {
                for(int j = 0; j< riverLands.GetLength(1); j++)
                {
                    if (!visited[i,j] && riverLands[i,j] == 1)
                    {
                        riverCount = 0;
                        ArrDFS(riverLands,i,j, visited, ref riverCount);
                        listOfRivers.Add(riverCount);
                    }
                }
            }

            return listOfRivers;
        }

        private static void ArrDFS(int[,] riverLands, int i, int j, bool[,] visited, ref int riverCount)
        {
            riverCount = riverCount + 1;
            visited[i, j] = true;
            int[] deltaRows = new int[] { 0, 0, 1, -1 };
            int[] deltaCols = new int[] { 1, -1, 0, 0 };


            for (int m = 0; m < 4; m++) { 
            
                int dx = i + deltaRows[m];
                int dy = j + deltaCols[m];

                if(dx>=0 && dy>=0 && dx<riverLands.GetLength(0) && dy<riverLands.GetLength(1))
                {
                    if (!visited[dx,dy] && riverLands[dx,dy] == 1)
                    {
                        ArrDFS(riverLands, dx, dy, visited, ref riverCount);
                    }
                }
            }
        }

        public class AncestralTree
        {
            public string Name;
            public AncestralTree Ancestor;

            public AncestralTree(string name)
            {
                this.Name = name;
                this.Ancestor = null;
            }
        }

        public static AncestralTree BuildAndGetAncestralTree()
        {
            // Create nodes
            AncestralTree A = new AncestralTree("A");
            AncestralTree B = new AncestralTree("B");
            AncestralTree C = new AncestralTree("C");
            AncestralTree D = new AncestralTree("D");
            AncestralTree E = new AncestralTree("E");
            AncestralTree F = new AncestralTree("F");
            AncestralTree G = new AncestralTree("G");
            AncestralTree H = new AncestralTree("H");
            AncestralTree I = new AncestralTree("I");

            // Set ancestors
            B.Ancestor = A;
            C.Ancestor = A;
            D.Ancestor = B;
            E.Ancestor = B;
            F.Ancestor = C;
            G.Ancestor = C;
            H.Ancestor = D;
            I.Ancestor = D;

            // Inputs
            AncestralTree topAncestor = A;
            AncestralTree descendantOne = E;
            AncestralTree descendantTwo = I;

            // You can now work on finding the youngest common ancestor

            return A;
        }

        public static string GetYoungestCommonAncestor() {

            // Create nodes
            AncestralTree A = new AncestralTree("A");
            AncestralTree B = new AncestralTree("B");
            AncestralTree C = new AncestralTree("C");
            AncestralTree D = new AncestralTree("D");
            AncestralTree E = new AncestralTree("E");
            AncestralTree F = new AncestralTree("F");
            AncestralTree G = new AncestralTree("G");
            AncestralTree H = new AncestralTree("H");
            AncestralTree I = new AncestralTree("I");

            // Set ancestors
            B.Ancestor = A;
            C.Ancestor = A;
            D.Ancestor = B;
            E.Ancestor = B;
            F.Ancestor = C;
            G.Ancestor = C;
            H.Ancestor = D;
            I.Ancestor = D;

            // Inputs
            AncestralTree topAncestor = A;
            AncestralTree descendantOne = E;
            AncestralTree descendantTwo = I;


            List<string> pathForDescendantOne = new List<string>();
            List<string> pathForDescendantTwo = new List<string>();

            Traverse(descendantOne, pathForDescendantOne);
            Traverse(descendantTwo, pathForDescendantTwo);

            pathForDescendantOne.Reverse();
            pathForDescendantTwo.Reverse();

            string lastMatched = string.Empty;

            for(int i = 0; i < Math.Min(pathForDescendantOne.Count, pathForDescendantTwo.Count); i++)
            {
                if (pathForDescendantOne[i] == pathForDescendantTwo[i])
                {
                    lastMatched = pathForDescendantOne[i];
                }
            }

            return lastMatched;

        }

        private static void Traverse(AncestralTree descendant, List<string> path)
        {
            if (descendant.Ancestor is null)
                return;

            path.Add(descendant.Ancestor.Name);   
            Traverse(descendant.Ancestor, path);
        }


        public static string GetYoungestCommonAncestorOptimal()
        {

            // Create nodes
            AncestralTree A = new AncestralTree("A");
            AncestralTree B = new AncestralTree("B");
            AncestralTree C = new AncestralTree("C");
            AncestralTree D = new AncestralTree("D");
            AncestralTree E = new AncestralTree("E");
            AncestralTree F = new AncestralTree("F");
            AncestralTree G = new AncestralTree("G");
            AncestralTree H = new AncestralTree("H");
            AncestralTree I = new AncestralTree("I");

            // Set ancestors
            B.Ancestor = A;
            C.Ancestor = A;
            D.Ancestor = B;
            E.Ancestor = B;
            F.Ancestor = C;
            G.Ancestor = C;
            H.Ancestor = D;
            I.Ancestor = D;

            // Inputs
            AncestralTree topAncestor = A;
            AncestralTree descendantOne = E;
            AncestralTree descendantTwo = I;

            int depthOfDescendantOne = GetDepth(descendantOne);
            int depthOfDescendantTwo = GetDepth(descendantTwo);

            if(depthOfDescendantOne>depthOfDescendantTwo)
            {
                return GetLeveledAncestor(descendantOne, descendantTwo, depthOfDescendantOne - depthOfDescendantTwo);
            }
            else
            {
                return GetLeveledAncestor(descendantTwo, descendantOne, depthOfDescendantTwo - depthOfDescendantOne);
            }

        }

        private static string GetLeveledAncestor(AncestralTree descendantOne, AncestralTree descendantTwo, int diff )
        {
            while(diff > 0)
            {
                descendantOne = descendantOne.Ancestor;
                diff = diff - 1;
            }

            while(descendantOne != descendantTwo)
            {
                descendantOne = descendantOne.Ancestor;
                descendantTwo = descendantTwo.Ancestor;
            }

            return descendantTwo.Name;
        }

        private static int GetDepth(AncestralTree descendant)
        {
            int depth = 0;
            while (descendant != null) {
            
                descendant = descendant.Ancestor;
                depth++;
            }
            return depth;
        }

        public bool DetectCycleInAGraph(int[,] graph)
        {
            bool[] visitedArray = new bool[graph.GetLength(0)];
            List<int> listOfParents = new List<int>();
            for (int i = 0; i < graph.GetLength(0); i++)
            { 
                listOfParents.Add(-99);
            }
            listOfParents[0] = -1;
            bool isCycleDetected = false;
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                if (!visitedArray[i])
                {
                    DFSCycle(i, graph, listOfParents, visitedArray, ref isCycleDetected);
                }
            }
            return isCycleDetected;
        }

        /// <summary>
        /// Code for detecting cycle
        /// </summary>
        /// <param name="index"></param>
        /// <param name="graph"></param>
        /// <param name="listOfParents"></param>
        /// <param name="visitedArray"></param>
        /// <param name="isCycleDetected"></param>
        private void DFSCycle(int index, int[,] graph, List<int> listOfParents, bool[] visitedArray,ref bool isCycleDetected)
        {
            if(isCycleDetected) { return; } 
            visitedArray[index] = true;
            for (int j = 0; j < graph.GetLength(1); j++)
            {   
                if (graph[index, j] == 1 && visitedArray[j] != true)
                {
                    listOfParents[j] = index;
                    DFSCycle(j, graph, listOfParents, visitedArray, ref isCycleDetected);
                }
                else if (listOfParents[index] != j)
                {
                    isCycleDetected = true;
                    break;
                }
            }
            
        }
    }
}
