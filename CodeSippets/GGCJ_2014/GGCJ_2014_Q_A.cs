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
            var input = fileUtils.ReadFileToStringArray(@"C:\CODEJAM\2014_Q_A\A-small-attempt0.in");
            int linepointer =1 , currentCase = 1;            
            var output = new string[int.Parse(fileUtils.GetCountOfCases(input))];
            while (linepointer < input.Length)
            {                
                var result = string.Empty;
                var volunteer1 = int.Parse(input[linepointer]);
                var volunteer2 = int.Parse(input[linepointer + 5]);
                var initialRow = input[linepointer + volunteer1].Split(' ').Select(n => Convert.ToInt32(n)).ToList();
                var secondRow = input[linepointer + 5 + volunteer2].Split(' ').Select(n => Convert.ToInt32(n)).ToList();                
                var matches = secondRow.Where(x => initialRow.Contains(x)).ToList() ;
                
                switch (matches.Count()){
                    case 0:
                        result = "Volunteer cheated!";
                        break;
                    case 1:
                        result = matches[0].ToString();
                        break;
                    default:
                        result = "Bad magician!";
                        break;
                    }
                                                               
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);
                linepointer += 10;
                currentCase += 1;
            }
            fileUtils.WriteStringArrayToFile(output, @"C:\CODEJAM\2014_Q_A\A-small-attempt0.out");
            Console.ReadKey();
        }  
    }
}
