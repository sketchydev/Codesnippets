using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeSippets.GGCJ2016
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var input =
                 FileUtils.ReadFileToStringArray(@"C:\temp\GGCJ_2016\Inputs\A-large.in");         
            
            var currentCase = 1;
            var caseCount = int.Parse(FileUtils.GetCountOfCases(input));
            var output = new string[caseCount];
            while (currentCase <= caseCount)
            {
                var result=string.Empty;
                //MAGIC GOES HERE  

                var testString = "0123456789";

                var startNumber = long.Parse(input[currentCase]);                
                var asleep = false;


                for (var i = 0; ((i + 1) * startNumber) < long.MaxValue; i++)
                {
                    var currentNumber = (i + 1)*startNumber;
                    if (currentNumber == 0)
                    {
                        asleep = true;
                        result = "INSOMNIA";
                    }
                    testString = currentNumber
                        .ToString()
                        .ToCharArray()
                        .Aggregate(testString, (current, c) =>
                            current.Replace(c.ToString(), ""));

                    if (testString == string.Empty)
                    {
                        asleep = true;
                        result = currentNumber.ToString();
                    }
                    if (asleep) break;                                        
                }                               
                

                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = $"Case #{currentCase}: {result}";                
                currentCase += 1;
            }
            FileUtils.WriteStringArrayToFile(output, @"C:\temp\GGCJ_2016\Outputs\A-large.out");
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
