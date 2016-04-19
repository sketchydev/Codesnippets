using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeSippets
{
    class Program
    {
        public static void Main(string[] args)
        {            
            var input =
              FileUtils.ReadFileToStringArray(@"c:\temp\GGCJ_2016\Inputs\D-small-attempt0.in");            
            var currentCase = 1;
            var caseCount = int.Parse(FileUtils.GetCountOfCases(input));
            var output = new string[caseCount];
            while (currentCase <= caseCount)
            {
                var result=string.Empty;
                var inputs = input[currentCase].Split(' ');
                var K = inputs[0]; //original sequence length i.e. LGL = 3
                var C = inputs[0]; // complexity level
                var S = inputs[0]; // is it possible to clean S tiles and confirm a G exists in the sequence?
                //MAGIC GOES HERE  

                //for the small case it's always possible to clean K tiles and get an answer.
                if (K == S)
                {
                    result = string.Join(" ", Enumerable.Range(1, int.Parse(K)).Select(x => x.ToString()).ToArray());
                }
                else
                {
                    
                }

                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = $"Case #{currentCase}: {result}";                
                currentCase += 1;
            }
            FileUtils.WriteStringArrayToFile(output, @"c:\temp\GGCJ_2016\Outputs\D-small-attempt0.out");
            Console.ReadKey();
        }  
    }

    public static class FileUtils
    {
        public static string[] ReadFileToStringArray(string filename)
        {
            return File.ReadAllLines(filename);
        }
        public static string[] GetRecordSet(int start, int length, string[] input)
        {
            var output = new string[length];
            var pointer = 0;
            for (var i = start; i < start + length; i++)
            {
                output[pointer] = input[i];
                pointer++;
            }
            return output;
        }
        public static string GetCountOfCases(string[] input)
        {
            return input[0];
        }
        public static void WriteStringArrayToFile(string[] data, string filename)
        {
            try { File.Delete(filename); }
            catch
            {/*Intentionally empty*/}
            var sw = new StreamWriter(filename, true);
            foreach (var line in data)
            {
                sw.WriteLine(line);
            }
            sw.Close();
        }

        public static void WriteListToFile(List<string> data, string filename)
        {
            try { File.Delete(filename); }
            catch
            {/*Intentionally empty*/}
            var sw = new StreamWriter(filename, true);
            foreach (var row in data)
            {
                sw.WriteLine(row);
            }
            sw.Close();
        }
    }
}
