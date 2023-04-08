using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    internal class Calculation
    {
        public string? NumButton1 { get; set; }
        public string? NumButton2 { get; set; }
        public double Result { get; set; }
        public string? Operator { get; set; }

        public static double PerformCalculation(Calculation calc)
        {
            if (calc.Operator == "+")
            {
                return calc.Result = Convert.ToDouble(calc.NumButton1) + Convert.ToDouble(calc.NumButton2);
            }
            else if (calc.Operator == "-")
            {
                return calc.Result = Convert.ToDouble(calc.NumButton1) - Convert.ToDouble(calc.NumButton2);
            }
            else if (calc.Operator == "x")
            {
                return calc.Result = Convert.ToDouble(calc.NumButton1) * Convert.ToDouble(calc.NumButton2);
            }
            else if (calc.Operator == "÷")
            {
                return calc.Result = Convert.ToDouble(calc.NumButton1) / Convert.ToDouble(calc.NumButton2);
            }
            else
            {
                throw new ArgumentException("Unexpected operator");
            }
        }
    }
}
