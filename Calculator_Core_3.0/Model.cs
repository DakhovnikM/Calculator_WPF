using System;

namespace Calculator_Core_3._0
{
    class Model
    {
        double Number1 { get; set; } = 0;
        double Number2 { get; set; } = 0;
        char Sign { get; set; } = 'ё';
        double Result { get; set; } = 0;

        /// <summary>
        /// Выбор арифметической операции.
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        public char SetSignOperation(char ch) => Sign = ch;

        /// <summary>
        /// Инициализация 1-ой переменной.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public double SetNumber1(string str) => Number1 = Convert.ToDouble(str);

        /// <summary>
        /// Инициализация 2-ой переменной.
        /// </summary>
        /// <param name="str">Число отоброжаемое в </param>
        /// <returns></returns>
        public double SetNumber2(string str) => Number2 = Convert.ToDouble(str);

        /// <summary>
        /// Вычисление результата.
        /// </summary>
        /// <param name="str1">Первое число</param>
        /// <param name="str2">Второе число</param>
        /// <returns></returns>
        public double GetResult() =>
        Sign switch
        {
            '+' => Result = Number2 == 0 ? Number1 + Number1 : Number1 + Number2,
            '-' => Result = Number2 == 0 ? Number1 - Number1 : Number1 - Number2,
            '*' => Result = Number2 == 0 ? Number1 * Number1 : Number1 * Number2,
            '/' => Result = Number2 != 0 ? Number1 / Number2 : 0,
            _ => Result
        };
        /// <summary>
        /// Вывод арифметического знака на экран.
        /// </summary>
        /// <returns></returns>
        public string ArithmeticSignToLable() => Sign.ToString();

        /// <summary>
        /// Вывод результата на экран.
        /// </summary>
        /// <returns></returns>
        public string ResultToTextBox() => Result.ToString();

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
