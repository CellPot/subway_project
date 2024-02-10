using System.Collections.Generic;
using System.Linq;
using BaseGraph.Graph;
using SubwayLines.Data;
using SubwayLines.Models;

namespace SubwayLines.Logic
{
    public static class RouteUtils
    {
        public static string ConvertRoutesToString(List<SubwayRoute> travelRoutes, StationsData stationsData)
        {
            var resultString = "";
            if (travelRoutes.Count == 0)
                resultString = "No routes found";
            else if (travelRoutes.Count == 1 && travelRoutes[0].PathNode.Adjacencies.Count == 1)
                resultString = "You are already here!";
            else
            {
                for (var i = 0; i < travelRoutes.Count; i++)
                {
                    if (i == 1)
                        resultString += "\nOther shortest routes: \n";
                    resultString += $"Route {i + 1} ({travelRoutes[i].TransfersCount - 1} transfers): ";
                    for (var k = 0; k < travelRoutes[i].PathNode.Adjacencies.Count; k++)
                    {
                        if (k != 0)
                            resultString += " -> ";
                        var vertexIndex = travelRoutes[i].PathNode.Adjacencies[k];
                        resultString += GetRoutePointName(stationsData, vertexIndex);
                    }

                    resultString += "\n";
                }
            }

            return resultString;
        }

        public static List<SubwayRoute> GetTravelRoutesFor(UndirectedGraph shortestPaths, SubwaySystem system)
        {
            var routesList = new List<SubwayRoute>();
            foreach (var path in shortestPaths.Nodes)
            {
                routesList.Add(GetTravelRouteFor(path, system));
            }

            return routesList;
        }

        public static SubwayRoute GetTravelRouteFor(Node path, SubwaySystem system)
        {
            var segments = LineSegment.ConvertToSegments(path.Adjacencies);
            SubwayLine lastLine = null;
            var counter = 0;
            foreach (var segment in segments)
            {
                var currentLine = system.GetLineWithSegment(segment.Point1, segment.Point2);
                if (currentLine != lastLine)
                    counter++;
                lastLine = currentLine;
            }

            return new SubwayRoute(path, counter);
        }

        public static string GetRoutePointName(StationsData stationsData, int index)
        {
            var data = stationsData.stations.First(data => data.ID == index);

            return data.Name;
        }
    }
}