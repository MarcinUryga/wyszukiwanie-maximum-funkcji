using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    class Mutation : OperationsForNewPopulation
    {
        public Mutation(int[] newPopulationD, int maxNumber, string[] newPopulationB, int[] savetoNewPopulation) : base(newPopulationD, maxNumber)
        {
            parents = newPopulationB;

            Random rand = new Random();
            randTheIndividual = rand.Next(0, base.maxNumber);
            RandomParents();
            ModifyThePopulation();

            displayNewPopulation(setIndividuals(savetoNewPopulation));
        }

        new string[] parents = null;
        string randomParent = null;
        int randTheIndividual;
        int randomGene;

        public override void displayNewPopulation(int[] newPopulation)
        {
            Console.WriteLine("After Mutation");
            for (int j = 0; j < newPopulation.Length; j++)
                Console.WriteLine("New Population after modification: " + newPopulation[j]);
        }

        public override void ModifyThePopulation()
        {
            Console.WriteLine("\t\t\tMUTATION PROCESS");

            Random rand = new Random();
            Console.WriteLine("Rand Individual: " + randTheIndividual + " binary: " + randomParent);
            char[] arrayRandomParent = randomParent.ToCharArray();
            randomGene = rand.Next(0, arrayRandomParent.Length);
           
            if (arrayRandomParent[randomGene] == '0')
                arrayRandomParent[randomGene] = '1';
            else
                arrayRandomParent[randomGene] = '0';
            randomParent = new string(arrayRandomParent);
           
            parents[randTheIndividual] = randomParent;

            newPopulationB = parents;
            for (int i = 0; i < newPopulationB.Length; i++)
                Console.WriteLine(newPopulationB[i]);

            ConvertNewPopulationToDecimal(newPopulationB);

        }

        public override void RandomParents()
        {
            randomParent = parents[randTheIndividual];
        }

       
    }
}
