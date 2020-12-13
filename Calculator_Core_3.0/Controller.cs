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
        private bool CanSetSecondOperand;

        private string GetOperand
        {
            get => TBString == "" ? "0" : TBString;
        }

        private string result="";

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
                if (CanSetSecondOperand)
                {
                    TBString = "";
                    CanSetSecondOperand = false;
                }

                if (int.TryParse(buttonContent, out _) && buttonContent != "0")
                    TBString += buttonContent;

                if (buttonContent == "0" && TBString!="0")
                    TBString += buttonContent;

                if (buttonContent == "," && !TBString.Contains(","))
                    TBString += buttonContent;

                if (buttonContent == "+" || buttonContent == "-" || buttonContent == "*" || buttonContent == "/")
                {
                    OperationSign = buttonContent;
                    FirstOperand = GetOperand;
                    CanSetSecondOperand = true;
                }

                if (buttonContent == "<<")
                    TBString = TBString.Length >= 1
                        ? TBString.Remove(TBString.Length - 1)
                        : "";

                if (buttonContent == "=" && OperationSign != "")
                {
                    EqualSign = "=";

                    if (result != "") FirstOperand = result;
                    else SecondOperand = GetOperand;

                    result = calc.CalcResult(OperationSign, FirstOperand, SecondOperand).ToString();
                    TBString = result;
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
                result = calc.CalcResult("Sqr", FirstOperand, "0").ToString();
                TBString = result;
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