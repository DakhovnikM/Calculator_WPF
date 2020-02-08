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
        public char SetSignOperation(char ch) => sign = ch;

        /// <summary>
        /// Инициализация 1-ой переменной.
        /// </summary>
        /// <param name="str">Number1</param>
        /// <returns></returns>
        public double SetNumber1(string str) => number1 = Convert.ToDouble(str);

        /// <summary>
        /// Инициализация 2-ой переменной.
        /// </summary>
        /// <param name="str">Number2</param>
        /// <returns></returns>
        public double SetNumber2(string str) => number2 = Convert.ToDouble(str);

        /// <summary>
        /// Получение результата.
        /// </summary>
        /// <returns></returns>
        public double GetResult() => sign switch
        {
            '+' => result = number2 == 0 ? number1 + number1 : number1 + number2,
            '-' => result = number2 == 0 ? number1 - number1 : number1 - number2,
            '*' => result = number2 == 0 ? number1 * number1 : number1 * number2,
            '/' => result = number2 == 0 ? 0 : number1 / number2,
            _ => result
        };
        
        /// <summary>
        /// Вывод арифметического знака на экран.
        /// </summary>
        /// <returns></returns>
        public string ArithmeticSignToLabel() => sign.ToString();

        /// <summary>
        /// Вывод результата на экран.
        /// </summary>
        /// <returns></returns>
        public string ResultToTextBox() => result.ToString(CultureInfo.CurrentCulture);

        /// <summary>
        /// Проверяем, задан ли знак арифметической операции.
        /// </summary>
        /// <returns></returns>
        public bool SignSetOrNot() => sign != 'ё';

        /// <summary>
        /// Возврвщвет символ арифметической операции.
        /// </summary>
        /// <returns></returns>
        public string ReturnSign() => Convert.ToString(sign);

        /// <summary>
        /// Сброс значений всех переменных.
        /// </summary>
        public void Reset()
        {
            number1 = 0;
            number2 = 0;
            result = 0;
            sign = 'ё';
        }
    }
}