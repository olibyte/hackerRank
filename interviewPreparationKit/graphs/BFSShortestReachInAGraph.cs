using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        var q = Int32.Parse(Console.ReadLine());

            for (var i = 0; i < q; i++)
            {
                var firstLine = Console.ReadLine().Split(' ');
                var nodesCnt = Int32.Parse(firstLine[0]);
                var edgesCnt = Int32.Parse(firstLine[1]);
                var nodes = new Node[nodesCnt];

                for (int j = 0; j < nodesCnt; j++)
                {
                    nodes[j] = new Node(j);
                }

                for (int j = 0; j < edgesCnt; j++)
                {
                    var connection = Console.ReadLine().Split(' ');
                    var node1 = Int32.Parse(connection[0]);
                    var node2 = Int32.Parse(connection[1]);
                    nodes[node1 -1].AddNeighbor(nodes[node2 - 1]);
                }

                var startNodeId = Int32.Parse(Console.ReadLine());

                nodes[startNodeId - 1].Distance = 0;
                CountDistances(nodes[startNodeId - 1]);

                var result = String.Join(" ", nodes.Where(x => x.Value != startNodeId -1).Select(x => x.Distance).ToList());
                Console.WriteLine(result);
            }

            Console.ReadKey();
        }

        private static void CountDistances(Node startNode)
        {
            var queue = new Queue<Node>();
            startNode.Distance = 0;
            queue.Enqueue(startNode);
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                foreach (var node in currentNode.Neighbors)
                {
                    if (node.Distance == -1)
                    {
                        node.Distance = currentNode.Distance + 6;
                        queue.Enqueue(node);
                    }
                }
            }
            //foreach (var node in startNode.Neighbors)
            //{
            //    if (node.Distance != -1) continue;
            //    node.Distance = startNode.Distance + 6;
            //    CountDistances(node);
            //}
        }

    public class Node
    {
        public int Value { get;}
        public HashSet<Node> Neighbors { get; set; }
        public int Distance { get; set; }

        public Node(int value)
        {
            Value = value;
            Neighbors = new HashSet<Node>();
            Distance = -1;
        }

        public void AddNeighbor(Node neighbor)
        {
            Neighbors.Add(neighbor);
            neighbor.Neighbors.Add(this);
        }
    }
}