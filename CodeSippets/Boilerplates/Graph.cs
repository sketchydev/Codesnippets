using System;
using System.Collections.Generic;

namespace CodeSippets.Boilerplates
{
    public class Graph
    {
        internal IDictionary<string, Node> Nodes { get; }

        public Graph()
        {
            Nodes = new Dictionary<string, Node>();
        }

        public void AddNode(string name)
        {
            var node = new Node(name);
            Nodes.Add(name, node);
        }

        public void AddConnection(string fromNode, string toNode, int distance, bool twoWay)
        {
            Nodes[fromNode].AddConnection(Nodes[toNode], distance, twoWay);
        }


    }

    public class Node
    {
        public int FScore { get; set; }
        public int GScore { get; set; }

        readonly IList<NodeConnection> _connections;
        internal string Name { get; private set; }
        internal double DistanceFromStart { get; set; }
        internal IEnumerable<NodeConnection> Connections => _connections;

        public Node(string name)
        {
            Name = name;
            _connections = new List<NodeConnection>();
        }
        internal void AddConnection(Node targetNode, int distance, bool twoWay)
        {
            if (targetNode == null) throw new ArgumentNullException(nameof(targetNode));
            if (targetNode == this) throw new ArgumentException("Node may not connect to itself.");
            if (distance <= 0) throw new ArgumentException("Distance must be positive.");
            _connections.Add(new NodeConnection(targetNode, distance));

            if (twoWay) targetNode.AddConnection(this, distance, false);
        }
    }

    internal class NodeConnection
    {
        internal Node Target { get; private set; }
        internal int Distance { get; private set; }
        internal NodeConnection(Node target, int distance)
        {
            Target = target; Distance = distance;
        }
    }

}
