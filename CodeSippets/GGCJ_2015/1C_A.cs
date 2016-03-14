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
              fileUtils.ReadFileToStringArray(@"C:\temp\ggcj\a_sample.in");            
            var currentCase = 1;
            var caseCount = int.Parse(fileUtils.GetCountOfCases(input)));
            var output = new string[caseCount];
            while (currentCase <= caseCount)
            {
                var result=string.Empty;
                //MAGIC GOES HERE  
                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);                
                currentCase += 1;
            }
            //fileUtils.WriteStringArrayToFile(output,@"C:\temp\ggcj\upload\.out");
            Console.ReadKey();
        }  
    }
}
