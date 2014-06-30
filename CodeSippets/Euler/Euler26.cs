using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSippets.Euler
{
    public class Euler26
    {
        private static void Main(string[] args)
        {
            var results = new Dictionary<decimal, decimal>();

            for (decimal i = 2; i < 1000; i++)
            {                
                results.Add(i, 1/i);
            }

            foreach (var dec in results)
            {

                //adjust window size
                for (int j = 0; j < dec.ToString().Length; j++)
                {
                    var window = dec.ToString().Substring(0, j);
                    //move window


                }


            }


            Console.ReadKey();

        }
    }
}
