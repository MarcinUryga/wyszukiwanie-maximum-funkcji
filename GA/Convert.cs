using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GA
{
    static class Convert
    {
        private static string ReverseTheTable(string stringOfNumbers)
        {
            string ReverseTheTab = new string(stringOfNumbers.Reverse().ToArray());

            return ReverseTheTab;
        }

        public static int ConvertToDecimals(string stringOfNumbers)
        {
            string individuals;
            individuals = ReverseTheTable(stringOfNumbers);
            int number = 0;

            for (int i = 0; i < individuals.Length; i++)
                if (individuals[i].ToString() == "1")
                    number += (int)Math.Pow(2, i);


            return number;
        }

        public static string ConvertToBinary(int number, int maxNumber)
        {
            string stringOfNumbers = null;

            for (int i = 0; i < Math.Log(maxNumber, 2); i++)
                stringOfNumbers += "0";

            char[] arrayOfNumbers = stringOfNumbers.ToCharArray();

            int k = 0;
            while (number > 0)
            {
                int checkRest = number;
                if ((checkRest %= 2) == 1)
                    arrayOfNumbers[k] = '1';
                else
                    arrayOfNumbers[k] = '0';
                number /= 2;
                k++;
            }

            stringOfNumbers = new string(arrayOfNumbers);
            stringOfNumbers = ReverseTheTable(stringOfNumbers.ToString());

            return stringOfNumbers.ToString();
        }
    }
}
