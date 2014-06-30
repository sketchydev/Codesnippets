using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSippets.GGCJ_2014
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var fileUtils = new FileUtils();
            var input =
              fileUtils.ReadFileToStringArray(@"D:\Users\shanebo\Projects\CodeSippets\CodeSippets\GGCJ_2014\Inputs\1A-A-small-practice.in");
            var linepointer = 1;
            var currentCase = 1;
            var output = new string[int.Parse(fileUtils.GetCountOfCases(input))];
            while (linepointer < input.Length)
            {
                var result = string.Empty;
                var lights = int.Parse(input[linepointer].Split(' ')[0]);
                var switches = int.Parse(input[linepointer].Split(' ')[1]);
                var startConfig = input[linepointer + 1].Split(' ').ToList();
                var targetConfig = input[linepointer + 2].Split(' ').ToList();                
                var count = 0;
                var pointer = 0;
                bool resultFound = true;
                //MAGIC GOES HERE  

                if (!startConfig.OrderBy(x => Convert.ToInt32(x, 2)).SequenceEqual(targetConfig.OrderBy(x => Convert.ToInt32(x, 2))))
                {
                    resultFound = false;
                    while (pointer < switches)
                    {
                        count += 1;
                        for (var j = pointer; j < switches; j++)
                        {
                            var testConfig = new List<string>();
                            foreach (var x in startConfig.Select(t => t.ToArray()))
                            {
                                x[j] = x[j] == '1' ? '0' : '1';
                                testConfig.Add(new string(x));
                            }

                            if (!testConfig.OrderBy(x => Convert.ToInt32(x, 2)).SequenceEqual(
                                    targetConfig.OrderBy(x => Convert.ToInt32(x, 2)))) continue;
                            resultFound = true;
                            break;
                        }
                        if (resultFound) break;
                        pointer += 1;
                    }
                }

                result = resultFound ? count.ToString() : "NOT POSSIBLE";
                
                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);
                linepointer += 3;
                currentCase += 1;
            }
              fileUtils.WriteStringArrayToFile(output, @"D:\Users\shanebo\Projects\CodeSippets\CodeSippets\GGCJ_2014\Inputs\1A-A-small-practice.out");
            Console.ReadKey();
        }  
    }
}
