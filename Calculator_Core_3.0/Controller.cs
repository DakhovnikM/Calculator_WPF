using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Calculator_Core_3._0
{
    class Controller
    {
        private readonly MainWindow mainWindow;
        private readonly Calc calc;
        private string BtnName => mainWindow.BtnName;
        private string firstOperand;
        private string secondOperand;
        private string result;


        public Controller(MainWindow window)
        {
            mainWindow = window;
            mainWindow.GetStr += MainWindow_GetStr;
        }

        private void MainWindow_GetStr(object sender, RoutedEventArgs e)
        {
            mainWindow.TextBox.Text = BtnName;
        }

        private void MainLoggic()
        {
            if (int.TryParse(BtnName, out int result))
            {
                firstOperand += BtnName;
            }
            else
            if (BtnName == "=")
            {
                mainWindow.ShowResult(firstOperand.ToString());
            }

        }


        //private bool DigitBtnIsPressed()
        //{
        //    firstOperand += BtnName;
        //    return true;
        //}
        //private bool OperationBtnIsPressed()
        //{
        //    return true;
        //}
        //private bool EqlBtnIsPressed()
        //{
        //    return true;
        //}

        //private bool SignBtnIsPressed()
        //{
        //    return true;
        //}
        //private bool SqrBtnIsPressed()
        //{
        //    return true;
        //}

    }
}
