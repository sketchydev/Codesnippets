using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace CodeSippets
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileUtils = new FileUtils();
            var input =
              fileUtils.ReadFileToStringArray(@"D:\Users\shanebo\Projects\CodeSippets\CodeSippets\GGCJ_2014\Inputs\1B-B-large-practice.in");            
            var currentCase = 1;
            var caseCount = int.Parse(fileUtils.GetCountOfCases(input));
            var output = new string[caseCount];
            while (currentCase <= caseCount)
            {
                long result;

                var A = long.Parse(input[currentCase].Split(' ')[0]);
                var B = long.Parse(input[currentCase].Split(' ')[1]);
                var K = long.Parse(input[currentCase].Split(' ')[2]);

                //MAGIC GOES HERE  

                if ((K>A)||(K>B))
                {
                    result = A*B;
                }
                else if ((K == A) && (K == B))
                {
                    result = (A*B) ;
                }
                else if ((K == A))
                {
                    result = (K * B);
                }
                else if ((K == B))
                {
                    result = (K * A);
                }
                //((K<A) && (K < B))
                else 
                {
                    //remove K square
                    result = (K*K);

                    for (long i = K; i < A; i++)
                    {
                        for (long j = 0; j < B; j++)
                        {
                            if ((i & j) < K) result += 1;
                        }
                    }

                    for (long i = K; i < B; i++)
                    {
                        for (long j = 0; j < K; j++)
                        {
                            if ((i & j) < K) result += 1;
                        }
                    }
                }
                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);                
                currentCase += 1;
            }
            fileUtils.WriteStringArrayToFile(output, @"D:\Users\shanebo\Projects\CodeSippets\CodeSippets\GGCJ_2014\Inputs\1B-B-large-practice.out");
            Console.ReadKey();
        }  
    }
}
