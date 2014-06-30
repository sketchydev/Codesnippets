using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeSippets
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileUtils = new FileUtils();
            var input =
              fileUtils.ReadFileToStringArray(@"C:\CODEJAM\2014_Q_D\D-small-attempt0.in");            
            var currentCase = 1;
            var lineCounter = 1;
            var caseCount = int.Parse(fileUtils.GetCountOfCases(input));
            var output = new string[caseCount];
            while (currentCase <= caseCount)
            {
                var resultWar=0;
                var resultDeceitful = 0;
                var rounds = int.Parse(input[lineCounter]);
                var Naomi = input[lineCounter + 1].Split(' ').Select(Convert.ToDecimal).ToList();
                var Ken = input[lineCounter + 2].Split(' ').Select(Convert.ToDecimal).ToList();                  

                //Playing WAR
                for (var i = 1; i <= rounds;i++) 
                {
                    decimal chosenNaomi = Naomi.Max();
                    decimal chosenKen = 0;
                
                    //Ken plays smallest block possible to beat Naomi/ if not beatable play smallest???
                chosenKen = Ken.Max() < chosenNaomi ? Ken.Min() : Ken.Where(x => x > chosenNaomi).Min();
                if (chosenNaomi > chosenKen) resultWar += 1;

                //remove the burned blocks
                Naomi.Remove(chosenNaomi);
                Ken.Remove(chosenKen);

                }

                //reset lists
                 Naomi = input[lineCounter + 1].Split(' ').Select(Convert.ToDecimal).ToList();
                 Ken = input[lineCounter + 2].Split(' ').Select(Convert.ToDecimal).ToList();  

                //Playing Deceitful WAR - 
                for (var i = 1; i <= rounds; i++)
                {
                    decimal chosenNaomi = 0;
                    decimal chosenKen = 0;
                    if (Naomi.Min() < Ken.Min())
                    {
                        chosenNaomi = Ken.Max() - new Decimal(0.0000001);
                         Naomi.Remove(Naomi.Min());
                    }
                    else {
                         chosenNaomi = Ken.Max() + new Decimal(0.0000001);
                         Naomi.Remove(Naomi.Min());
                    }

                    //Ken plays smallest block possible to beat Naomi/ if not beatable play smallest???
                    chosenKen = Ken.Max() < chosenNaomi ? Ken.Min() : Ken.Where(x => x > chosenNaomi).Min();
                    if (chosenNaomi > chosenKen) resultDeceitful += 1;

                    //remove the burned blocks                    
                    Ken.Remove(chosenKen);

                }



                    //MAGIC ENDS HERE  
                    Console.WriteLine("Case #{0}: {1} {2}", currentCase, resultDeceitful, resultWar);
                output[currentCase - 1] = String.Format("Case #{0}: {1} {2}", currentCase, resultDeceitful, resultWar);                
                currentCase += 1;
                lineCounter+=3;
            }
            fileUtils.WriteStringArrayToFile(output,
              @"C:\CODEJAM\2014_Q_D\D-small-attempt0.out");
            Console.ReadKey();
        }  
    }
}
