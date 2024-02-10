using System.Collections.Generic;
using System.Linq;
using BaseGraph.Graph;
using BaseGraph.PathFinder;
using SubwayLines.Models;

namespace SubwayLines.Logic
{
    public class RouteSearchHandler
    {
        private SubwaySystem subwaySystem;
        private IAdjacencyPathsFinder pathsFinder;
        private UndirectedGraph graph;

        public RouteSearchHandler(SubwaySystem subwaySystem, IAdjacencyPathsFinder pathsFinder)
        {
            this.subwaySystem = subwaySystem;
            this.pathsFinder = pathsFinder;

            InitializeGraph(subwaySystem);
        }

        public UndirectedGraph Graph => graph;
        public SubwaySystem System => subwaySystem;

        public List<SubwayRoute> GetTravelRoutes(int origin, int target)
        {
            var shortestPaths = pathsFinder.GetShortestPaths(graph, origin, target);

            return RouteUtils.GetTravelRoutesFor(shortestPaths, subwaySystem);
        }

        public List<SubwayRoute> GetSortedTravelRoutes(int origin, int target)
        {
            var routes = GetTravelRoutes(origin, target);
            var sortedRoutes = routes.OrderBy(route => route.TransfersCount).ToList();

            return sortedRoutes;
        }

        private void InitializeGraph(SubwaySystem system)
        {
            graph = new UndirectedGraph();

            for (var i = 0; i < system.StationsCount; i++)
                graph.Nodes.Add(new Node());

            foreach (var subwayLine in system.Lines)
            {
                foreach (var segment in subwayLine.Segments)
                    graph.AddEdge(segment.Point1, segment.Point2);
            }
        }
    }
}