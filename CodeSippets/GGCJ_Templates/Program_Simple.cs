using System;

namespace CodeSippets
{
    class Program
    {
        public static void Main(string[] args)
        {            
            var input =
              FileUtils.ReadFileToStringArray(@"c:\temp\GGCJ_\Inputs\.in");            
            var currentCase = 1;
            var caseCount = int.Parse(FileUtils.GetCountOfCases(input));
            var output = new string[caseCount];
            while (currentCase <= caseCount)
            {
                var result=string.Empty;
                //MAGIC GOES HERE  
                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = $"Case #{currentCase}: {result}";                
                currentCase += 1;
            }
            FileUtils.WriteStringArrayToFile(output,@"c:\temp\GGCJ_\Outputs\.out");
            Console.ReadKey();
        }  
    }
}
