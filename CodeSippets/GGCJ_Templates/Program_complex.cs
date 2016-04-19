using System;

namespace CodeSippets
{
    class Program
    {
        static void Main(string[] args)
        {            
            var input =
              FileUtils.ReadFileToStringArray(@"c:\temp\GGCJ_\Inputs\.in");
            var linepointer = 1;
            var currentCase = 1;
            var output = new string[int.Parse(FileUtils.GetCountOfCases(input))];
            while (linepointer < input.Length)
            {
                var result = string.Empty;
                var currentRecordCount = int.Parse(input[linepointer]);
                var currentRecordSet = FileUtils.GetRecordSet(linepointer + 1,
                                       currentRecordCount,
                                       input);
                //MAGIC GOES HERE  
                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = $"Case #{currentCase}: {result}";
                linepointer += currentRecordCount + 1;
                currentCase += 1;
            }
            FileUtils.WriteStringArrayToFile(output,@"c:\temp\GGCJ_\Outputs\.out");
            Console.ReadKey();
        }  
    }
}
