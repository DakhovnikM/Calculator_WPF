using System;

namespace Calculator
{
    class Presenter
    {
        readonly Model model;
        readonly MainWindow mainWindow;
        string TextBoxText { get; set; }
        object LableContent { get; set; }

        public Presenter(MainWindow mainWindow)
        {
            model = new Model();
            this.mainWindow = mainWindow;
            TextBoxText = this.mainWindow.textBox.Text = "";
            LableContent = this.mainWindow.lable.Content = "";

            #region Subscribe to events.

            this.mainWindow.But_0_Click += MainWindow_But_0_Click;
            this.mainWindow.But_1_Click += MainWindow_But_1_Click;
            this.mainWindow.But_2_Click += MainWindow_But_2_Click;
            this.mainWindow.But_3_Click += MainWindow_But_3_Click;
            this.mainWindow.But_4_Click += MainWindow_But_4_Click;
            this.mainWindow.But_5_Click += MainWindow_But_5_Click;
            this.mainWindow.But_6_Click += MainWindow_But_6_Click;
            this.mainWindow.But_7_Click += MainWindow_But_7_Click;
            this.mainWindow.But_8_Click += MainWindow_But_8_Click;
            this.mainWindow.But_9_Click += MainWindow_But_9_Click;
            this.mainWindow.But_Add_Click += MainWindow_But_Add_Click;
            this.mainWindow.But_ChangeSign_Click += MainWindow_But_ChangeSign_Click;
            this.mainWindow.But_Dev_Click += MainWindow_But_Dev_Click;
            this.mainWindow.But_Equals_Click += MainWindow_But_Equals_Click;
            this.mainWindow.But_Mul_Click += MainWindow_But_Mul_Click;
            this.mainWindow.But_Point_Click += MainWindow_But_Point_Click;
            this.mainWindow.But_Res_Click += MainWindow_But_Res_Click;
            this.mainWindow.But_Sub_Click += MainWindow_But_Sub_Click;
            this.mainWindow.But_Corect_Click += MainWindow_But_Corect_Click;
            #endregion
        }

        /// <summary>
        /// Set first number and sign of arithmetic operation.
        /// </summary>
        /// <param name="ch">Sign of arithmetic operation</param>
        private void SetNumbersAndSign(char ch)
        {
            model.SetSignOperation(ch);
            model.SetNumber1(mainWindow.textBox.Text);
            model.SetNumber2(mainWindow.textBox.Text);
            LableContent = TextBoxText;
            TextBoxText = "";
            LableContent += model.ArithmeticSignToLable();
        }

        /// <summary>
        /// Filing out the textbox and the lable.
        /// </summary>
        /// <param name="num">Number</param>
        private void FilingOutFormAndLable(string num)
        {
            this.mainWindow.textBox.Text += model.AddCharToString(num);
            LableContent += model.AddCharToString(num);
        }

        #region Arithmetic operations buttons.
        //
        //Button "/"
        private void MainWindow_But_Dev_Click(object sender, EventArgs e)
        {
            SetNumbersAndSign('/');
        }

        //
        //Button "-"
        private void MainWindow_But_Sub_Click(object sender, EventArgs e)
        {
            SetNumbersAndSign('-');
        }

        //
        //Button "*"
        private void MainWindow_But_Mul_Click(object sender, EventArgs e)
        {
            SetNumbersAndSign('*');
        }

        //
        //Button "+"
        private void MainWindow_But_Add_Click(object sender, EventArgs e)
        {
            SetNumbersAndSign('+');
        }
        #endregion

        #region Number buttons.
        private void MainWindow_But_9_Click(object sender, EventArgs e)
        {
            FilingOutFormAndLable("9");
        }

        private void MainWindow_But_8_Click(object sender, EventArgs e)
        {
            FilingOutFormAndLable("8");
        }

        private void MainWindow_But_7_Click(object sender, EventArgs e)
        {
            FilingOutFormAndLable("7");
        }

        private void MainWindow_But_6_Click(object sender, EventArgs e)
        {
            FilingOutFormAndLable("6");
        }

        private void MainWindow_But_5_Click(object sender, EventArgs e)
        {
            FilingOutFormAndLable("5");
        }

        private void MainWindow_But_4_Click(object sender, EventArgs e)
        {
            FilingOutFormAndLable("4");
        }

        private void MainWindow_But_3_Click(object sender, EventArgs e)
        {
            FilingOutFormAndLable("3");
        }
        private void MainWindow_But_2_Click(object sender, EventArgs e)
        {
            FilingOutFormAndLable("2");
        }

        private void MainWindow_But_1_Click(object sender, EventArgs e)
        {
            FilingOutFormAndLable("1");
        }

        private void MainWindow_But_0_Click(object sender, EventArgs e)
        {
            FilingOutFormAndLable("0");
        }
        #endregion

        #region Auxiliary buttons.
        //
        //Button "C"
        private void MainWindow_But_Res_Click(object sender, EventArgs e)
        {
            TextBoxText = "";
            mainWindow.lable.Content = "";
            model.Reset();
        }

        //
        //Button "."
        private void MainWindow_But_Point_Click(object sender, EventArgs e)
        {
            FilingOutFormAndLable(",");
        }

        //
        //Button "="
        private void MainWindow_But_Equals_Click(object sender, EventArgs e)
        {
            if (TextBoxText.Length != 0)
                model.SetNumber2(TextBoxText);
            else
                model.SetNumber2(LableContent.ToString().Remove(LableContent.ToString().Length - 1, 1));

            model.GetResult();
            TextBoxText = model.ResultToTextBox();
            LableContent = "";
        }

        //
        //Button "+/-"
        private void MainWindow_But_ChangeSign_Click(object sender, EventArgs e)
        {

        }

        //
        //Button "<<"
        private void MainWindow_But_Corect_Click(object sender, EventArgs e)
        {
            if (TextBoxText.Length != 0)
            {
                TextBoxText = TextBoxText.Remove(TextBoxText.Length - 1, 1);

                if (LableContent.ToString().Length != 0)
                    LableContent = LableContent.ToString().Remove(LableContent.ToString().Length - 1, 1);
            }

            if (TextBoxText.Length == 0 && LableContent.ToString().Length == 0)
            {
                TextBoxText = "0";
                LableContent = "0";
            }
        }
        #endregion 
    }
}
