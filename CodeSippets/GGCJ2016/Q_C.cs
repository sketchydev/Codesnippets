using System;
using System.Collections.Generic;
using System.IO;

namespace CodeSippets.GGCJ2016
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //sample range: 
            //bin: 100001 - > 111111
            //dec: 33 -> 63

            //small range:
            // binary: 1000000000000001 -> 1111111111111111 
            // dec:32769 -> 65535

            //large range: 
            //bin:10000000000000000000000000000001 -> 11111111111111111111111111111111
            //dec: 2147483649 -> 4294967295

            var N = 32;
            var J = 500;
            long l = 2147483649;
            long u = 4294967295;

            var output = new string[51];
            Console.WriteLine("Case #1:");
            output[0] = $"Case #1:";
            

            var candidateJamCoins = new List<string>();            
            for (long i = l; i < u+1; i++)
            {
                var candidateString = OtherUtils.DecimalToArbitrarySystem(i, 2);
                if (candidateString.EndsWith("1"))
                {
                   candidateJamCoins.Add(candidateString);
                }

            }
            var JamcoinsFound = 0;
            foreach (var c in candidateJamCoins)
            {
                var validJamCoin = true;
                var outputString = c;
                for (int i = 2; i < 11; i++)
                {
                    var res = OtherUtils.ArbitraryToDecimalSystem(c, i);
                    var divisor = OtherUtils.isPrime(res);
                    if (divisor==-1)
                    {
                        validJamCoin = false;
                        break;
                    }
                    outputString = $"{outputString} {divisor}";
                }
                if (validJamCoin)
                {
                    JamcoinsFound += 1;
                    Console.WriteLine(outputString);
                    output[JamcoinsFound] = outputString;
                }
                if (JamcoinsFound == J)
                {
                    break;
                }
            }

            var x = candidateJamCoins.Count;                                 
            
            FileUtils.WriteStringArrayToFile(output,@"c:\temp\GGCJ_2016\Outputs\c-small-attempt0.out");
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

    public static class OtherUtils
    {
        //From http://www.pvladov.com/2012/05/decimal-to-arbitrary-numeral-system.html
        public static string DecimalToArbitrarySystem(long decimalNumber, int radix)
        {
            const int BitsInLong = 64;
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (radix < 2 || radix > Digits.Length)
                throw new ArgumentException("The radix must be >= 2 and <= " + Digits.Length.ToString());

            if (decimalNumber == 0)
                return "0";

            int index = BitsInLong - 1;
            long currentNumber = Math.Abs(decimalNumber);
            char[] charArray = new char[BitsInLong];

            while (currentNumber != 0)
            {
                int remainder = (int)(currentNumber % radix);
                charArray[index--] = Digits[remainder];
                currentNumber = currentNumber / radix;
            }

            string result = new String(charArray, index + 1, BitsInLong - index - 1);
            if (decimalNumber < 0)
            {
                result = "-" + result;
            }

            return result;
        }

        //from http://www.pvladov.com/2012/07/arbitrary-to-decimal-numeral-system.html
        public static long ArbitraryToDecimalSystem(string number, int radix)
        {
            const string Digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            if (radix < 2 || radix > Digits.Length)
                throw new ArgumentException("The radix must be >= 2 and <= " +
                    Digits.Length.ToString());

            if (String.IsNullOrEmpty(number))
                return 0;

            // Make sure the arbitrary numeral system number is in upper case
            number = number.ToUpperInvariant();

            long result = 0;
            long multiplier = 1;
            for (int i = number.Length - 1; i >= 0; i--)
            {
                char c = number[i];
                if (i == 0 && c == '-')
                {
                    // This is the negative sign symbol
                    result = -result;
                    break;
                }

                int digit = Digits.IndexOf(c);
                if (digit == -1)
                    throw new ArgumentException(
                        "Invalid character in the arbitrary numeral system number",
                        "number");

                result += digit * multiplier;
                multiplier *= radix;
            }

            return result;
        }

        //from http://stackoverflow.com/questions/15743192/check-if-number-is-prime-number
        public static int isPrime(long number)
        {
            int boundary = (int) Math.Floor(Math.Sqrt(number));

            switch (number)
            {
                case 1:
                    return -1;
                case 2:
                    return -1;
            }

            for (var i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return i;
            }

            return -1;
        }
    }


}
