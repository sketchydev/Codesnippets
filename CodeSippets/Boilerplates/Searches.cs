using System.Collections.Generic;

namespace CodeSippets.Boilerplates
{
    public class Searches
    {
        public class Node
        {
            public string Value;
            public List<Node> Children;
        }

        public static Node BFS(Node root, string caseToFind)
        {

            var queue = new Queue<Node>();            
            queue.Enqueue(root);
            var currentNode = new Node();
            while (queue.Count>0)
            {                                       
                currentNode = queue.Dequeue();

                //test for case
                if (currentNode.Value == caseToFind) break;
                foreach (var child in currentNode.Children)
                {
                    queue.Enqueue(child);
                }
            }
                return currentNode;    
        }

        public static Node DFS(Node root, string caseToFind)
        {

            var stack = new Stack<Node>();
            stack.Push(root);
            var currentNode = new Node();
            while (stack.Count > 0)
            {
                currentNode = stack.Pop();

                if (currentNode.Value == caseToFind) break;
                foreach (var child in currentNode.Children)
                {
                    stack.Push(child);
                }
            }
            return currentNode;
        }

    }
}
