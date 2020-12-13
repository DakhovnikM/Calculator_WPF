﻿using System;
using System.Collections.Generic;

namespace Calculator_Core_3._0
{
    class Calc
    {
        private double result;

        public delegate double MathOperation(string x, string y);

        private readonly Dictionary<string, MathOperation> dict;

        public Calc()
        {
            dict = new Dictionary<string, MathOperation>()
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
            dict.Add(str, mathOperation);
        }

        public double CalcResult(string key, string x, string y)
        {
            var value = dict[key];
            result = value(x, y);
            return result;
        }
    }
}