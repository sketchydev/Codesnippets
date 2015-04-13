using System;
using System.Collections.Generic;

namespace CodeSippets
{
    class Program
    {
        static void Main(string[] args)
        {
            var allScenarios = new Dictionary<string, string>
            {
                {"1 1 1", "GABRIEL"},
                {"1 1 2", "GABRIEL"},
                {"1 1 3", "GABRIEL"},
                {"1 1 4", "GABRIEL"},
                {"1 2 1", "GABRIEL"},
                {"1 2 2", "GABRIEL"},
                {"1 2 3", "GABRIEL"},
                {"1 2 4", "GABRIEL"},
                {"1 3 1", "GABRIEL"},
                {"1 3 2", "GABRIEL"},
                {"1 3 3", "GABRIEL"},
                {"1 3 4", "GABRIEL"},
                {"1 4 1", "GABRIEL"},
                {"1 4 2", "GABRIEL"},
                {"1 4 3", "GABRIEL"},
                {"1 4 4", "GABRIEL"},

                {"2 1 1", "RICHARD"},
                {"2 1 2", "GABRIEL"},
                {"2 1 3", "RICHARD"},
                {"2 1 4", "GABRIEL"},
                {"2 2 1", "GABRIEL"},
                {"2 2 2", "GABRIEL"},
                {"2 2 3", "GABRIEL"},
                {"2 2 4", "GABRIEL"},
                {"2 3 1", "RICHARD"},
                {"2 3 2", "GABRIEL"},
                {"2 3 3", "RICHARD"},
                {"2 3 4", "GABRIEL"},
                {"2 4 1", "GABRIEL"},
                {"2 4 2", "GABRIEL"},
                {"2 4 3", "GABRIEL"},
                {"2 4 4", "GABRIEL"},

                {"3 1 1", "RICHARD"},
                {"3 1 2", "RICHARD"},
                {"3 1 3", "RICHARD"},
                {"3 1 4", "RICHARD"},
                {"3 2 1", "RICHARD"},
                {"3 2 2", "RICHARD"},
                {"3 2 3", "GABRIEL"},
                {"3 2 4", "RICHARD"},
                {"3 3 1", "RICHARD"},
                {"3 3 2", "GABRIEL"},
                {"3 3 3", "GABRIEL"},
                {"3 3 4", "GABRIEL"},
                {"3 4 1", "RICHARD"},
                {"3 4 2", "RICHARD"},
                {"3 4 3", "GABRIEL"},
                {"3 4 4", "RICHARD"},
                
                {"4 1 1", "RICHARD"},
                {"4 1 2", "RICHARD"},
                {"4 1 3", "RICHARD"},
                {"4 1 4", "RICHARD"},
                {"4 2 1", "RICHARD"},
                {"4 2 2", "RICHARD"},
                {"4 2 3", "RICHARD"},
                {"4 2 4", "RICHARD"},
                {"4 3 1", "RICHARD"},
                {"4 3 2", "RICHARD"},
                {"4 3 3", "RICHARD"},
                {"4 3 4", "GABRIEL"},
                {"4 4 1", "RICHARD"},
                {"4 4 2", "RICHARD"},
                {"4 4 3", "GABRIEL"},
                {"4 4 4", "GABRIEL"}
            };



            var fileUtils = new FileUtils();
            var input =
              fileUtils.ReadFileToStringArray(@"C:\temp\ggcj\D-small-attempt12.in");
            var currentCase = 1;
            var caseCount = int.Parse(fileUtils.GetCountOfCases(input));
            var output = new string[caseCount];


            while (currentCase <= caseCount)
            {
                var result = string.Empty;
                //MAGIC GOES HERE  

                var testCase = input[currentCase];

                result = allScenarios[testCase];

                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);
                currentCase += 1;
            }
            fileUtils.WriteStringArrayToFile(output, @"C:\temp\ggcj\D-small-attempt12.out");
            Console.ReadKey();
        }
    }
}
