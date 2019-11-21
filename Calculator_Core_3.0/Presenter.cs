using System;

namespace Calculator_Core_3._0
{
    class Presenter
    {
        readonly Model model;
        readonly MainWindow mainWindow;
        int EqualCount { get; set; }
        //string TextBoxText { get; set; }
        //object LableContent { get; set; }

        public Presenter(MainWindow mainWindow)
        {
            model = new Model();
            this.mainWindow = mainWindow;
            this.mainWindow.textBox.Text = "";
            this.mainWindow.lable.Content = "";

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
            this.mainWindow.But_Correct_Click += MainWindow_But_Corect_Click;
            #endregion
        }

        /// <summary>
        /// Set first number and the sign of arithmetic operation.
        /// </summary>
        /// <param name="ch">Sign of arithmetic operation</param>
        private void SetNumbersAndSign(char ch)
        {
            if (mainWindow.textBox.Text.Length != 0)
            {
                model.SetSignOperation(ch);
                model.SetNumber1(mainWindow.textBox.Text);
                model.SetNumber2(mainWindow.textBox.Text);
                mainWindow.lable.Content = mainWindow.textBox.Text;
                mainWindow.textBox.Text = "";
                mainWindow.lable.Content += model.ArithmeticSignToLable();
            }
            else
                mainWindow.textBox.Text = "";
        }

        /// <summary>
        /// Filing out the textbox and the lable.
        /// </summary>
        /// <param name="num">Number</param>
        private void FilingOutTextBoxAndLable(string num)
        {
            //При соблюдении условия перед запятой будет дописан 0.
            if (num == "," && mainWindow.textBox.Text.Length == 0)
            {
                mainWindow.textBox.Text += "0" + num;
                mainWindow.lable.Content += "0" + num;
            }
            else
            {
                mainWindow.textBox.Text += num;

                //После добавления в Lable арифметического знака туда не добавляются символы.
                if (!mainWindow.lable.Content.ToString().Contains(model.ReturnSign()))
                    mainWindow.lable.Content += num;
            }
        }

        #region Auxiliary buttons.
        //
        //Button "C", all clear.
        private void MainWindow_But_Res_Click(object sender, EventArgs e)
        {
            mainWindow.textBox.Text = "";
            mainWindow.lable.Content = "";
            model.Reset();
        }

        //
        //Button "."
        private void MainWindow_But_Point_Click(object sender, EventArgs e)
        {
            FilingOutTextBoxAndLable(",");
        }

        //
        //Button "="
        private void MainWindow_But_Equals_Click(object sender, EventArgs e)
        {
            //Выполнятся только при условии, 
            //что установлен какой либо из знаков операции.
            if (model.SignSetOrNot())
            {
                if (mainWindow.lable.Content.ToString().Length != 0)
                    model.SetNumber2(mainWindow.lable.Content.ToString().Remove(mainWindow.lable.Content.ToString().Length - 1, 1));

                if (mainWindow.textBox.Text.Length != 0 && EqualCount == 0) model.SetNumber2(mainWindow.textBox.Text);

                model.GetResult();
                mainWindow.textBox.Text = model.ResultToTextBox();
                model.SetNumber1(mainWindow.textBox.Text);
                mainWindow.lable.Content = "";
                EqualCount = 1;
            }
        }

        //
        //Button "+/-", change the sign of a number.
        private void MainWindow_But_ChangeSign_Click(object sender, EventArgs e)
        {
            if (mainWindow.textBox.Text.StartsWith("-")) mainWindow.textBox.Text = mainWindow.textBox.Text.Remove(0, 1);
            else
                mainWindow.textBox.Text = mainWindow.textBox.Text.Insert(0, "-");
        }

        //
        //Button "<<", line adjustment.
        private void MainWindow_But_Corect_Click(object sender, EventArgs e)
        {
            if (mainWindow.textBox.Text.Length != 0)
            {
                mainWindow.textBox.Text = mainWindow.textBox.Text.Remove(mainWindow.textBox.Text.Length - 1, 1);

                //Корректировка строки в Lable происходит, если в ней не содержится зак операции.
                if (mainWindow.lable.Content.ToString().Length != 0 && !mainWindow.lable.Content.ToString().Contains(model.ReturnSign()))
                    mainWindow.lable.Content = mainWindow.lable.Content.ToString().Remove(mainWindow.lable.Content.ToString().Length - 1, 1);
            }
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
        private void MainWindow_But_9_Click(object sender, EventArgs e) => FilingOutTextBoxAndLable("9");
        private void MainWindow_But_8_Click(object sender, EventArgs e) => FilingOutTextBoxAndLable("8");
        private void MainWindow_But_7_Click(object sender, EventArgs e) => FilingOutTextBoxAndLable("7");
        private void MainWindow_But_6_Click(object sender, EventArgs e) => FilingOutTextBoxAndLable("6");
        private void MainWindow_But_5_Click(object sender, EventArgs e) => FilingOutTextBoxAndLable("5");
        private void MainWindow_But_4_Click(object sender, EventArgs e) => FilingOutTextBoxAndLable("4");
        private void MainWindow_But_3_Click(object sender, EventArgs e) => FilingOutTextBoxAndLable("3");
        private void MainWindow_But_2_Click(object sender, EventArgs e) => FilingOutTextBoxAndLable("2");
        private void MainWindow_But_1_Click(object sender, EventArgs e) => FilingOutTextBoxAndLable("1");
        private void MainWindow_But_0_Click(object sender, EventArgs e) => FilingOutTextBoxAndLable("0");
        #endregion
    }
}