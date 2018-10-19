using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floyd_Warshall
{
    class Graph : Dictionary<int, Node>
    {
        public void createNodes(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                this.Add(i, new Node(i));
            }
        }

        public void createEdges(List<string> strEdges)
        {
            foreach (string str in strEdges)
            {
                string[] splitedEdges = str.Split(',');
                int startNodeNum = Int32.Parse(splitedEdges[0].Trim());
                int endNodeNum = Int32.Parse(splitedEdges[1].Trim());
                int weight = Int32.Parse(splitedEdges[2].Trim());
                this[startNodeNum].edges.Add(new Edge(this[endNodeNum], weight));
            }
        }

        public void runFloydWarshallAlgorithm()
        {
            int inf = 2000000;
            int nodesCount = this.Count;
            int[,] adjacencyMatrix = setAdjacencyMatrix();
            printMatrix(adjacencyMatrix);
            Console.WriteLine("    k\ti\tj\tw[i,k] + w[k,j] < w[i,j]\tw[i,j]");
            Console.WriteLine("______________________________________________________________");

            int stepNum = 0;
            for (int k = 0; k < nodesCount; k++)
            {
                for (int i = 0; i < nodesCount; i++)
                {
                    for (int j = 0; j < nodesCount; j++)
                    {
                        stepNum++;
                        Console.Write("{0}) ", stepNum);
                        if (stepNum <= 9)
                            Console.Write(" ");
                        Console.Write("{0}\t{1}\t{2}\t{3}\t\t\t\t", k, i, j, (adjacencyMatrix[i, k] + adjacencyMatrix[k, j]) < adjacencyMatrix[i, j]);
                        if ((adjacencyMatrix[i, k] + adjacencyMatrix[k, j]) < adjacencyMatrix[i, j])
                            adjacencyMatrix[i, j] = adjacencyMatrix[i, k] + adjacencyMatrix[k, j];
                        if (adjacencyMatrix[i, j] != inf)
                            Console.Write("{0}\n", adjacencyMatrix[i, j]);
                        else
                            Console.Write("{0}\n", "inf");
                    }
                }
            }
            Console.Write("\n\n");

            printMatrix(adjacencyMatrix);

            
        }

        int[,] setAdjacencyMatrix()
        {
            int inf = 2000000;
            int nodesCount = this.Count;
            int[,] adjacencyMatrix = new int[nodesCount, nodesCount];
            bool[,] boolMatrix = new bool[nodesCount, nodesCount];
            foreach (Node node in this.Values)
            {
                foreach (Edge edge in node.edges)
                {
                    adjacencyMatrix[node.number - 1, edge.neighbourNode.number - 1] = edge.weight;
                }
            }
            for (int i = 0; i < nodesCount; i++)
            {
                for (int j = 0; j < nodesCount; j++)
                {
                    if (adjacencyMatrix[i, j] == 0 && i != j)
                        adjacencyMatrix[i, j] = inf;
                }
            }

            return adjacencyMatrix;
        }

        void printMatrix(int[,] matrix)
        {
            int inf = 2000000;
            int rowLength = matrix.GetLength(0);
            int colLength = matrix.GetLength(1);

            Console.Write("   ");
            for (int i = 1; i <= rowLength; i++)
            {
                Console.Write("{0}\t", i);
            }
            Console.WriteLine();
            Console.Write("  ");
            for (int i = 1; i <= 40; i++)
            {
                Console.Write("_");
            }
            Console.WriteLine();

            for (int i = 0; i < rowLength; i++)
            {
                Console.Write("{0} |", i + 1);
                for (int j = 0; j < colLength; j++)
                {
                    if (matrix[i, j] == inf)
                        Console.Write("{0}\t", "inf");
                    else
                        Console.Write("{0}\t", matrix[i, j]);
                }
                Console.WriteLine();
            }
            Console.Write("\n\n");
        }
    }
}
