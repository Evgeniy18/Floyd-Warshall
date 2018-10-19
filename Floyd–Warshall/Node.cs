using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floyd_Warshall
{
    class Node
    {
        public int number;
        public List<Edge> edges = new List<Edge>();

        public Node(int number)
        {
            this.number = number;
        }
    }

    struct Edge
    {
        public Node neighbourNode;
        public int weight;

        public Edge(Node node, int dist)
        {
            this.neighbourNode = node;
            this.weight = dist;
        }
    }
}
