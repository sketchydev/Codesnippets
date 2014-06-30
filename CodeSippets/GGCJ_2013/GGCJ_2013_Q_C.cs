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
            //100000000000000
            //100000000000000
            var x = genFairAndSquare(1, 100000000000000);

            var fileUtils = new FileUtils();
            var input =
              fileUtils.ReadFileToStringArray(@"D:\Users\shanebo\Projects\CodeSippets\CodeJamDownloads\2013_Q_C\C-large-practice-1.in");            
            var currentCase = 1;
            var caseCount = int.Parse(fileUtils.GetCountOfCases(input));
            var output = new string[caseCount];
            while (currentCase <= caseCount)
            {
                var splitInput = input[currentCase].Split(' ');
                var result = string.Empty;

                var y = x.Where(z => z >= long.Parse(splitInput[0]) && z <= long.Parse(splitInput[1]));

                result = y.Count().ToString();


                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);                
                currentCase += 1;
            }
            fileUtils.WriteStringArrayToFile(output,
              @"D:\Users\shanebo\Projects\CodeSippets\CodeJamDownloads\2013_Q_C\C-large-practice-1.out");
            Console.ReadKey();
        }  

        /*
         * Limits
            Small dataset

            1 ≤ T ≤ 100.
            1 ≤ A ≤ B ≤ 1000.
            First large dataset

            1 ≤ T ≤ 10000.
            1 ≤ A ≤ B ≤ 1014.
            Second large dataset

            1 ≤ T ≤ 1000.
            1 ≤ A ≤ B ≤ 10100. 
        */
        static List<long> genFairAndSquare(long lower, long upper)
        {
            var retval = new List<long>();

            for (long i = lower; i < upper; i++)
            {
                //new string(original.Reverse().ToArray()

                if ((i.ToString() == (new string(i.ToString().Reverse().ToArray()))) && ((i * i).ToString() == new string((i * i).ToString().Reverse().ToArray())))
                {
                    retval.Add(i * i);           
                }      
                
                if(i*i>upper) break;
            }

            return retval;
        }
    }
}
