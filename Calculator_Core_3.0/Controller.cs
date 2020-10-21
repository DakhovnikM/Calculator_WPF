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
        private bool flag;

        private string TextBoxText
        {
            get { return mainWindow.TextBox.Text; }
            set { mainWindow.TextBox.Text = value; }
        }

        public double FirstOperand { get; set; }
        public double SecondOperand { get; set; }
        private double Memory { get; set; }
        public string OperationSign { get; set; }
        #endregion

        #region Ctor
        public Controller(MainWindow window)
        {
            mainWindow = window;
            calc = new Calc();

            FirstOperand = 0;
            SecondOperand = 0;
            Memory = 0;
            OperationSign = "";
            flag = true;

            mainWindow.GetStr += MainWindow_GetStr;
        }
        #endregion

        private void MainWindow_GetStr(string content)
        {
            if (flag)
            {
                if ((content == "," && !TextBoxText.Contains(",")) || int.TryParse(content, out int res))
                {
                    TextBoxText += content;
                    GetLabelText(content);
                }

                if (content == "+" || content == "-" || content == "*" || content == "/")
                {
                    OperationSign = content; //TODO Повторное нажатие знака
                    FirstOperand = GetOperand();
                    TextBoxText = "";
                    GetLabelText(content);
                }

                if (content == "<<")
                {
                    TextBoxText = TextBoxText.Length >= 1
                        ? TextBoxText.Remove(TextBoxText.Length - 1)
                        : "";
                }

                if (content == "=" && OperationSign != "")
                {
                    SecondOperand = GetOperand();
                    TextBoxText = calc.CalcResult(OperationSign, FirstOperand, SecondOperand).ToString();
                    OperationSign = "";
                    GetLabelText("=");
                    flag = false;
                }
            }

            if (content == "M+")
            {
                Memory += Convert.ToDouble(TextBoxText);
            }
            if (content == "M-")
            {
                Memory -= Convert.ToDouble(TextBoxText);

            }
            if (content == "MR")
            {
                GetLabelText("");
                TextBoxText = Memory.ToString();
            }
            if (content == "MC")
            {
                Memory = 0;
            }

            if (content == "C")
            {
                Clear();
                flag = true;
            };
        }

        private void Clear()
        {
            TextBoxText = "";
            FirstOperand = 0;
            SecondOperand = 0;
            GetLabelText("");
            OperationSign = "";
        }
        private double GetOperand()
        {
            return TextBoxText != "" ? Convert.ToDouble(TextBoxText) : 0;
        }

        private void GetLabelText(string content)
        {
            if (content == "")
                mainWindow.Label.Content = "";
            else
                mainWindow.Label.Content += content;
        }

        private void MemoryInit()
        {

        }

    }
}
