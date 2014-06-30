using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Linq;
using CodeSippets;

public class B
{
        static void Main(string[] args)
        {
            var fileUtils = new FileUtils();
            var input =
              fileUtils.ReadFileToStringArray(@"D:\Users\shanebo\Projects\CodeSippets\CodeJamDownloads\2014_2\B-small-practice.in");
            var linepointer = 1;
            var currentCase = 1;
            var output = new string[int.Parse(fileUtils.GetCountOfCases(input))];
            while (linepointer < input.Length)
            {
                var result = 0;                
                //MAGIC GOES HERE  

                int N = int.Parse(input[linepointer]);
                int[] A = input[linepointer+1].Split().Select(int.Parse).ToArray();

                int[] idx = new int[N];
             
                for (int i = 0; i < N; i++)
                idx[i] = i;
                Array.Sort(A, idx);
            
            for (int i = 0; i < N; i++)
            {
                int nl = 0;
                int nr = 0;
                for (int j = 0; j < N; j++)
                {
                    if (A[j] <= A[i]) continue;
                    if (idx[j] < idx[i])
                        nl++;
                    else
                        nr++;
                }
                result += Math.Min(nl, nr);
            }

                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);
                linepointer += 2;
                currentCase += 1;
            }
            fileUtils.WriteStringArrayToFile(output,
              @"D:\Users\shanebo\Projects\CodeSippets\CodeJamDownloads\2014_2\B-small-practice.out.working");
            Console.ReadKey();
        }

    }

