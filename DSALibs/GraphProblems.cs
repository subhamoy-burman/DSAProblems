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
    }
}
