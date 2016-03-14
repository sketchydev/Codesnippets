using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSippets
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileUtils = new FileUtils();
            var input =
              fileUtils.ReadFileToStringArray(@"C:\temp\ggcj\sample_c.in");            
            var currentCase = 1;
            var currentLine = 1;
            var caseCount = int.Parse(fileUtils.GetCountOfCases(input));
            var output = new string[caseCount];



            while (currentCase <= caseCount)
            {
                var result=string.Empty;
                //MAGIC GOES HERE  
                var L = input[currentLine].Split(' ')[0];
                var X = input[currentLine].Split(' ')[1];
                var str = input[currentLine + 1];

                str = string.Concat(Enumerable.Repeat(str, int.Parse(X)));

                if (str.Distinct().Count() == 1)
                {
                    result = "NO";
                }

                if (str.Length < 3)
                {
                    result = "NO";
                }
                if (result == String.Empty)
                {
                    var stringArr = str.ToCharArray().Select(c => c.ToString()).ToArray();
                    var reduction = stringArr.Aggregate(mq);

                    result = reduction == "-1" ? "YES" : "NO";

                }
                if (result == string.Empty) result = "NO";


                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);                
                currentCase += 1;
                currentLine += 2;
            }
                   //fileUtils.WriteStringArrayToFile(output,@"C:\temp\ggcj\C-small-practice.out");;
            Console.ReadKey();
        }

        private static string mq(string left, string right)
        {
            var multiply = new Dictionary<string, string>
            {
                {"1,1", "1"},
                {"1,i", "i"},
                {"1,j", "j"},
                {"1,k", "k"},
                {"1,-1", "-1"},
                {"1,-i", "-i"},
                {"1,-j", "-j"},
                {"1,-k", "-k"},
                {"-1,1", "-1"},
                {"-1,i", "-i"},
                {"-1,j", "-j"},
                {"-1,k", "-k"},
                {"-1,-1", "1"},
                {"-1,-i", "i"},
                {"-1,-j", "j"},
                {"-1,-k", "k"},
                {"i,1", "i"},
                {"i,i", "-1"},
                {"i,j", "k"},
                {"i,k", "-j"},
                {"i,-1", "-i"},
                {"i,-i", "1"},
                {"i,-j", "-k"},
                {"i,-k", "j"},
                {"-i,1", "-i"},
                {"-i,i", "1"},
                {"-i,j", "-k"},
                {"-i,k", "j"},
                {"-i,-1", "i"},
                {"-i,-i", "-1"},
                {"-i,-j", "k"},
                {"-i,-k", "-j"},
                {"j,1", "j"},
                {"j,i", "-k"},
                {"j,j", "-1"},
                {"j,k", "i"},
                {"j,-1", "-j"},
                {"j,-i", "k"},
                {"j,-j", "1"},
                {"j,-k", "-i"},
                {"-j,1", "-j"},
                {"-j,i", "k"},
                {"-j,j", "1"},
                {"-j,k", "-i"},
                {"-j,-1", "j"},
                {"-j,-i", "-k"},
                {"-j,-j", "-1"},
                {"-j,-k", "i"},
                {"k,1", "k"},
                {"k,i", "j"},
                {"k,j", "-i"},
                {"k,k", "-1"},
                {"k,-1", "-k"},
                {"k,-i", "-j"},
                {"k,-j", "-i"},
                {"k,-k", "1"},
                {"-k,1", "-k"},
                {"-k,i", "-j"},
                {"-k,j", "-i"},
                {"-k,k", "1"},
                {"-k,-1", "k"},
                {"-k,-i", "j"},
                {"-k,-j", "-i"},
                {"-k,-k", "-1"}
            };

            var join = left + "," + right;
            return multiply[join];
        }
    }
}
