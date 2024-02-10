using System.Collections.Generic;
using BaseGraph.Graph;

namespace BaseGraph.PathFinder
{
    public class BfsPathsFinder : IAdjacencyPathsFinder
    {
        public UndirectedGraph GetShortestPaths(UndirectedGraph graph, int originIndex, int targetIndex)
        {
            var distancesGraph = GetDistancesWithParents(graph, originIndex);
            var pathsGraph = FindAllPaths(distancesGraph, targetIndex);
            RevertAllPaths(pathsGraph);

            return pathsGraph;
        }

        private static UndirectedGraph GetDistancesWithParents(UndirectedGraph graph, int originIndex)
        {
            var queue = new Queue<int>();
            var distancesGraph = new UndirectedGraph();
            var distFromOrigin = new int[graph.Nodes.Count];
            for (var i = 0; i < graph.Nodes.Count; i++)
            {
                distancesGraph.Nodes.Add(new Node());
                distFromOrigin[i] = int.MaxValue;
            }

            queue.Enqueue(originIndex);

            distancesGraph.Nodes[originIndex].Adjacencies.Clear();
            distancesGraph.Nodes[originIndex].Adjacencies.Add(-1);
            distFromOrigin[originIndex] = 0;

            while (queue.Count != 0)
            {
                var currentIndex = queue.Dequeue();

                foreach (var adjIndex in graph.Nodes[currentIndex].Adjacencies)
                {
                    if (ShorterDistanceFound(adjIndex, currentIndex))
                    {
                        distFromOrigin[adjIndex] = distFromOrigin[currentIndex] + 1;
                        queue.Enqueue(adjIndex);

                        distancesGraph.Nodes[adjIndex].Adjacencies.Clear();
                        distancesGraph.Nodes[adjIndex].Adjacencies.Add(currentIndex);
                    }
                    else if (SameDistance(adjIndex, currentIndex))
                    {
                        distancesGraph.Nodes[adjIndex].Adjacencies.Add(currentIndex);
                    }
                }
            }

            return distancesGraph;

            bool ShorterDistanceFound(int original, int newDistance) =>
                distFromOrigin[original] > distFromOrigin[newDistance] + 1;

            bool SameDistance(int original, int newDistance) =>
                distFromOrigin[original] == distFromOrigin[newDistance] + 1;
        }

        private static UndirectedGraph FindAllPaths(UndirectedGraph distancesGraph, int targetIndex,
            UndirectedGraph pathsGraph = null, Node path = null)
        {
            pathsGraph ??= new UndirectedGraph();
            path ??= new Node();

            if (IsBaseCase())
            {
                pathsGraph.Nodes.Add(new Node(path));
                return pathsGraph;
            }

            foreach (var parentIndex in distancesGraph.Nodes[targetIndex].Adjacencies)
            {
                InsertCurrentVertexInPath();
                pathsGraph = FindAllPaths(distancesGraph, parentIndex, pathsGraph, path);
                RemoveCurrentVertexFromPath();
            }

            return pathsGraph;

            bool IsBaseCase() =>
                targetIndex == -1;

            void InsertCurrentVertexInPath() =>
                path.Adjacencies.Add(targetIndex);

            void RemoveCurrentVertexFromPath() =>
                path.Adjacencies.RemoveAt(path.Adjacencies.Count - 1);
        }

        private static void RevertAllPaths(UndirectedGraph pathsGraph)
        {
            foreach (var pathVertex in pathsGraph.Nodes)
                pathVertex.Adjacencies.Reverse();
        }
    }
}