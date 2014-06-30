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
              fileUtils.ReadFileToStringArray(@"D:\Users\shanebo\Projects\CodeSippets\CodeJamDownloads\2014_2\A-large-practice.in");
            var linepointer = 1;
            var currentCase = 1;
            var output = new string[int.Parse(fileUtils.GetCountOfCases(input))];
            while (linepointer < input.Length)
            {
                var result = 0;                
                var diskSize = int.Parse(input[linepointer].Split(' ')[1]);
                List<int> currentRecordSet = input[linepointer+1].Split(' ')
                    .Select(n => Convert.ToInt32(n)).ToList();
                //MAGIC GOES HERE  
                currentRecordSet.Sort();
                while (currentRecordSet.Count>=2)
                {
                    var a = currentRecordSet.Max();
                    var b = currentRecordSet.Take(currentRecordSet.Count-1).Where(n => n + a <= diskSize);
                    var enumerable = b as List<int> ?? b.ToList();
                    if (enumerable.Any())
                    {
                        currentRecordSet.Remove(enumerable.Max());
                    }
                    currentRecordSet.Remove(a);                    
                    result += 1;
                }

                if (currentRecordSet.Count>0) result += 1;            

                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);
                linepointer += 2;
                currentCase += 1;
            }
            fileUtils.WriteStringArrayToFile(output,
              @"D:\Users\shanebo\Projects\CodeSippets\CodeJamDownloads\2014_2\A-large-practice.out");
            Console.ReadKey();
        }  
    }
}
