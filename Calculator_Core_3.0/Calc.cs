using System;
using System.Collections.Generic;

namespace Calculator_Core_3._0
{
    internal class Calc
    {
        public double FirstOperand { get; set; }
        public double SecondOperand { get; set; }
        public string OperationSign { get; set; }
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

        public double SqrCalculation(double x) => Math.Sqrt(x);

        public bool SignInitCheck() => OperationSign != "\0";

        public void Reset()
        {
            FirstOperand = 0;
            SecondOperand = 0;
            Result = 0;
            OperationSign = "\0";
        }


        //public double Addition(double x, double y) => x + y;
        //public double Subtraction(double x, double y) => x - y;
        //public double Multiplication(double x, double y) => x * y;
        //public double Division(double x, double y) => x / y;
        //public double ArithmeticOpCalculation() =>
        //    ArithmeticSign switch
        //    {
        //        "+" => Result = SecondOperand == 0
        //                        ? FirstOperand + FirstOperand
        //                        : FirstOperand + SecondOperand,

        //        "-" => Result = SecondOperand == 0
        //                        ? FirstOperand - FirstOperand
        //                        : FirstOperand - SecondOperand,

        //        "*" => Result = SecondOperand == 0
        //                        ? FirstOperand * FirstOperand
        //                        : FirstOperand * SecondOperand,

        //        "/" => Result = SecondOperand == 0
        //                        ? 0
        //                        : FirstOperand / SecondOperand,
        //        _ => Result
        //    };
    }
}