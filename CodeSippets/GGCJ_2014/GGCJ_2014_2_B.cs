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
              fileUtils.ReadFileToStringArray(@"D:\Users\shanebo\Projects\CodeSippets\CodeJamDownloads\2014_2\B-small-practice.in");
            var linepointer = 1;
            var currentCase = 1;
            var output = new string[int.Parse(fileUtils.GetCountOfCases(input))];
            while (linepointer < input.Length)
            {
                var result = 0;                
                var currentRecordSet = input[linepointer+1].Split(' ')
                    .Select(n => Convert.ToInt32(n)).ToList();
                //MAGIC GOES HERE  

                var LHS = currentRecordSet.Take(currentRecordSet.FindIndex(n=> n==currentRecordSet.Max())).ToList();
                currentRecordSet.RemoveRange(0, LHS.Count()+1);
                //currentRecordSet.Reverse();
                var RHS = currentRecordSet;

                result = BubblesortCountLeft(LHS) + BubblesortCountRight(RHS);

                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);
                linepointer += 2;
                currentCase += 1;
            }
            fileUtils.WriteStringArrayToFile(output,
              @"D:\Users\shanebo\Projects\CodeSippets\CodeJamDownloads\2014_2\B-small-practice.out");
            Console.ReadKey();
        }

        public static int BubblesortCountLeft(List<int> input )
        {
            var count = 0;
            for (int write = 0; write < input.Count; write++)
            {
                for (int sort = 0; sort < input.Count - 1; sort++)
                {
                    if (input[sort] <= input[sort + 1]) continue;
                    var temp = input[sort + 1];
                    input[sort + 1] = input[sort];
                    input[sort] = temp;
                    count += 1;
                }
            }

            return count;
        }

        public static int BubblesortCountRight(List<int> input)
        {
            var count = 0;
            for (int write = 0; write < input.Count; write++)
            {
                for (int sort = 0; sort < input.Count - 1; sort++)
                {
                    if (input[sort] >= input[sort + 1]) continue;
                    var temp = input[sort + 1];
                    input[sort + 1] = input[sort];
                    input[sort] = temp;
                    count += 1;
                }
            }

            return count;
        }
    }
}
