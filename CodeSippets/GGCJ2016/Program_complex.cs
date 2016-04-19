using System;

namespace CodeSippets
{
    class Program
    {
        static void Main(string[] args)
        {            
            var input =
              FileUtils.ReadFileToStringArray(@"c:\temp\GGCJ_\Inputs\.in");
            var linepointer = 1;
            var currentCase = 1;
            var output = new string[int.Parse(FileUtils.GetCountOfCases(input))];
            while (linepointer < input.Length)
            {
                var result = string.Empty;
                var currentRecordCount = int.Parse(input[linepointer]);
                var currentRecordSet = FileUtils.GetRecordSet(linepointer + 1,
                                       currentRecordCount,
                                       input);
                //MAGIC GOES HERE  
                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = $"Case #{currentCase}: {result}";
                linepointer += currentRecordCount + 1;
                currentCase += 1;
            }
            FileUtils.WriteStringArrayToFile(output,@"c:\temp\GGCJ_\Outputs\.out");
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
