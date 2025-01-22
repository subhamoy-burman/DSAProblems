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
    }
}
