using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSippets.GGCJ_2014
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var fileUtils = new FileUtils();
            var input =
              fileUtils.ReadFileToStringArray(@"C:\Git\Personal\Codesnippets\CodeSippets\GGCJ_2014\Inputs\1A-A-Sample.in");
            var linepointer = 1;
            var currentCase = 1;
            var output = new string[int.Parse(fileUtils.GetCountOfCases(input))];
            while (linepointer < input.Length)
            {
                var result = string.Empty;
                var lights = int.Parse(input[linepointer].Split(' ')[0]);
                var switches = int.Parse(input[linepointer].Split(' ')[1]);
                var startConfig = input[linepointer + 1].Split(' ').ToList().OrderBy(x=>x);
                var targetConfig = input[linepointer + 2].Split(' ').ToList().OrderBy(x => x);                
                var count = 0;
                var pointer = 0;
                bool resultFound = true;
                //MAGIC GOES HERE  

                


                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);
                linepointer += 3;
                currentCase += 1;
            }
            //fileUtils.WriteStringArrayToFile(output, @"C:\Git\Personal\Codesnippets\CodeSippets\GGCJ_2014\Inputs\1A-A-Sample.out");
            Console.ReadKey();
        }  
    }

    public class BinaryTreeNode
    {
        public BinaryTreeNode Left { get; set; }

        public BinaryTreeNode Right { get; set; }

        public List<string> Data { get; set; }
    }


    public class BreadthFirstSearch
    {
        private readonly Queue<BinaryTreeNode> _searchQueue;
        private readonly BinaryTreeNode _root;

        public BreadthFirstSearch(BinaryTreeNode rootNode)
        {
            _searchQueue = new Queue<BinaryTreeNode>();
            _root = rootNode;
        }

        public bool Search(List<string> data)
        {
            var _current = _root;
            _searchQueue.Enqueue(_root);

            while (_searchQueue.Count != 0)
            {
                _current = _searchQueue.Dequeue();
                if (_current.Data == data)
                {
                    return true;
                }
                _searchQueue.Enqueue(_current.Left);
                _searchQueue.Enqueue(_current.Right);
            }

            return false;
        }
    }

}
