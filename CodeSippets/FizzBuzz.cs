using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSippets
{
    class FizzBuzz
    {
        static void Main(string[] args)
        {
            foreach (var y in Enumerable.Range(0, 100).Select(x => x%3 == 0 ? (x%5==0?"FizzBuzz":"Fizz") : (x%5==0?"Buzz":x.ToString())))
            {
            Console.WriteLine(y);
            }

            Console.ReadKey();
        }

    }
}
