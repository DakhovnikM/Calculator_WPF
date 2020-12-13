using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Calculator_Core_3._0
{
    class Controller : INotifyPropertyChanged
    {
        #region Prop
        private readonly MainWindow mainWindow;
        private readonly Calc calc;
        private double memory;
        private bool CanPressEqualButton;

        private string GetOperand
        {
            get => tbString ?? "0";
        }

        private string firstOperand = "";
        public string FirstOperand
        {
            get => firstOperand;
            set
            {
                firstOperand = value;
                OnPropertyChanged();
            }
        }

        private string secondOperand = "";
        public string SecondOperand
        {
            get => secondOperand;
            set
            {
                secondOperand = value;
                OnPropertyChanged();
            }
        }

        private string equalSign = "";
        public string EqualSign
        {
            get => equalSign;
            set
            {
                equalSign = value;
                OnPropertyChanged();
            }
        }

        private string operationSign = "";
        public string OperationSign
        {
            get => operationSign;
            set
            {
                operationSign = value;
                OnPropertyChanged();
            }
        }

        private string result;
        public string Result
        {
            get => result;
            set
            {
                result = value;
            }
        }

        private string tbString = "";
        public string TBString
        {
            get => tbString;
            set
            {
                tbString = value;
                OnPropertyChanged();
            }
        }

        private string lbString = "";
        public string LBString
        {
            get => lbString;
            set
            {
                lbString = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string param = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(param));
        }
        #endregion

        #region Ctor
        public Controller()
        {

        }
        public Controller(MainWindow window) : this()
        {
            mainWindow = window;
            calc = new Calc();
            CanPressEqualButton = true;
            mainWindow.GetButtonContent += MainWindow_GetButtonContent;
        }
        #endregion

        private void MainWindow_GetButtonContent(string buttonContent)
        {
            if (CanPressEqualButton)
            {
                if (int.TryParse(buttonContent, out _) && buttonContent != "0")
                    TBString += buttonContent;

                if (buttonContent == "0" && !TBString.StartsWith("0") || TBString == "")
                    TBString += buttonContent;

                if (buttonContent == "," && !TBString.Contains(","))
                    TBString += buttonContent;

                if (buttonContent == "+" || buttonContent == "-" || buttonContent == "*" || buttonContent == "/")
                {
                    OperationSign = buttonContent; //TODO Повторное нажатие знака
                    FirstOperand = GetOperand;
                    TBString = "";
                }

                if (buttonContent == "<<")
                {
                    TBString = TBString.Length >= 1
                        ? TBString.Remove(TBString.Length - 1)
                        : "";
                }

                if (buttonContent == "=" && OperationSign != "")
                {
                    EqualSign = buttonContent == "=" ? buttonContent : "";
                    SecondOperand = GetOperand;
                    Result = calc.CalcResult(OperationSign, FirstOperand, SecondOperand).ToString();
                    TBString = Result;
                    CanPressEqualButton = false;
                }
            }

            if (buttonContent == "+/-" && TBString != "")
            {
                TBString = TBString.StartsWith("-")
                    ? TBString.Remove(0, 1)
                    : "-" + TBString;
            }

            if (buttonContent == "Sqr")
            {
                FirstOperand = GetOperand;
                Result = calc.CalcResult("Sqr", FirstOperand, "0").ToString();
                TBString = Result;
            }

            if (buttonContent == "M+")
                memory += Convert.ToDouble(TBString);

            if (buttonContent == "M-")
                memory -= Convert.ToDouble(TBString);

            if (buttonContent == "MR")
                TBString = memory.ToString();

            if (buttonContent == "MC")
                memory = 0;

            if (buttonContent == "C")
                Clear();
        }

        private void Clear()
        {
            TBString = "";
            FirstOperand = "";
            SecondOperand = "";
            OperationSign = "";
            EqualSign = "";
            CanPressEqualButton = true;
        }
    }
}