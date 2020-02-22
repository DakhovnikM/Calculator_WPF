using System;

namespace Calculator_Core_3._0
{
    internal class Model
    {
        private double argument_1;
        private double argument_2;
        private char sign;
        private double result;


        /// <summary>
        /// Arithmetic operation selection.
        /// </summary>
        /// <param name="ch">Sign</param>
        /// <returns></returns>
        public char SetArithmeticSign(char ch) =>
            sign = ch;

        public char GetArithmeticSign() =>
            sign;

        /// <summary>
        /// Инициализация 1-ой переменной.
        /// </summary>
        /// <param name="str">Number1</param>
        /// <returns></returns>
        public double SetArgument_1(string str) =>
            argument_1 = Convert.ToDouble(str);

        public double GetArgument_1() =>
            argument_1;

        /// <summary>
        /// Инициализация 2-ой переменной.
        /// </summary>
        /// <param name="str">Number2</param>
        /// <returns></returns>
        public double SetArgument_2(string str) =>
            argument_2 = Convert.ToDouble(str);

        public double GetArgument_2() =>
            argument_2;

        /// <summary>
        /// Получение результата извлечения корня.
        /// </summary>
        /// <returns></returns>
        public double GetSqr() =>
            result = Math.Sqrt(argument_1);

        /// <summary>
        /// Получение результата арифметической операции.
        /// </summary>
        /// <returns></returns>
        public double GetResult() =>
            sign switch
            {
                '+' => result = argument_2 == 0
                                ? argument_1 + argument_1
                                : argument_1 + argument_2,

                '-' => result = argument_2 == 0
                                ? argument_1 - argument_1
                                : argument_1 - argument_2,

                '*' => result = argument_2 == 0
                                ? argument_1 * argument_1
                                : argument_1 * argument_2,

                '/' => result = argument_2 == 0
                                ? 0
                                : argument_1 / argument_2,
                _ => result
            };

        /// <summary>
        /// Вывод результата на экран.
        /// </summary>
        /// <returns></returns>
        public string ResultToString() =>
            Convert.ToString(result);

        /// <summary>
        /// Проверяем, задан ли знак арифметической операции.
        /// </summary>
        /// <returns></returns>
        public bool SignInitCheck() =>
            sign != '\0';

        /// <summary>
        /// Возврвщвет символ арифметической операции.
        /// </summary>
        /// <returns></returns>
        public string SignToString() =>
            Convert.ToString(sign);

        /// <summary>
        /// Сброс значений всех переменных.
        /// </summary>
        public void Reset()
        {
            argument_1 = 0;
            argument_2 = 0;
            result = 0;
            sign = '\0';
        }
    }
}