using System.Collections.Generic;
using System.IO;

namespace CodeSippets
{
    public class FileUtils
    {
        public string[] ReadFileToStringArray(string filename)
        {
            return File.ReadAllLines(filename);
        }
        public string[] GetRecordSet(int start, int length, string[] input)
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
        public string GetCountOfCases(string[] input)
        {
            return input[0];
        }
        public void WriteStringArrayToFile(string[] data, string filename)
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

        public void WriteListToFile(List<string> data, string filename)
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