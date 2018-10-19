using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Floyd_Warshall
{
    class Program
    {
        static void Main(string[] args)
        {
            int nodesCount = 4; //количество вершин

            List<string> strEdges = new List<string>{
                //"Номер_начальной_вершины, номер_конечной_вершины, вес_связи",
                "1, 2, 1",
                "1, 3, 6",
                "2, 3, 4",
                "2, 4, 1",
                "4, 3, 1"
            };

            Graph graph = new Graph();

            graph.createNodes(nodesCount);

            graph.createEdges(strEdges);

            graph.runFloydWarshallAlgorithm();

            Console.Read();
        }
    }
}
