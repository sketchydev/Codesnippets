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
              fileUtils.ReadFileToStringArray(@"D:\Users\shanebo\Projects\CodeSippets\CodeSippets\GGCJ_2014\Inputs\1A-C-small-practice.in");
            var linepointer = 2;
            var currentCase = 1;
            var output = new string[int.Parse(fileUtils.GetCountOfCases(input))];
            var goodies = new List<List<int>>();
            var baddies = new List<List<int>>();

            for (int i = 1; i <= 100000; i++)
            {
                goodies.Add(GoodAlgo());
                baddies.Add(BadAlgo());
            }

            while (linepointer < input.Length)
            {
                var result = string.Empty;                
               List<int> currentRecordSet = input[linepointer].Split(' ').Select(int.Parse).ToList();
                //MAGIC GOES HERE    

                var inGood = goodies.Count(x => x == currentRecordSet);
                var inBad = baddies.Count(x => x == currentRecordSet);



                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);
                linepointer += linepointer + 2;
                currentCase += 1;
            }
            fileUtils.WriteStringArrayToFile(output,
              @"D:\Users\shanebo\Projects\CodeSippets\CodeSippets\GGCJ_2014\Inputs\1A-C-small-practice.out");
            Console.ReadKey();
        } 
 
        public static List<int> GoodAlgo()
        {
            var rnd = new Random();
            var output = Enumerable.Range(0, 1000).ToList();
            
             for (var k = 0; k < 1000; k++)
            {
                var p = rnd.Next(0, 999);
                var a = output[k];
                output[k] = output[p];
                output[p] = a;
            }


            return output;
        }

        public static List<int> BadAlgo()
        {
            var rnd = new Random();
            var output = Enumerable.Range(0, 1000).ToList();

            for (var k = 0; k < 1000; k++)
            {
                var p = rnd.Next(k, 999);
                var a = output[k];
                output[k] = output[p];
                output[p] = a;
            }

            return output;

        }


    }
}
