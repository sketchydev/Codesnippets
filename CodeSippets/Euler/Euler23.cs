using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSippets.Euler
{
    public class Euler23
    {
        static void Main(string[] args)
        {
            var abundant = new List<int>();

            for (int i = 1; i < 28123; i++)
            {
                var divisors = new List<int>();
                var y = 1;
                while (y <= Math.Sqrt(i))
                {
                    if (i%y==0)
                    {
                        divisors.Add(y);
                        if (y>1)
                        {
                            divisors.Add(i / y);    
                        }                        
                    }
                    y += 1;
                }
                divisors = divisors.Distinct().ToList();

                if (divisors.Sum() > i)
                {
                    abundant.Add(i);
                }
            }

            var abundantArray = abundant.ToArray();

            var abundantSums = new List<int>();
            for (var i = 0; i < abundant.Count; i++)
            {
                for (var j = i; j < abundant.Count; j++)
                {
                    abundantSums.Add(abundantArray[i] + abundantArray[j]);
                }
            }
            abundantSums = abundantSums.Where(x=>x<=28123).Distinct().ToList();
            var result = 0;
            for (int i = 1; i < 28123; i++)
            {
                if (!abundantSums.Contains(i))
                {
                    result += i;
                }
            }
            Console.WriteLine(result);
            Console.ReadKey();
        }


    }
}
