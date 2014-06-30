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
              fileUtils.ReadFileToStringArray(@"D:\Users\shanebo\Projects\CodeSippets\CodeSippets\GGCJ_2014\Inputs\1B-A-Sample.in");
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

                var stringA = currentRecordSet[0];
                var stringB = currentRecordSet[1];

                //MAGIC GOES HERE  

                foreach (var ch in stringA)
                {
                    if (!stringB.Contains(ch)) result = "FEGLA WON";
                }

                if (result ==string.Empty)
                {
                    var count = 0;
                    for (int i = 0; i < stringA.Length; i++)
                    {
                        if (stringA[i]!=stringB[i])
                        {
                            count += 1;

                        }
                    }





                }


                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);
                linepointer += currentRecordCount + 1;
                currentCase += 1;
            }
            fileUtils.WriteStringArrayToFile(output,
              @"D:\Users\shanebo\Projects\CodeSippets\CodeSippets\GGCJ_2014\Inputs\1B-A-Sample.out");
            Console.ReadKey();
        }  



    }
}
