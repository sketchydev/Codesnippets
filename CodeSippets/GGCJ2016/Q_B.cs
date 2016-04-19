using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodeSippets
{
    class Program
    {
        public static void Main(string[] args)
        {            
            var input =
              FileUtils.ReadFileToStringArray(@"c:\temp\GGCJ_2016\Inputs\B-large.in");            
            var currentCase = 1;
            var caseCount = int.Parse(FileUtils.GetCountOfCases(input));
            var output = new string[caseCount];
            while (currentCase <= caseCount)
            {
                var result=string.Empty;
                var inputString = input[currentCase];

                //inputStringLength <= 10 for small, <=100 for large
                // - = face down
                // + = face up
                var targetState = new string('+',inputString.Length);
                var targetStateNegative = new string('-', inputString.Length);
                var flipcounter = 0;
                //special cases

                if (inputString == targetState)
                {
                    result = "0";
                }
                if (inputString == targetStateNegative)
                {
                    result = "1";
                }
                //end special cases

                //strategy
                //-trim trailing ++ = free                    
                //-flip leading ++ = 1 flip
                //-flip stack = 1 flip
                //-repeat

                while (inputString.Contains("-") || inputString !=targetState)
                {
                    //trim
                    inputString = inputString.TrimEnd('+');
                    if (!inputString.Contains("-") || inputString == targetState) break;

                    var flipped = false;
                    //flip leading +
                    for (int i = 0; i < inputString.Length; i++)
                    {
                        if (inputString[i]=='+')
                        {
                            var sb = new StringBuilder(inputString) {[i] = '-'};
                            inputString = sb.ToString();
                            flipped = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (flipped) flipcounter += 1;
                    if (!inputString.Contains("-") || inputString == targetState) break;
                    //flip stack
                    var arr = inputString.ToCharArray();
                    Array.Reverse(arr);
                    inputString = new string(arr);

                    var sb2 = new StringBuilder(inputString);
                    for (int i = 0; i < inputString.Length; i++)
                    {
                        if (inputString[i] == '+')
                        {
                            sb2[i] = '-';
                        }
                        else
                        {
                            sb2[i] = '+';
                        }
                    }
                    inputString = sb2.ToString();
                    flipcounter += 1;
                }
                result = flipcounter.ToString();
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = $"Case #{currentCase}: {result}";                
                currentCase += 1;
            }
            FileUtils.WriteStringArrayToFile(output, @"c:\temp\GGCJ_2016\Outputs\B-large.out");
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
