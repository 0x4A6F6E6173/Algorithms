using Algorithms.Datatypes;

namespace Algorithms.Traversal
{
    public static class BFS
    {
        public static void BreadthFirstSearch<T>(DirectedDenseGraph<T> graph, int startingNode)
        {
            Datatypes.Queue<int> queue = new();
            var nodeCount = graph.NodeList.Count;
            var visited = new bool[nodeCount];
            var traversalGraph = new int[nodeCount, nodeCount];

            // Push the first node onto the queue
            for (int index = 0; index < nodeCount; index++)
            {
                var currentEdge = graph.NodeArcIncidenceMatrix[startingNode, index];
                bool areNodesConnected = currentEdge > 0;
                if (areNodesConnected)
                {
                    queue.Enqueue(currentEdge);
                    traversalGraph[startingNode, index] = 1;
                }
            }

            // Traverse through the rest of the graph
            while (queue.Count() > 0)
            {
                var currentNode = queue.Dequeue();
                for (int index = 0; index < nodeCount; index++)
                {
                    var currentEdge = graph.NodeArcIncidenceMatrix[currentNode, index];
                    bool areNodesConnected = currentEdge > 0;
                    if (areNodesConnected)
                    {
                        queue.Enqueue(currentEdge);
                        traversalGraph[startingNode, index] = 1;
                    }
                }
            }
        }
    }
}
