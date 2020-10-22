using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;
using System.Windows;

namespace Calculator_Core_3._0
{
    class Controller
    {
        #region Prop
        private readonly MainWindow mainWindow;
        private readonly Calc calc;
        private double memory;
        private bool equalButtonPressed;
        private double firstOperand;
        private double secondOperand;
        private string operationSign;
        private string TextBoxText
        {
            get { return mainWindow.TextBox.Text; }
            set { mainWindow.TextBox.Text = value; }
        }
        private double GetOperand { get => TextBoxText != "" ? Convert.ToDouble(TextBoxText) : 0; }
        #endregion

        #region Ctor
        public Controller(MainWindow window)
        {
            mainWindow = window;
            calc = new Calc();
            firstOperand = 0;
            secondOperand = 0;
            memory = 0;
            operationSign = "";
            equalButtonPressed = true;
            mainWindow.GetStr += MainWindow_GetStr;
        }
        #endregion

        private void MainWindow_GetStr(string content)
        {
            if (equalButtonPressed)
            {
                if ((content == "," && !TextBoxText.Contains(",")) || int.TryParse(content, out int res))
                {
                    TextBoxText += content;
                }

                if (content == "+" || content == "-" || content == "*" || content == "/")
                {
                    ToLabelText(TextBoxText);
                    operationSign = content; //TODO Повторное нажатие знака
                    firstOperand = GetOperand;
                    ToLabelText(content);
                    TextBoxText = "";
                }

                if (content == "<<")
                {
                    TextBoxText = TextBoxText.Length >= 1
                        ? TextBoxText.Remove(TextBoxText.Length - 1)
                        : "";
                }

                if (content == "=" && operationSign != "")
                {
                    secondOperand = GetOperand;
                    var result = calc.CalcResult(operationSign, firstOperand, secondOperand).ToString();
                    TextBoxText = result;
                    operationSign = "";
                    ToLabelText(secondOperand + "=");
                    equalButtonPressed = false;
                }
            }

            if (content == "+/-")
            {
                TextBoxText = TextBoxText.StartsWith("-")
                    ? TextBoxText.Remove(0, 1)
                    : "-" + TextBoxText;
            }

            if (content == "Sqr")
            {
                ToLabelText("");
                firstOperand = GetOperand;
                ToLabelText("√" + firstOperand);
                var result = calc.CalcResult("Sqr", firstOperand, 0).ToString();
                TextBoxText = result;
            }

            if (content == "M+")
            {
                memory += Convert.ToDouble(TextBoxText);
            }

            if (content == "M-")
            {
                memory -= Convert.ToDouble(TextBoxText);
            }

            if (content == "MR")
            {
                ToLabelText("");
                TextBoxText = memory.ToString();
            }

            if (content == "MC")
            {
                memory = 0;
            }

            if (content == "C")
            {
                Clear();
            };
        }

        private void Clear()
        {
            TextBoxText = "";
            firstOperand = 0;
            secondOperand = 0;
            ToLabelText("");
            operationSign = "";
            equalButtonPressed = true;
        }

        private void ToLabelText(string content)
        {
            if (content == "")
                mainWindow.Label.Content = "";
            else
                mainWindow.Label.Content += content;
        }

    }
}