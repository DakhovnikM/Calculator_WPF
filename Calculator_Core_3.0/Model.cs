using System;
using System.Globalization;

namespace Calculator_Core_3._0
{
    internal class Model
    {
        private double Number1 { get; set; }
        private double Number2 { get; set; }
        private char Sign { get; set; }
        private double Result { get; set; }

        /// <summary>
        /// Arithmetic operation selection.
        /// </summary>
        /// <param name="ch">Sign</param>
        /// <returns></returns>
        public char SetSignOperation(char ch) => Sign = ch;

        /// <summary>
        /// Инициализация 1-ой переменной.
        /// </summary>
        /// <param name="str">Number1</param>
        /// <returns></returns>
        public double SetNumber1(string str) => Number1 = Convert.ToDouble(str);

        /// <summary>
        /// Инициализация 2-ой переменной.
        /// </summary>
        /// <param name="str">Number2</param>
        /// <returns></returns>
        public double SetNumber2(string str) => Number2 = Convert.ToDouble(str);

        /// <summary>
        /// Получение результата.
        /// </summary>
        /// <returns></returns>
        public double GetResult() => Sign switch
        {
            '+' => Result = Number2 == 0 ? Number1 + Number1 : Number1 + Number2,
            '-' => Result = Number2 == 0 ? Number1 - Number1 : Number1 - Number2,
            '*' => Result = Number2 == 0 ? Number1 * Number1 : Number1 * Number2,
            '/' => Result = Number2 == 0 ? 0 : Number1 / Number2,
            _ => Result
        };
        
        /// <summary>
        /// Вывод арифметического знака на экран.
        /// </summary>
        /// <returns></returns>
        public string ArithmeticSignToLabel() => Sign.ToString();

        /// <summary>
        /// Вывод результата на экран.
        /// </summary>
        /// <returns></returns>
        public string ResultToTextBox() => Result.ToString(CultureInfo.CurrentCulture);

        /// <summary>
        /// Проверяем, задан ли знак арифметической операции.
        /// </summary>
        /// <returns></returns>
        public bool SignSetOrNot() => Sign != 'ё';

        /// <summary>
        /// Возврвщвет символ арифметической операции.
        /// </summary>
        /// <returns></returns>
        public string ReturnSign() => Convert.ToString(Sign);

        /// <summary>
        /// Сброс значений всех переменных.
        /// </summary>
        public void Reset()
        {
            Number1 = 0;
            Number2 = 0;
            Result = 0;
            Sign = 'ё';
        }
    }
}