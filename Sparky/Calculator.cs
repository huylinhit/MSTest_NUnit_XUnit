using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class Calculator
    {
        public int Discount = 15;
        public int AddNumbers(int a, int b)
        { 
            return a + b; 
        }

        public double AddDoubleNumbers(double a, double b)
        {
            return a + b; 
        }

        public bool isOddNumber(int a)
        {
            if (a % 2 == 0)
                return false;
            return true;
        }

        public List<int> GetRanngeOfOddNumber(int min, int max)
        {
            Discount = 25;

            List<int> result = new List<int>();
            for (int i = min; i <= max; i++)
            {
                if(i % 2 != 0)
                {
                    result.Add(i);  
                }
            }
            return result;
        }

    }
}
