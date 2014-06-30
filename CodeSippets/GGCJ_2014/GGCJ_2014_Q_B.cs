using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSippets.GGCJ_2014
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileUtils = new FileUtils();
            var input =
              fileUtils.ReadFileToStringArray(@"D:\Users\shanebo\Projects\CodeSippets\CodeJamDownloads\2014_Q\B-large-practice.in");            
            var currentCase = 1;
            var caseCount = int.Parse(fileUtils.GetCountOfCases(input));
            var output = new string[caseCount];

            while (currentCase <= caseCount)
            {
                var current = input[currentCase].Split(' ');
                var C = Convert.ToDecimal(current[0]);
                var F = Convert.ToDecimal(current[1]);
                var X = Convert.ToDecimal(current[2]);
                //MAGIC GOES HERE                  
                var times = new List<decimal>(){0,0};
                decimal prodRate = 2;
                times[0] = (X/prodRate)+1;
                times[1] = X / prodRate;                
                decimal cumTime = 0;
                while (times[1] <= times[0])
                {
                times[0] = times[1];                
                cumTime += C / prodRate;
                prodRate += F;                
                times[1]=cumTime + X/prodRate;                             
                }

                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, times.Min().ToString("f9"));
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, times.Min().ToString("f9"));                
                currentCase += 1;
            }
            fileUtils.WriteStringArrayToFile(output,
              @"D:\Users\shanebo\Projects\CodeSippets\CodeJamDownloads\2014_Q\B-large-practice.out");
            Console.ReadKey();
        }  
    }
}
