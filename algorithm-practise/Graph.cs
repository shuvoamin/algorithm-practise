using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;

namespace algorithm_practise
{
    public class Graph
    {
        public class GraphNode
        {
            public int Id { get; set; }
            public LinkedList<GraphNode> Adjacent { get; set; } = new LinkedList<GraphNode>();

            public GraphNode(int id)
            {
                Id = id;
            }
        }

        private GraphNode GetNode(int id) => NodeToLookup[id];

        public void AddNode(int id) => NodeToLookup.Add(id, new GraphNode(id));

        public void AddEdge(int src, int dest)
        {
            GraphNode srcGraphNode = GetNode(src);
            GraphNode destGraphNode = GetNode(dest);

            srcGraphNode.Adjacent.AddLast(destGraphNode);
        }

        private IDictionary<int, GraphNode> NodeToLookup = new Dictionary<int, GraphNode>();

        public bool HasPathDfs(int src, int dest)
        {
            GraphNode srcGraphNode = GetNode(src);
            GraphNode destGraphNode = GetNode(dest);
            HashSet<int> visited = new HashSet<int>();
            
            return HasPathDfs(srcGraphNode, destGraphNode, visited);
        }

        private bool HasPathDfs(GraphNode src, GraphNode dest, HashSet<int> visited)
        {
            if (visited.Contains(src.Id))
                return false;

            visited.Add(src.Id);

            if (src == dest)
                return true;

            foreach (GraphNode child in src.Adjacent)
            {
                if (HasPathDfs(child, dest, visited))
                    return true;
            }

            return false;
        }

        public bool HasPathBfs(int src, int dest)
        {
            return HasPathBfs(GetNode(src), GetNode(dest));
        }

        private bool HasPathBfs(GraphNode srcNode, GraphNode destNode)
        {
            Queue<GraphNode> nextToVisit = new Queue<GraphNode>();
            HashSet<int> visited = new HashSet<int>();
            nextToVisit.Enqueue(srcNode);

            while (nextToVisit.Count > 0)
            {
                GraphNode graphNode = nextToVisit.Dequeue();

                if (graphNode == destNode)
                    return true;
                
                if (visited.Contains(srcNode.Id))
                    continue;

                visited.Add(srcNode.Id);

                foreach (GraphNode child in graphNode.Adjacent)
                {
                    nextToVisit.Enqueue(child);
                }
            }

            return false;
        }
    }
}