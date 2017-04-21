using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    abstract class OperationsForNewPopulation
    {
        public OperationsForNewPopulation(int[] newPopulationD, int maxNumber)
        {
            this.maxNumber = (int)Math.Log(maxNumber, 2);
            parents = new string[2];
            newPopulationB = new string[newPopulationD.Length];
            newPopulationInDecimal = new int[newPopulationD.Length];
            for (int i = 0; i < newPopulationD.Length; i++)
                newPopulationB[i] = Convert.ConvertToBinary(newPopulationD[i], maxNumber);
        }

        protected string[] newPopulationB;
        protected string[] parents;
        protected int maxNumber;
        protected int[] newPopulationInDecimal;

        public string[] NEWPOPULATION
        {
            get { return newPopulationB; }
        }

        public int[] NewPopulationInDecimal
        {
            get { return newPopulationInDecimal; }
        }

        protected int[] setIndividuals(int[] individuals)
        {
            for (int i = 0; i < individuals.Length; i++)
                individuals[i] = NewPopulationInDecimal[i];

            return individuals;
        }

        public abstract void RandomParents();

        public abstract void ModifyThePopulation();

        public abstract void displayNewPopulation(int[] indiv);

        public void ConvertNewPopulationToDecimal(string[] population)
        {
            for (int i = 0; i < newPopulationB.Length; i++)
                newPopulationInDecimal[i] = Convert.ConvertToDecimals(population[i]);
        }
    }
}
