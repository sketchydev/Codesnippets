using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSippets
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileUtils = new FileUtils();
            var input =
              fileUtils.ReadFileToStringArray(@"D:\Users\shanebo\Projects\CodeSippets\CodeSippets\GGCJ_Practices\Inputs\Africa-A-large-practice.in");
            var linepointer = 1;
            var currentCase = 1;
            var output = new string[int.Parse(fileUtils.GetCountOfCases(input))];
            while (linepointer < input.Length)
            {
                var result = string.Empty;
                var creditLimit = int.Parse(input[linepointer]);
                var currentRecordSet = input[linepointer + 2].Split(' ').Select(int.Parse).ToArray();
                //MAGIC GOES HERE 

                for (var i = 0; i < currentRecordSet.Length; i++)
                {                    
                    for (var j = i+1; j < currentRecordSet.Length; j++)
                    {
                        if (currentRecordSet[i] + currentRecordSet[j]==creditLimit)
                        {
                            result = (i+1) + " " + (j+1);
                        }
                    }
                    if(result!=string.Empty) break;
                }

                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);
                linepointer += 3;
                currentCase += 1;
            }
                 fileUtils.WriteStringArrayToFile(output,
                    @"D:\Users\shanebo\Projects\CodeSippets\CodeSippets\GGCJ_Practices\Inputs\Africa-A-large-practice.out");
            
            Console.ReadKey();
        }  
    }
}
