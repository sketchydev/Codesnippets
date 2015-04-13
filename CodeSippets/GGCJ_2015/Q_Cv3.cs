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
              fileUtils.ReadFileToStringArray(@"C:\Users\booths\Downloads\c-small-practice.in");            
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

                if (str.Length <= 3)
                {
                    result = str == "ijk" ? "YES" : "NO";
                }
                if (result == String.Empty)
                {
                    for (int i = 1; i < str.Length; i++)
                    {
                        var subI = str.Substring(0, i);
                        if (subI.ToCharArray().Aggregate(mq) == 'i')
                        {
                            for (int j = 1; j < str.Length - i; j++)
                            {
                                var subJ = str.Substring(i, j);
                                var subK = str.Remove(0, j);

                                var
                                blnJ = subJ
                                    .ToCharArray().Aggregate(mq) == 'j';
                                var blnK = subK
                                    .ToCharArray().Aggregate(mq) == 'k';

                                if (blnJ && blnK) result = "YES";

                                if (result != string.Empty) break;
                            }
                            if (result != string.Empty) break;
                        }
                    }
                }
                if (result == string.Empty) result = "NO";


                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);                
                currentCase += 1;
                currentLine += 2;
            }
            fileUtils.WriteStringArrayToFile(output,@"C:\temp\ggcj\C-small-practice.out");;
            Console.ReadKey();
        }

        private static char mq(char left, char right)
        {
            if (left == right) return '1';
            if (left=='1') return right;
            if (right == '1') return left;
            if (left == 'i' && right == 'j') return 'k';
            if (left == 'i' && right == 'k') return 'j';
            if (left == 'j' && right == 'i') return 'k';
            if (left == 'j' && right == 'k') return 'i';
            if (left == 'k' && right == 'i') return 'j';
            if (left == 'k' && right == 'j') return 'i';
            throw new Exception();
        }
    }
}
