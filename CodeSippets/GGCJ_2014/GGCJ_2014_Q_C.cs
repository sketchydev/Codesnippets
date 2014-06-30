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
              fileUtils.ReadFileToStringArray(@"D:\Users\shanebo\Projects\CodeSippets\CodeSippets\GGCJ_2014\Inputs\C-Sample.in");            
            var currentCase = 1;
            var caseCount = int.Parse(fileUtils.GetCountOfCases(input));
            var output = new List<string>();
            while (currentCase <= caseCount)
            {
                var result=string.Empty;
                var R = int.Parse(input[currentCase].Split(' ')[0]);
                var C = int.Parse(input[currentCase].Split(' ')[1]);
                var M = int.Parse(input[currentCase].Split(' ')[2]);
                //MAGIC GOES HERE  

                //Create the grid
                var Grid = new List<List<char>>(R);
                var fullOfMines = Math.Floor((decimal)(M/C));
                var safeCells = (R*C) - M;

                //Fill Grid with Mines
                for (var i = 1 ; i <= R; i++)
                {
                    var x = new List<char>();
                    for (var j = 1; j <= C; j++)
                    {
                        x.Add('*');
                    }
                    Grid.Add(x);
                }
                //add the clicked cell
                Grid[0][0] = 'c';
                //Sort ot configuration of safe cells




                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}:", currentCase);
                foreach (var row in Grid)
                {
                    foreach (var col in row)
                    {
                        Console.Write(col.ToString());
                    }
                    Console.Write(Environment.NewLine);
                }
                
                output.Add(String.Format("Case #{0}:", currentCase));
                output.AddRange(Grid.Select(row => row.Aggregate(string.Empty, (current, col) => current + col.ToString())));
                currentCase += 1;
            }
            fileUtils.WriteListToFile(output,
              @"D:\Users\shanebo\Projects\CodeSippets\CodeSippets\GGCJ_2014\Inputs\C-Sample.out");
            Console.ReadKey();
        }  
    }
}
