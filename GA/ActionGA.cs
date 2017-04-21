using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    class ActionGA
    {
        public ActionGA()
        {
            cP = new CreatePopulation();
            roulette = new RouletteWheel(cP.Individuals, cP.AmountOfPhenotypes);

            cP.displayIndividualsInDecimals();
            cP.displayIndividualsInBinary();
        }

        CreatePopulation cP;
        RouletteWheel roulette;
        OperationsForNewPopulation op;
        int[] perfectIndividuals = { 15, 15, 15, 15 };

        public bool endingCondition()
        {
            bool ifEnd = false;

            if (cP.Individuals.SequenceEqual(perfectIndividuals))
                ifEnd = true;

            return ifEnd;
        }

        public void infoAboutGeneration(int generation)
        {
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("#####################\tGENERATION " + generation + "\t#####################\t");
        }

        public void Selection()
        {
            roulette.setIndividuals(cP.Individuals);
            roulette.CountFitnessFunctionForPopulation();
            roulette.CountRateAdaptation();
            roulette.SpinTheRouletteWheel();
        }

        public void Modyfication(Random rand)
        {
            op = new CrossingOver(roulette.RANDOMLYselectedINDIVIDUALS, cP.MAXnumber, cP.Individuals);

            if (rand.NextDouble() < 0.5)
                op = new Mutation(roulette.RANDOMLYselectedINDIVIDUALS, cP.MAXnumber, op.NEWPOPULATION, cP.Individuals);
        }

        public void runAlghoritm()
        {
            Random rand = new Random();
            int i = 0;
            do
            {                
                if (endingCondition())
                    break;

                infoAboutGeneration(i);
                Selection();
                Modyfication(rand);

                i++;
            } while (true);

            
            Console.WriteLine("koniec");

        }
    }
}
