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
              fileUtils.ReadFileToStringArray(@"D:\Users\shanebo\Projects\CodeSippets\CodeSippets\GGCJ_Practices\Inputs\Africa-B-large-practice.in");            
            var currentCase = 1;
            var caseCount = int.Parse(fileUtils.GetCountOfCases(input));
            var output = new string[caseCount];
            while (currentCase <= caseCount)
            {
                var result=string.Empty;
                //MAGIC GOES HERE  
                var inArray = input[currentCase].Split(' ');
                Array.Reverse(inArray);
                result = (inArray.Aggregate(result, (current, s) => current + (s + " "))).TrimEnd(' ');

                
                
                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);                
                currentCase += 1;
            }
            fileUtils.WriteStringArrayToFile(output,
              @"D:\Users\shanebo\Projects\CodeSippets\CodeSippets\GGCJ_Practices\Inputs\Africa-B-large-practice.out");
            Console.ReadKey();
        }  
    }
}
