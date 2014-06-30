using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSippets.Euler
{
    public class Euler24
    {
        static void Main(string[] args)
        {
var perm = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
 
int count = 1;
const int numPerm = 1000000;
while (count < numPerm) {
    int N = perm.Length;
    int i = N-1;
    while (perm[i - 1] >= perm[i]) {
        i = i - 1;
         
    }
    int j = N;
    while (perm[j - 1] <= perm[i - 1]) {
        j = j - 1;
    }
    // swap values at position i-1 and j-1
    swap(i - 1, j - 1, perm);
 
    i++;
    j = N;
    while (i < j) {
            swap(i - 1, j - 1, perm);
            i++;
            j--;
        }
        count++;
    }
     
    string permNum = perm.Aggregate("", (current, t) => current + t);

    Console.WriteLine(permNum);
            Console.ReadKey();
        }


        private static void swap(int i, int j, int[] perm)
        {
            int k = perm[i];
            perm[i] = perm[j];
            perm[j] = k;
        }

    }
}
