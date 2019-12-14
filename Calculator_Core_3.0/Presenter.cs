using System;

namespace Calculator_Core_3._0
{
    internal class Presenter
    {
        private readonly Model _model;
        private readonly MainWindow _mainWindow;
        private int EqualCount { get; set; }

        public Presenter(MainWindow mainWindow)
        {
            _model = new Model();
            _mainWindow = mainWindow;
            _mainWindow.TextBox.Text = "";
            _mainWindow.Label.Content = "";

            #region Subscribe to events.

            _mainWindow.But_0_Click += MainWindow_But_0_Click;
            _mainWindow.But_1_Click += MainWindow_But_1_Click;
            _mainWindow.But_2_Click += MainWindow_But_2_Click;
            _mainWindow.But_3_Click += MainWindow_But_3_Click;
            _mainWindow.But_4_Click += MainWindow_But_4_Click;
            _mainWindow.But_5_Click += MainWindow_But_5_Click;
            _mainWindow.But_6_Click += MainWindow_But_6_Click;
            _mainWindow.But_7_Click += MainWindow_But_7_Click;
            _mainWindow.But_8_Click += MainWindow_But_8_Click;
            _mainWindow.But_9_Click += MainWindow_But_9_Click;
            _mainWindow.But_Add_Click += MainWindow_But_Add_Click;
            _mainWindow.But_ChangeSign_Click += MainWindow_But_ChangeSign_Click;
            _mainWindow.But_Dev_Click += MainWindow_But_Dev_Click;
            _mainWindow.But_Equals_Click += MainWindow_But_Equals_Click;
            _mainWindow.But_Mul_Click += MainWindow_But_Mul_Click;
            _mainWindow.But_Point_Click += MainWindow_But_Point_Click;
            _mainWindow.But_Res_Click += MainWindow_But_Res_Click;
            _mainWindow.But_Sub_Click += MainWindow_But_Sub_Click;
            _mainWindow.But_Correct_Click += MainWindow_But_Correct_Click;

            #endregion
        }

        /// <summary>
        /// Set first number and the sign of arithmetic operation.
        /// </summary>
        /// <param name="ch">Sign of arithmetic operation</param>
        private void SetNumbersAndSign(char ch)
        {
            if (_mainWindow.TextBox.Text.Length != 0)
            {
                _model.SetSignOperation(ch);
                _model.SetNumber1(_mainWindow.TextBox.Text);
                _model.SetNumber2(_mainWindow.TextBox.Text);
                _mainWindow.Label.Content = _mainWindow.TextBox.Text;
                _mainWindow.TextBox.Text = "";
                _mainWindow.Label.Content += _model.ArithmeticSignToLabel();
            }
            else _mainWindow.TextBox.Text = "";
        }

        /// <summary>
        /// Filing out the Text_box and the Label.
        /// </summary>
        /// <param name="num">Number</param>
        private void FilingOutTextBoxAndLabel(string num)
        {
            if (num == "," && _mainWindow.TextBox.Text.Length == 0)
            {
                _mainWindow.TextBox.Text += "0" + num;
                _mainWindow.Label.Content += "0" + num;
            }
            else
            {
                _mainWindow.TextBox.Text += num;
                if (!_mainWindow.Label.Content.ToString().Contains(_model.ReturnSign()))
                    _mainWindow.Label.Content += num;
            }
        }

        #region Auxiliary buttons.

        //
        //Button "C", all clear.
        private void MainWindow_But_Res_Click(object sender, EventArgs e)
        {
            _mainWindow.TextBox.Text = "";
            _mainWindow.Label.Content = "";
            EqualCount = 0;
            _model.Reset();
        }

        //
        //Button "."
        private void MainWindow_But_Point_Click(object sender, EventArgs e) => FilingOutTextBoxAndLabel(",");

        //
        //Button "="
        private void MainWindow_But_Equals_Click(object sender, EventArgs e)
        {
            if (!_model.SignSetOrNot()) return;
            if (_mainWindow.Label.Content.ToString().Length != 0)
                _model.SetNumber2(_mainWindow.Label.Content.ToString()
                    .Remove(_mainWindow.Label.Content.ToString().Length - 1, 1));
            if (_mainWindow.TextBox.Text.Length != 0 && EqualCount == 0)
                _model.SetNumber2(_mainWindow.TextBox.Text);
            _model.GetResult();
            _mainWindow.TextBox.Text = _model.ResultToTextBox();
            _model.SetNumber1(_mainWindow.TextBox.Text);
            _mainWindow.Label.Content = "";
            EqualCount = 1;
        }

        //
        //Button "+/-", change the sign of a number.
        private void MainWindow_But_ChangeSign_Click(object sender, EventArgs e)
        {
            _mainWindow.TextBox.Text = _mainWindow.TextBox.Text.StartsWith("-")
                ? _mainWindow.TextBox.Text.Remove(0, 1)
                : _mainWindow.TextBox.Text.Insert(0, "-");
        }

        //
        //Button "<<", line adjustment.
        private void MainWindow_But_Correct_Click(object sender, EventArgs e)
        {
            if (_mainWindow.TextBox.Text.Length == 0) return;
            _mainWindow.TextBox.Text = _mainWindow.TextBox.Text.Remove(_mainWindow.TextBox.Text.Length - 1, 1);
            if (_mainWindow.Label.Content.ToString().Length != 0 &&
                !_mainWindow.Label.Content.ToString().Contains(_model.ReturnSign()))
                _mainWindow.Label.Content = _mainWindow.Label.Content.ToString()
                    .Remove(_mainWindow.Label.Content.ToString().Length - 1, 1);
        }

        #endregion

        #region Arithmetic operations buttons.

        //
        //Button "/"
        private void MainWindow_But_Dev_Click(object sender, EventArgs e) => SetNumbersAndSign('/');

        //
        //Button "-"
        private void MainWindow_But_Sub_Click(object sender, EventArgs e) => SetNumbersAndSign('-');

        //
        //Button "*"
        private void MainWindow_But_Mul_Click(object sender, EventArgs e) => SetNumbersAndSign('*');

        //
        //Button "+"
        private void MainWindow_But_Add_Click(object sender, EventArgs e) => SetNumbersAndSign('+');

        #endregion

        #region Number buttons.

        private void MainWindow_But_9_Click(object sender, EventArgs e) => FilingOutTextBoxAndLabel("9");
        private void MainWindow_But_8_Click(object sender, EventArgs e) => FilingOutTextBoxAndLabel("8");
        private void MainWindow_But_7_Click(object sender, EventArgs e) => FilingOutTextBoxAndLabel("7");
        private void MainWindow_But_6_Click(object sender, EventArgs e) => FilingOutTextBoxAndLabel("6");
        private void MainWindow_But_5_Click(object sender, EventArgs e) => FilingOutTextBoxAndLabel("5");
        private void MainWindow_But_4_Click(object sender, EventArgs e) => FilingOutTextBoxAndLabel("4");
        private void MainWindow_But_3_Click(object sender, EventArgs e) => FilingOutTextBoxAndLabel("3");
        private void MainWindow_But_2_Click(object sender, EventArgs e) => FilingOutTextBoxAndLabel("2");
        private void MainWindow_But_1_Click(object sender, EventArgs e) => FilingOutTextBoxAndLabel("1");
        private void MainWindow_But_0_Click(object sender, EventArgs e) => FilingOutTextBoxAndLabel("0");

        #endregion
    }
}