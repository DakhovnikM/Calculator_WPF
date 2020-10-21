using System;
using System.Collections.Generic;

namespace Calculator_Core_3._0
{
    internal class Calc
    {
        public double Result { get; private set; }

        public delegate double MathOperation(double x, double y);
        private readonly Dictionary<string, MathOperation> dict;

        public Calc()
        {
            dict = new Dictionary<string, MathOperation>()
            {
                ["+"] = (x, y) => (x + y),
                ["-"] = (x, y) => (x - y),
                ["*"] = (x, y) => (x * y),
                ["/"] = (x, y) => (x / y),
                ["sqr"] = (x, y) => Math.Sqrt(x)
            };
        }

        public void DefineOperation(string str, MathOperation mathOperation)
        {
            dict.Add(str, mathOperation);
        }

        public double CalcResult(string key, double x, double y)
        {
            var value = dict[key];
            Result = value(x, y);
            return Result;
        }
    }
}