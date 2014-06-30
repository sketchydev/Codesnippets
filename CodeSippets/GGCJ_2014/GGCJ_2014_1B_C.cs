using System;
using System.Collections.Generic;
using System.Linq;
using CodeSippets.Boilerplates;

namespace CodeSippets
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileUtils = new FileUtils();
            var input =
              fileUtils.ReadFileToStringArray(@"D:\Users\shanebo\Projects\CodeSippets\CodeSippets\GGCJ_2014\Inputs\1B-C-Sample.in");
            var linepointer = 1;
            var currentCase = 1;
            var output = new string[int.Parse(fileUtils.GetCountOfCases(input))];
            while (linepointer < input.Length)
            {
                var result = string.Empty;
                var M = int.Parse(input[linepointer].Split(' ')[0]);
                var N = int.Parse(input[linepointer].Split(' ')[1]);                    
                var zipCodes = fileUtils.GetRecordSet(linepointer + 1,
                                       M,
                                       input);

                var flights = fileUtils.GetRecordSet(linepointer +1+M,
                       N,
                       input);
                //MAGIC GOES HERE  

                var graph = new Graph();

                //add nodes here
                foreach (var node in zipCodes)
                {
                    graph.AddNode(node);
                }

                //add connections
                foreach (var connection in flights)
                {
                    var a = int.Parse(connection.Split(' ')[0]);
                    var b = int.Parse(connection.Split(' ')[1]);

                    graph.AddConnection(zipCodes[a - 1], zipCodes[b-1], 1, true);
                }

                var astarcalc = new AStarDistanceCalculator(graph);

                var routes = graph.Nodes.Select(node => astarcalc.AStar(node.Value, node.Value, N, true)).ToList();


                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);
                linepointer += M+N + 1;
                currentCase += 1;
            }
            //fileUtils.WriteStringArrayToFile(output,@"D:\Users\shanebo\Projects\CodeSippets\CodeSippets\GGCJ_2014\Inputs\.out");
            Console.ReadKey();
        }  
    }
}
