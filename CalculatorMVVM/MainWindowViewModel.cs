using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CalculatorMVVM
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Поля
        private readonly Calc _calc;
        private double _memory;
        private bool _canSetSecondOperand;
        private string _result = "";
        #endregion

        #region Свойства
        private string GetOperand => CalcContent == "" ? "0" : CalcContent;

        private string _firstOperand = "";
        public string FirstOperand
        {
            get => _firstOperand;
            set
            {
                _firstOperand = value;
                OnPropertyChanged();
            }
        }

        private string _secondOperand = "";
        public string SecondOperand
        {
            get => _secondOperand;
            set
            {
                _secondOperand = value;
                OnPropertyChanged();
            }
        }

        private string _equalSign = "";
        public string EqualSign
        {
            get => _equalSign;
            set
            {
                _equalSign = value;
                OnPropertyChanged();
            }
        }

        private string _operationSign = "";
        public string OperationSign
        {
            get => _operationSign;
            set
            {
                _operationSign = value;
                OnPropertyChanged();
            }
        }

        private string _calcString = "0";
        public string CalcContent
        {
            get => _calcString;
            set
            {
                _calcString = value;
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
            VariableInit((string)p);
        }
        #endregion

        #region Конструктор
        public MainWindowViewModel()
        {
            _calc = new Calc();
            ControllerCommand = new Command(OnExecutedControllerCommand, CanExecuteControllerCommand);
        }
        #endregion

        //private void ButtonContentProcessing(string btnContent)
        //{
        //    if (CalcContent == "0" && btnContent == ",") CalcContent = "0,";

        //    if (CalcContent == "0") CalcContent = "";

        //    if (_canPressEqualButton)
        //    {
        //        if (_canSetSecondOperand)
        //        {
        //            CalcContent = "";
        //            _canSetSecondOperand = false;
        //        }

        //        if (int.TryParse(btnContent, out _) && btnContent != "0")
        //            CalcContent += btnContent;

        //        if (btnContent == "0" && CalcContent != "0")
        //            CalcContent += btnContent;

        //        if (btnContent == "," && !CalcContent.Contains(","))
        //            CalcContent += btnContent;

        //        if (btnContent == "+" || btnContent == "-" || btnContent == "*" || btnContent == "/") //TODO реализовать повторное нажатие знака операции
        //        {
        //            OperationSign = btnContent;
        //            FirstOperand = GetOperand;
        //            _canSetSecondOperand = true;
        //        }

        //        if (btnContent == "=" && OperationSign != "")
        //        {
        //            EqualSign = "=";

        //            if (_result != "") FirstOperand = _result;
        //            else SecondOperand = GetOperand;

        //            _result = _calc.CalcResult(OperationSign, FirstOperand, SecondOperand).ToString();
        //            CalcContent = _result;
        //        }

        //        if (btnContent == "<<")
        //            CalcContent = CalcContent.Length >= 1
        //                ? CalcContent.Remove(CalcContent.Length - 1)
        //                : "";
        //    }

        //    if (btnContent == "+/-" && CalcContent != "")
        //    {
        //        CalcContent = CalcContent.StartsWith("-")
        //            ? CalcContent.Remove(0, 1)
        //            : CalcContent.Insert(0, "-");
        //    }

        //    if (btnContent == "Sqr")
        //    {
        //        FirstOperand = GetOperand;
        //        _result = _calc.CalcResult("Sqr", FirstOperand, "0").ToString();
        //        CalcContent = _result;
        //    }

        //    if (btnContent == "M+")
        //        _memory += Convert.ToDouble(CalcContent);

        //    if (btnContent == "M-")
        //        _memory -= Convert.ToDouble(CalcContent);

        //    if (btnContent == "MR")
        //        CalcContent = _memory.ToString();

        //    if (btnContent == "MC")
        //        _memory = 0;

        //    if (btnContent == "C")
        //        Clear();
        //}

        private void VariableInit(string btnContent)
        {
            if (int.TryParse(btnContent, out _))
            {
                if (_canSetSecondOperand)
                {
                    CalcContent = "";
                    _canSetSecondOperand = false;
                }

                if (CalcContent == "0") CalcContent = "";

                if (btnContent != "0" || btnContent == "0" && CalcContent != "0")
                    CalcContent += btnContent;
            }
            else
            {
                if (btnContent == "+" || btnContent == "-" || btnContent == "*" || btnContent == "/") //TODO реализовать повторное нажатие знака операции
                {
                    if (OperationSign == "")
                    {
                        OperationSign = btnContent;
                        FirstOperand = GetOperand;
                        _canSetSecondOperand = true;
                    }
                }

                if (btnContent == "=")
                {
                    if (OperationSign != "")
                    {
                        EqualSign = "=";

                        if (_result != "") FirstOperand = _result;
                        else SecondOperand = GetOperand;

                        _result = _calc.CalcResult(OperationSign, FirstOperand, SecondOperand).ToString();
                        CalcContent = _result;
                    }
                }

                if (btnContent == "<<")
                {
                    CalcContent = CalcContent.Length >= 1
                        ? CalcContent.Remove(CalcContent.Length - 1)
                        : "";
                }

                if (btnContent == ",")
                {
                    if (CalcContent == "0") CalcContent = "0,";
                    if (!CalcContent.Contains(",")) CalcContent += ",";
                }

                if (btnContent == "+/-")
                {
                    if (CalcContent != "")
                        CalcContent = CalcContent.StartsWith("-")
                            ? CalcContent.Remove(0, 1)
                            : CalcContent.Insert(0, "-");
                }

                if (btnContent == "Sqr")
                {
                    FirstOperand = GetOperand;
                    _result = _calc.CalcResult("Sqr", FirstOperand, "0").ToString();
                    CalcContent = _result;
                }

                if (btnContent == "M+")
                    _memory += Convert.ToDouble(CalcContent);

                if (btnContent == "M-")
                    _memory -= Convert.ToDouble(CalcContent);

                if (btnContent == "MR")
                    CalcContent = _memory.ToString();

                if (btnContent == "MC")
                    _memory = 0;

                if (btnContent == "C")
                    Clear();
            }
        }

        private void Clear()
        {
            CalcContent = "0";
            FirstOperand = "";
            SecondOperand = "";
            OperationSign = "";
            EqualSign = "";
            _result = "";
        }
    }
}