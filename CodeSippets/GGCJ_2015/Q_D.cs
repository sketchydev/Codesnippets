using System;

namespace CodeSippets
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileUtils = new FileUtils();
            var input =
              fileUtils.ReadFileToStringArray(@"C:\temp\ggcj\D-small-attempt12.in");
            var currentCase = 1;
            var caseCount = int.Parse(fileUtils.GetCountOfCases(input));
            var output = new string[caseCount];

            var rich = "RICHARD";
            var gab = "GABRIEL";
            while (currentCase <= caseCount)
            {
                var result = string.Empty;
                //MAGIC GOES HERE  

                var X = int.Parse(input[currentCase].Split(' ')[0]);
                var R = int.Parse(input[currentCase].Split(' ')[1]);
                var C = int.Parse(input[currentCase].Split(' ')[2]);

                bool tacticFound = false;
               
                //if X is greater than longest side, rich wins
                tacticFound = X > Math.Max(R, C);

                //if X>=7 and R,C>=3
                if (!tacticFound)
                {
                    if (X>=7 &&R>=3 && C>=3)
                    {
                        tacticFound = true;
                    }
                }

                //Gabriel always wins if
                if (X==1)
                {
                    tacticFound = false;
                }



                result = tacticFound ? rich : gab;

                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);
                currentCase += 1;
            }
            fileUtils.WriteStringArrayToFile(output, @"C:\temp\ggcj\D-small-attempt12_2.out");
            Console.ReadKey();
        }
    }
}
