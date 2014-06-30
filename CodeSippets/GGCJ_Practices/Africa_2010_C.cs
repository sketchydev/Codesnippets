using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeSippets
{
    class Program
    {      
        static void Main(string[] args)
        {
            var fileUtils = new FileUtils();
            var input =
              fileUtils.ReadFileToStringArray(@"D:\Users\shanebo\Projects\CodeSippets\CodeSippets\GGCJ_Practices\Inputs\Africa-C-large-practice.in");            
            var currentCase = 1;
            var caseCount = int.Parse(fileUtils.GetCountOfCases(input));
            var output = new string[caseCount];

            var keypadHash = new Dictionary<char, int>
                                 {
                                    {' ',0},
                                    {'a',2},
                                    {'b',22},
                                    {'c',222},
                                    {'d',3},
                                    {'e',33},
                                    {'f',333},
                                    {'g',4},
                                    {'h',44},
                                    {'i',444},
                                    {'j',5},
                                    {'k',55},
                                    {'l',555},
                                    {'m',6},
                                    {'n',66},
                                    {'o',666},
                                    {'p',7},
                                    {'q',77},
                                    {'r',777},
                                    {'s',7777},
                                    {'t',8},
                                    {'u',88},
                                    {'v',888},
                                    {'w',9},
                                    {'x',99},
                                    {'y',999},
                                    {'z',9999}
                                 };
            while (currentCase <= caseCount)
            {
                var result=string.Empty;
                //MAGIC GOES HERE  
                var inarray = input[currentCase].ToCharArray();

                foreach (var c in inarray)
                {
                    var parsed = keypadHash[c];
                    if (result!=string.Empty && result.Last().Equals(parsed.ToString().First()))
                    {
                        result += " ";
                    }
                    result += parsed;
                }


                //MAGIC ENDS HERE  
                Console.WriteLine("Case #{0}: {1}", currentCase, result);
                output[currentCase - 1] = String.Format("Case #{0}: {1}", currentCase, result);                
                currentCase += 1;
            }

            fileUtils.WriteStringArrayToFile(output,
              @"D:\Users\shanebo\Projects\CodeSippets\CodeSippets\GGCJ_Practices\Inputs\Africa-C-large-practice.out");
             

            Console.ReadKey();
        }  
        /*
        public static string reversee(string inputstring)
        {
            var reverseHash = new Dictionary<int, char>
                                 {
                                    {0,' '},
                                    {2,'a'},
                                    {22,'b'},
                                    {222,'c'},
                                    {3,'d'},
                                    {33,'e'},
                                    {333,'f'},
                                    {4,'g'},
                                    {44,'h'},
                                    {444,'i'},
                                    {5,'j'},
                                    {55,'k'},
                                    {555,'l'},
                                    {6,'m'},
                                    {66,'n'},
                                    {666,'o'},
                                    {7,'p'},
                                    {77,'q'},
                                    {777,'r'},
                                    {7777,'s'},
                                    {8,'t'},
                                    {8,'u'},
                                    {8,'v'},
{9,'w'},
{99,'x'},
{999,'y'},
{9999,'z'},


                                 };

        }


        */
     
    }
}


 