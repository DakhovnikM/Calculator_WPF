using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Calculator_Core_3._0
{
    class Controller : INotifyPropertyChanged
    {
        private readonly Calc calc;
        private double memory;
        private bool CanPressEqualButton;
        private bool CanSetSecondOperand;

        #region Свойства
        private string GetOperand
        {
            get => CalcString == "" ? "0" : CalcString;
        }

        private string result = "";

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

        private string tbString = "0";
        public string CalcString
        {
            get => tbString;
            set
            {
                tbString = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string param = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(param));
        }

        #region Команды
        public ICommand ControllerCommand { get; }
        private bool CanExecuteControllerCommand(object p) => true;
        private void OnExecutedControllerCommand(object p)
        {
            MainWindow_GetButtonContent((string)p);
        }

        #endregion

        #region Ctor
        public Controller()
        {
            calc = new Calc();
            CanPressEqualButton = true;
            ControllerCommand = new Command(OnExecutedControllerCommand, CanExecuteControllerCommand);
        }
        #endregion

        private void MainWindow_GetButtonContent(string btnContent)
        {
            if (CalcString == "0" && btnContent == ",") CalcString = "0,";

            if (CalcString == "0") CalcString = "";

            if (CanPressEqualButton)
            {
                if (CanSetSecondOperand)
                {
                    CalcString = "";
                    CanSetSecondOperand = false;
                }

                if (int.TryParse(btnContent, out _) && btnContent != "0")
                    CalcString += btnContent;

                if (btnContent == "0" && CalcString != "0")
                    CalcString += btnContent;

                if (btnContent == "," && !CalcString.Contains(","))
                    CalcString += btnContent;

                if (btnContent == "+" || btnContent == "-" || btnContent == "*" || btnContent == "/") //TODO реализовать повторное нажатие знака операции
                {
                    OperationSign = btnContent;
                    FirstOperand = GetOperand;
                    CanSetSecondOperand = true;
                }

                if (btnContent == "<<")
                    CalcString = CalcString.Length >= 1
                        ? CalcString.Remove(CalcString.Length - 1)
                        : "";

                if (btnContent == "=" && OperationSign != "")
                {
                    EqualSign = "=";

                    if (result != "") FirstOperand = result;
                    else SecondOperand = GetOperand;

                    result = calc.CalcResult(OperationSign, FirstOperand, SecondOperand).ToString();
                    CalcString = result;
                }
            }

            if (btnContent == "+/-" && CalcString != "")
            {
                CalcString = CalcString.StartsWith("-")
                    ? CalcString.Remove(0, 1)
                    : CalcString.Insert(0, "-");
            }

            if (btnContent == "Sqr")
            {
                FirstOperand = GetOperand;
                result = calc.CalcResult("Sqr", FirstOperand, "0").ToString();
                CalcString = result;
            }

            if (btnContent == "M+")
                memory += Convert.ToDouble(CalcString);

            if (btnContent == "M-")
                memory -= Convert.ToDouble(CalcString);

            if (btnContent == "MR")
                CalcString = memory.ToString();

            if (btnContent == "MC")
                memory = 0;

            if (btnContent == "C")
                Clear();
        }

        private void Clear()
        {
            CalcString = "0";
            FirstOperand = "";
            SecondOperand = "";
            OperationSign = "";
            EqualSign = "";
            CanPressEqualButton = true;
        }
    }
}