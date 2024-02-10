using BaseGraph.Graph;

namespace BaseGraph.PathFinder
{
    public interface IAdjacencyPathsFinder
    {
        public UndirectedGraph GetShortestPaths(UndirectedGraph graph, int originIndex, int targetIndex);
    }
}