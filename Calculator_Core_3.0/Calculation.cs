using System;

namespace Calculator_Core_3._0
{
    internal class Calculation
    {
        public double FirstArgument { get; set; }
        public double SecondArgument { get; set; }
        public char ArithmeticSign { get; set; }
        public double Result { get; private set; }

        public double SqrCalculation() => Result = Math.Sqrt(FirstArgument);

        public double ArithmeticOpCalculation() =>
            ArithmeticSign switch
            {
                '+' => Result = SecondArgument == 0
                                ? FirstArgument + FirstArgument
                                : FirstArgument + SecondArgument,

                '-' => Result = SecondArgument == 0
                                ? FirstArgument - FirstArgument
                                : FirstArgument - SecondArgument,

                '*' => Result = SecondArgument == 0
                                ? FirstArgument * FirstArgument
                                : FirstArgument * SecondArgument,

                '/' => Result = SecondArgument == 0
                                ? 0
                                : FirstArgument / SecondArgument,
                _ => Result
            };

        public bool SignInitCheck() => ArithmeticSign != '\0';

        public void Reset()
        {
            FirstArgument = 0;
            SecondArgument = 0;
            Result = 0;
            ArithmeticSign = '\0';
        }
    }
}