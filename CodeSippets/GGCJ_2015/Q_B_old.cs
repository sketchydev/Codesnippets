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
           fileUtils.ReadFileToStringArray(@"C:\temp\ggcj\sample.in");      
            var linepointer = 1;
            var currentCase = 1;
            var output = new string[int.Parse(fileUtils.GetCountOfCases(input))];
            while (linepointer < input.Length)
            {
                var result = string.Empty;
                var currentRecordCount = int.Parse(input[linepointer]);
                var currentRecordSet = fileUtils.GetRecordSet(linepointer + 1,
                                       currentRecordCount,
                                       input);
                //MAGIC GOES HERE  

                //how many mins if we do nothing
                var minsBase = currentRecordSet[0].Split(' ').Select(int.Parse).Max();


                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);
                linepointer += currentRecordCount + 1;
                currentCase += 1;
            }
            //fileUtils.WriteStringArrayToFile(output, @"C:\temp\ggcj\b_sample.out");
            Console.ReadKey();
        }  
    }
}
