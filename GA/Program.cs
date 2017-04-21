using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    class Program
    {
        static void Main(string[] args)
        {
              ActionGA geneticAlgorithm = new ActionGA();

              geneticAlgorithm.runAlghoritm();         

            Console.ReadKey();

        }

    }
}
