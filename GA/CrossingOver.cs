using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    class CrossingOver : OperationsForNewPopulation
    {
        public CrossingOver(int[] newPopulationD, int maxNumber, int[] savetoNewPopulation) : base(newPopulationD, maxNumber)
        {
            parents = new string[newPopulationD.Length/2, 2];
            children = new string[newPopulationD.Length/2, 2];
            RandomParents();
            ModifyThePopulation();


            displayNewPopulation(setIndividuals(savetoNewPopulation));
        }

        private new string[,] parents;
        private string[,] children;
        List<string> newPopulation = new List<string>();


        public override void displayNewPopulation(int[] newPopulation)
        {
            Console.WriteLine("After CrossingOver");
            for (int j = 0; j < newPopulation.Length; j++)
                Console.WriteLine("New Population after modification: " + newPopulation[j]);
        }

        public override void RandomParents()
        {
            Random rand = new Random();
            int firstParent;
            int secondParent;

            Console.WriteLine("\t\tCROSSING OVER PROCESS");
            Console.WriteLine("\t\t   SELECTED PARENTS");

            for (int i = 0; i < newPopulationB.Length/2 ; i++)
            {
                firstParent = rand.Next(0, maxNumber);
                secondParent = rand.Next(0, maxNumber);
                parents[i, 0] = newPopulationB[firstParent];
                parents[i, 1] = newPopulationB[secondParent];

                //Console.WriteLine("Osobnik " + i + ": " + firstParent + " " + secondParent);

                if (firstParent == secondParent)
                    i--;
            }

            for(int i=0;i<newPopulationB.Length/2;i++)
            {
                Console.Write(i + " couple of parents: ");
                for (int j = 0; j < 2; j++)
                    Console.Write(parents[i, j] + "   ");
                Console.WriteLine();
            }
            Console.WriteLine();

        }

        public override void ModifyThePopulation()
        {
            Random rand = new Random();
            int crossingOverPoint;
            string[] children = new string[2];
            string tmp = "0000";
            
            for (int i = 0; i < newPopulationB.Length / 2; i++)
            {
                crossingOverPoint = rand.Next(1, maxNumber);
                Console.WriteLine("Crossing Over point: " + crossingOverPoint);
                //Console.WriteLine("ilosc znakow: " + (parents[i, 0].Length - crossingOverPoint));
                tmp = parents[i, 0].Substring(crossingOverPoint, parents[i, 0].Length - crossingOverPoint);
                children[0] = parents[i, 0].Substring(0, crossingOverPoint) + parents[i, 1].Substring(crossingOverPoint, parents[i, 1].Length - crossingOverPoint);
                children[1] = parents[i, 1].Substring(0, crossingOverPoint) + tmp;
                Console.WriteLine("chlidren from " + i + " couple  " + children[0] + "     " + children[1]);
                for (int j = 0; j < children.Length; j++)
                {
                    //if(Convert.ConvertToDecimals(children[j]) > Convert.ConvertToDecimals(parents[i,j]))
                        newPopulation.Add(children[j]);
                    //else
                      //  newPopulation.Add(parents[i,j]);

                }
            }

            Console.WriteLine();
            Console.WriteLine("\t\t\tnew population");

            for(int i = 0;i<newPopulationB.Length;i++)
            {
                newPopulationB[i] = newPopulation[i];
                Console.WriteLine(newPopulationB[i]);
            }

            ConvertNewPopulationToDecimal(newPopulationB);
        }
    }
}
