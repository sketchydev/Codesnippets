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
              fileUtils.ReadFileToStringArray(@"C:\temp\ggcj\A-large.in");            
            var currentCase = 1;
            var caseCount = int.Parse(fileUtils.GetCountOfCases(input));
            var output = new string[caseCount];
            while (currentCase <= caseCount)
            {
                var result=string.Empty;
                //MAGIC GOES HERE  
                var maxShyness = int.Parse(input[currentCase].Split()[0]);
                var inputString = input[currentCase].Split()[1].ToCharArray();
                int[] inputArr = inputString.Select(x => int.Parse(x.ToString())).ToArray();           
                var pplToAdd = 0;

                //if inputArr[0] = 0 then we will need to add at least one person
                if (inputArr[0] == 0)
                {                    
                    pplToAdd += 1;
                    inputArr[0] = 1;
                }
                var pplClapping = inputArr[0];

                for (var i = 1; i <= maxShyness; i++)
                {
                    if (inputArr[i] == 0) continue;
                    while (pplClapping < i)
                    {
                        pplToAdd += 1;
                        pplClapping += 1;
                    }
                    pplClapping += inputArr[i];
                }
                result = pplToAdd.ToString();

                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);                
                currentCase += 1;
            }
            fileUtils.WriteStringArrayToFile(output, @"C:\temp\ggcj\A-large.out");
            Console.ReadKey();
        }  
    }
}
