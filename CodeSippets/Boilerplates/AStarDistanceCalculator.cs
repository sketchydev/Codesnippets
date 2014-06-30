using System.Collections.Generic;
using System.Linq;

namespace CodeSippets.Boilerplates
{
    //TODO: not quite working needs fixing
    public class AStarDistanceCalculator
    {
        private readonly Graph _graph;
        public AStarDistanceCalculator(Graph graph)
        {
            _graph = graph;
        }

        public List<Node> AStar(Node start, Node goal, int costEstimate, bool visitAllNodes = false)
        {
            var visitedSet = new List<Node>();
            var openSet = new List<Node>() {start};
            var navigatedNodes = new List<Node>();

            start.GScore = 0;
            start.FScore = start.GScore + costEstimate;  //heuristic cost estimate
            //start.FScore = start.GScore + HeuristicCostEstimate(start, goal);  //heuristic cost estimate

            while (openSet.Count>0)
            {                
                var current = openSet.Find(x => x.FScore==openSet.Select(y=>y.FScore).Min());

                if (visitAllNodes)
                {
                    if (current == goal && (visitedSet.Count == _graph.Nodes.Count-1))
                        return ReconstructPath(navigatedNodes, current);    
                }
                else
                {
                if (current == goal) return ReconstructPath(navigatedNodes, current);    
                }
                
                openSet.Remove(current);
                visitedSet.Add(current);
                                
                foreach (var neighbour in current.Connections)
                {
                    if (visitedSet.Contains(neighbour.Target)) continue;

                    var tentativeGScore = current.GScore + neighbour.Distance;

                    if (openSet.Contains(neighbour.Target) && (tentativeGScore >= neighbour.Target.GScore)) continue;
                    navigatedNodes.Add(neighbour.Target);
                    neighbour.Target.GScore = tentativeGScore;
                    //neighbour.Target.FScore = neighbour.Target.GScore + HeuristicCostEstimate(neighbour.Target, goal);
                    neighbour.Target.FScore = neighbour.Target.GScore + costEstimate;

                    if(!openSet.Contains(neighbour.Target)) openSet.Add(neighbour.Target);

                }

            }
                //failure denoted by empty list
                return new List<Node>();

        }

        public int HeuristicCostEstimate(Node start, Node end)
        {
            return 1;

        }

        public List<Node> ReconstructPath(List<Node> navigatedNodes, Node current)
        {
            if (navigatedNodes.Contains(current))
            {
                var reconstructedPath = ReconstructPath(navigatedNodes, navigatedNodes.Find(x => x==current));
                return reconstructedPath;
            }

            return new List<Node>(){current};
        }



    }
}
