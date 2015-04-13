using System;
using System.CodeDom;

namespace CodeSippets
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileUtils = new FileUtils();
            var input =
              fileUtils.ReadFileToStringArray(@"C:\Git\Personal\Codesnippets\CodeJamDownloads\APAC_B\sample.in");
            var linepointer = 1;
            var currentCase = 1;
            var output = new string[int.Parse(fileUtils.GetCountOfCases(input))];
            while (linepointer < input.Length)
            {
                var result = string.Empty;
                var meta = input[linepointer].Split();
                var currentRecordCount = int.Parse(meta[0]);
                var DIR = meta[1];
                var currentRecordSet = fileUtils.GetRecordSet(linepointer + 1,
                                       currentRecordCount,
                                       input);
                //MAGIC GOES HERE  
                if (DIR == "right")
                {
                    foreach (var row in currentRecordSet)
                    {
                        var col = row.Split();
                        for (var i = currentRecordCount-1; i > -1; i--)
                        {
                            if (col[i]==col[i-1])
                            {
                                col[i] = (int.Parse(col[i]) *2).ToString();
                            }

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
              @"C:\Git\Personal\Codesnippets\CodeJamDownloads\APAC_B\sample.out");
            Console.ReadKey();
        }  
    }
}
