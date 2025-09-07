using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


public class Edge
{
    public int u, v;
    public double weight;

    public Edge(int u, int v, double weight)
    {
        this.u = u;
        this.v = v;
        this.weight = weight;
    }
}
public class UnionFind
{
    public List<Edge> Edges { get; set; }
    public List<int> Parents { get; set; }

    public UnionFind()
    {
        Edges = new List<Edge>()
        {
            new(0,1,2),
            new(1,2,3),
            new(1,4,5),
            new(0,3,6),
            new(2,4,7),
            new(1,3,8)
        };

        Parents = new List<int>();
        int maxNodeCount = Edges.Max(x => Math.Max(x.u, x.v));

        for (int i = 0; i <= maxNodeCount; i++)
        {
            Parents.Add(i);
        }
    }

    public int FindParent(int node)
    {
        if (Parents[node] == node)
        {
            return node;
        }
        else return FindParent(Parents[node]);
    }

    public void Union(int node1, int node2)
    {
        int parent1 = FindParent(node1);
        int parent2 = FindParent(node2);

        if (parent1 != parent2)
        {
            Parents[node1] = node2;
        }
    }

    public bool IsSameGroup(int node1, int node2)
    {
        return FindParent(node1) == FindParent(node2);
    }

}