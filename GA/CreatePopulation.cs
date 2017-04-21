using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    class CreatePopulation
    {
        public CreatePopulation()
        {
            maxNumber = 16;
            amountOfPhenotypes = 4;
            phenotypes = new int[amountOfPhenotypes];
            initialPhenotypesInTheFirstGeneration = new int[amountOfPhenotypes];

            phenotypesInBinary = new string[amountOfPhenotypes];

            //setMinimalValuesForPhenotypes();
            GenerateRandomNumbers(maxNumber);
            individualsInBinary();
        }

        public CreatePopulation(int maxNumber, int amountOfPhenotypes)
        {
            this.maxNumber = maxNumber;
            this.amountOfPhenotypes = amountOfPhenotypes;
            GenerateRandomNumbers(maxNumber);
            individualsInBinary();
        }

        public int[] initialPhenotypesInTheFirstGeneration;
        private int amountOfPhenotypes;
        private int maxNumber;
        private int[] phenotypes;
        private string[] phenotypesInBinary;

        public int MAXnumber
        {
            get { return maxNumber; }
        }

        private void setMinimalValuesForPhenotypes()
        {
            for (int i = 0; i < amountOfPhenotypes; i++)
            {
                phenotypes[i] = 0;
                initialPhenotypesInTheFirstGeneration[i] = phenotypes[i];

            }
        }

        public int AmountOfPhenotypes
        {
            set { amountOfPhenotypes = value; }
            get { return amountOfPhenotypes; }
        }

        public int[] Individuals
        {
            get { return phenotypes; }
            set { phenotypes = value; }
        }

        public void GenerateRandomNumbers(int maxNumber)
        {
            Random rand = new Random();
            for (int i = 0; i < amountOfPhenotypes; i++)
                phenotypes[i] = rand.Next(0,maxNumber);
        }

        public void individualsInBinary()
        {
            for(int i=0; i<amountOfPhenotypes;i++)
                phenotypesInBinary[i] = Convert.ConvertToBinary(phenotypes[i], maxNumber);
        }

        public void displayIndividualsInBinary()
        {
            Console.WriteLine("\t\t\tBINARY");
     
            foreach (string phenotype in phenotypesInBinary)
                Console.WriteLine(phenotype);
        }

        public void displayIndividualsInDecimals()
        {
            Console.WriteLine("\t\tGENERATED INDIVIDUALS");
            Console.WriteLine("\t\t\tDECIMALS");

            foreach (int phenotype in phenotypes)
                Console.WriteLine(phenotype);
        }
    }
}
