using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDD.Ferramentas
{
    public class Calculator
    {
        private double LastResult { get; set; }

        public double Sum(double number1, double number2)
        {
            LastResult = number1 + number2;
            return LastResult;
        }

        public double Sum(double number)
        {
            LastResult += number;
            return LastResult;
        }
    }
}
