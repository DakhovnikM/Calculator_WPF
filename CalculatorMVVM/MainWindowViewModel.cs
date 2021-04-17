using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
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
        private bool _mButtonUsed;
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

        #region Инициализация переменных
        public ICommand ControllerCommand { get; }
        private bool CanExecuteControllerCommand(object p) => true;
        private void OnExecutedControllerCommand(object p)
        {
            VariableInit((string)p);
        }
        #endregion

        #region Закрыть приложение
        public ICommand CloseApplicationCommand { get; }
        private bool CanExecuteCloseApplication(object p) => true;
        private void OnExecutedCloseApplication(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #region Сворачивание окна
        public ICommand MinimizeApplicationCommand { get; }
        private bool CanExecuteMinimizeApplication(object p) => true;
        private void OnExecutedMinimizeApplication(object p)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        #endregion

        #endregion

        #region Конструктор
        public MainWindowViewModel()
        {
            _calc = new Calc();
            ControllerCommand = new Command(OnExecutedControllerCommand, CanExecuteControllerCommand);
            CloseApplicationCommand = new Command(OnExecutedCloseApplication, CanExecuteCloseApplication);
            MinimizeApplicationCommand = new Command(OnExecutedMinimizeApplication, CanExecuteMinimizeApplication);
        }
        #endregion

        private void VariableInit(string btnContent)
        {
            if (int.TryParse(btnContent, out _))
            {
                if (EqualSign == "=")
                {
                    Clear();
                    _mButtonUsed = false;
                }

                if (_mButtonUsed == true)
                {
                    CalcContent = "";
                    _mButtonUsed = false;
                }

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
                if (btnContent == "+" || btnContent == "-" || btnContent == "*" || btnContent == "/")
                {
                    if (OperationSign == "" || SecondOperand != "")
                    {
                        OperationSign = btnContent;
                        FirstOperand = GetOperand;
                        _canSetSecondOperand = true;
                    }
                    else if (SecondOperand == "") OperationSign = btnContent;
                }

                if (btnContent == "=")
                {
                    if (OperationSign != "")
                    {
                        EqualSign = "=";

                        if (_result != "") FirstOperand = _result;
                        else SecondOperand = GetOperand;

                        _result = _calc.CalcResult(OperationSign, FirstOperand, SecondOperand).ToString(CultureInfo.CurrentCulture);
                        CalcContent = _result;
                    }
                }

                if (btnContent == "<<")
                {
                    CalcContent = CalcContent.Length >= 1 ? CalcContent.Remove(CalcContent.Length - 1) : "";
                }

                if (btnContent == ",")
                {
                    if (CalcContent == "0") CalcContent = "0,";
                    if (!CalcContent.Contains(",")) CalcContent += ",";
                }

                if (btnContent == "+/-")
                {
                    if (CalcContent != "")
                        CalcContent = CalcContent.StartsWith("-") ? CalcContent.Remove(0, 1) : CalcContent.Insert(0, "-");
                }

                if (btnContent == "Sqr")
                {
                    FirstOperand = GetOperand;
                    _result = _calc.CalcResult("Sqr", FirstOperand, "0").ToString(CultureInfo.CurrentCulture);
                    CalcContent = _result;
                }

                if (btnContent.StartsWith("M"))
                {
                    if (btnContent == "M+") _memory += Convert.ToDouble(CalcContent);

                    if (btnContent == "M-")
                        _memory -= Convert.ToDouble(CalcContent);

                    if (btnContent == "MR")
                        CalcContent = _memory.ToString(CultureInfo.CurrentCulture);

                    if (btnContent == "MC")
                        _memory = 0;

                    if (btnContent == "MS")
                        _memory = Convert.ToDouble(CalcContent);

                    Clear();
                    _mButtonUsed = true;
                }

                if (btnContent == "C")
                {
                    CalcContent = "0";
                    _result = "";
                    _mButtonUsed = false;
                    Clear();
                }
            }
        }

        private void Clear()
        {
            FirstOperand = "";
            SecondOperand = "";
            OperationSign = "";
            EqualSign = "";
        }
    }
}