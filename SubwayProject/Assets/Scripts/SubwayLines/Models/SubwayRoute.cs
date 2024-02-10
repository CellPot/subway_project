using BaseGraph.Graph;

namespace SubwayLines.Models
{
    public class SubwayRoute
    {
        public Node PathNode { get; }
        public int TransfersCount { get; }

        public SubwayRoute(Node pathNode, int transfersCount)
        {
            PathNode = pathNode;
            TransfersCount = transfersCount;
        }
    }
}