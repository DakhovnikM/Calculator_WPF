using System;
using System.Collections.Generic;

namespace CalculatorMVVM
{
    class Calc
    {
        public delegate double MathOperation(string x, string y);

        private readonly Dictionary<string, MathOperation> _dict;

        public Calc()
        {
            _dict = new Dictionary<string, MathOperation>()
            {
                ["+"] = (x, y) => double.Parse(x) + double.Parse(y),
                ["-"] = (x, y) => double.Parse(x) - double.Parse(y),
                ["*"] = (x, y) => double.Parse(x) * double.Parse(y),
                ["/"] = (x, y) => double.Parse(x) / double.Parse(y),
                ["Sqr"] = (x, y) => Math.Sqrt(double.Parse(x) + double.Parse(y))
            };
        }

        public void DefineOperation(string str, MathOperation mathOperation)
        {
            _dict.Add(str, mathOperation);
        }

        public double CalcResult(string key, string x, string y)
        {
            var value = _dict[key];
            return value(x, y);
        }
    }
}