using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CalculatorMVVM
{
    class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private Action<object> _execute;

        private Func<object, bool> _canExecute;

        public Command(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _canExecute = canExecute;
            _execute = execute;
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
