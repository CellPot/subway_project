using System.Collections.Generic;

namespace BaseGraph.Graph
{
    public class UndirectedGraph
    {
        public List<Node> Nodes = new();

        public void AddEdge(int originIndex, int targetIndex)
        {
            if (IndexesOutOfRange())
                return;

            Nodes[originIndex].Adjacencies.Add(targetIndex);
            Nodes[targetIndex].Adjacencies.Add(originIndex);

            bool IndexesOutOfRange() =>
                originIndex < 0 || originIndex >= Nodes.Count || targetIndex < 0 || targetIndex >= Nodes.Count;
        }
    }
}