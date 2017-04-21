using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    class RouletteWheel
    {
        public RouletteWheel(int[] individuals, int amountOfIndividuals)
        {
            this.individuals = individuals;
            functionResults = new int[amountOfIndividuals];
            RandomlySelectedIndividuals = new int[amountOfIndividuals];
            rateAdaptation = new double[individuals.Length, 3];
        }

        public int[] setIndividuals(int[] sendIndividuals)
        {
            for (int i = 0; i < individuals.Length; i++)
                individuals[i] = sendIndividuals[i];

            return individuals;
        }

        public int[] Individuals
        {
            get { return individuals; }
            //set { Individuals = value; }
        }

        public int[] RANDOMLYselectedINDIVIDUALS
        {
            get { return RandomlySelectedIndividuals; }
        }

        private int[] individuals;
        private int[] functionResults;
        private int[] RandomlySelectedIndividuals;
        double[,] rateAdaptation;

        public int fitnessFunction(int number)
        {
            int y;
            y = number * number;
            return y;
        }

        public void CountFitnessFunctionForPopulation()
        {
            Console.WriteLine("\t\tFITNESS FUNCTION");

            for (int i = 0; i < functionResults.Length; i++)
            {
                functionResults[i] = fitnessFunction(individuals[i]);
                Console.WriteLine("f(" + individuals[i] + ") = " + functionResults[i]);
            }
        }

        public void SetTheInitialCondition()
        {
            for (int i = 0; i < Individuals.Length; i++)
                for (int j = 0; j < 2; j++)
                    rateAdaptation[i, j] = 0.0;
        }

        public int CountSumForFunctionResults()
        {
            int sum = 0;
            for (int i = 0; i < functionResults.Length; i++)
            {
                sum += functionResults[i];
            }

            return sum;
        }


        public void CountRateAdaptation()
        {
            SetTheInitialCondition();
            double previously=0;
            int sum = CountSumForFunctionResults();
            
            for(int i=0; i<individuals.Length; i++)
            {
                rateAdaptation[i,0] = functionResults[i];
                rateAdaptation[i, 2] = individuals[i];
                rateAdaptation[i,0] /= sum;
                rateAdaptation[i,0] *= 100;

                previously += rateAdaptation[i, 0];
                if (i == 0)
                    rateAdaptation[i, 1] += rateAdaptation[i, 0];
                else
                    rateAdaptation[i, 1] += previously;
            }

            Console.WriteLine("\t\tRATE ADAPTATION");
            Console.WriteLine("\tUDZIAL(%)\t(DISTRIBUANTE)\tINDIVIDUAL(decimal value)");

            for (int i = 0; i < individuals.Length; i++)
            {
                for (int j = 0; j < 3; j++)
                    Console.Write(rateAdaptation[i, j] + "    ");
                Console.WriteLine();
            }
        }

        public void SpinTheRouletteWheel()
        {
            Random rand = new Random();
            double[] randomNumbers = new double[individuals.Length];

            Console.WriteLine("\t\tSPIN ROULETTE WHEEL");

            for (int i=0; i < individuals.Length;i++)
            {
                randomNumbers[i] = rand.NextDouble()*100;
                Console.WriteLine("Random: " + randomNumbers[i]);
            }


            Console.WriteLine("\t\tCHOOSEN INDIVIDUALS");

            for (int i = 0; i < randomNumbers.Length; i++)
                for (int j = 0; j < individuals.Length; j++)
                    if (randomNumbers[i] < rateAdaptation[j, 1])
                    {
                        RandomlySelectedIndividuals[i] = (int)rateAdaptation[j,2];
                        Console.WriteLine(randomNumbers[i] + " < " + rateAdaptation[j, 1]+" Wybrano osobnika : "+ RandomlySelectedIndividuals[i]);
                        break;
                    }
        }
    }
}
