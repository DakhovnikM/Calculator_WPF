using System;
using System.Globalization;

namespace Calculator_Core_3._0
{
    internal class Model
    {
        private double number1;
        private double number2;
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
        public double SetNumber1(string str) =>
            number1 = Convert.ToDouble(str);

        public double GetNumber1() =>
            number1;

        /// <summary>
        /// Инициализация 2-ой переменной.
        /// </summary>
        /// <param name="str">Number2</param>
        /// <returns></returns>
        public double SetNumber2(string str) =>
            number2 = Convert.ToDouble(str);

        public double GetNumber2() =>
            number2;

        /// <summary>
        /// Получение результата.
        /// </summary>
        /// <returns></returns>
        public double GetResult() =>
            sign switch
            {
                '+' => result = number2 == 0 ? number1 + number1
                                             : number1 + number2,

                '-' => result = number2 == 0 ? number1 - number1
                                             : number1 - number2,

                '*' => result = number2 == 0 ? number1 * number1
                                             : number1 * number2,

                '/' => result = number2 == 0 ? 0
                                             : number1 / number2,
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
            number1 = 0;
            number2 = 0;
            result = 0;
            sign = '\0';
        }
    }
}