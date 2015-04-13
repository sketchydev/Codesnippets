using System;
using System.Collections.Generic;

namespace CodeSippets
{
    class Program
    {       
        static void Main(string[] args)
        {           
            var validNumbers = new Dictionary<int, string>()
            {
            {0,"1111110"},
            {1,"0110000"},
            {2,"1101101"},
            {3,"1111001"},
            {4,"0110011"},
            {5,"1011011"},
            {6,"1011111"},
            {7,"1110000"},
            {8,"1111111"},
            {9,"1111011"}
            };

            var fileUtils = new FileUtils();
            var input =
              fileUtils.ReadFileToStringArray(@"C:\Git\Personal\Codesnippets\CodeJamDownloads\APAC_A\sample.in");            
            var currentCase = 1;
            var caseCount = int.Parse(fileUtils.GetCountOfCases(input));
            var output = new string[caseCount];
           
            while (currentCase <= caseCount)
            {
                var result=string.Empty;
                //MAGIC GOES HERE   
                var sequence = input[currentCase].Split(' ');

                foreach (var digit in sequence)
                {
                    if (validNumbers.ContainsValue(digit))
                    {
                        
                    }
                }


                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);                
                currentCase += 1;
            }
            fileUtils.WriteStringArrayToFile(output,
              @"C:\Git\Personal\Codesnippets\CodeJamDownloads\APAC_A\A-small-practice.out");
            Console.ReadKey();
        }  
    }
}
