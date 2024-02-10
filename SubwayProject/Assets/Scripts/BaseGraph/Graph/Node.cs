using System.Collections.Generic;

namespace BaseGraph.Graph
{
    public class Node
    {
        public Node()
        {
        }

        public Node(Node original)
        {
            Adjacencies = new List<int>(original.Adjacencies);
        }

        public List<int> Adjacencies = new();
    }
}