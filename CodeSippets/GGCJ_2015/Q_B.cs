using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSippets
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileUtils = new FileUtils();
            var input =
              fileUtils.ReadFileToStringArray(@"C:\temp\ggcj\B-small-attempt0.in");            
            var currentCase = 1;
            var caseCount = int.Parse(fileUtils.GetCountOfCases(input));
            var output = new string[caseCount];
            var linepointer = 2;
            while (currentCase <= caseCount)
            {
                var result=string.Empty;
                //MAGIC GOES HERE  
                //if we do nothing...use this as the limit when splitting pancakes
                var diners = input[linepointer]
                    .Split(' ').Select(int.Parse).ToList();
                var minsBase = diners.Max();            

                //At every step we can do nothing or split the largest stack in two

                int minMinselapsed = minsBase;
                Traverse(diners, 0, minsBase, ref minMinselapsed);

                result = minMinselapsed.ToString();

                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);                
                currentCase += 1;
                linepointer+=2;
            }
            fileUtils.WriteStringArrayToFile(output, @"C:\temp\ggcj\B-small-attempt0.out");
            Console.ReadKey();
        }

        static void Traverse(List<int> currentState, int depth, int maxDepth, ref int shallowest)
        {
            if (currentState.Sum() == 0)
            {
                if (shallowest > depth) shallowest = depth;               
                return;
            }
            if (depth==maxDepth) return;

            //eat the pancakes (left node)
            Traverse(currentState.Select(i => i - 1)
                .ToList(), depth+1, maxDepth, ref shallowest);

            //find the largest stack and split it (right node)            
            var max = currentState.Max();
            currentState.Remove(max);
            if (max%2 == 0)
            {
                currentState.Add(max/2);
                currentState.Add(max/2);
            }
            else
            {
                currentState.Add(max - 1 / 2);
                currentState.Add(max + 1 / 2);
            }
            
            Traverse(currentState, depth+1, maxDepth, ref shallowest);           
        }

    }
}
