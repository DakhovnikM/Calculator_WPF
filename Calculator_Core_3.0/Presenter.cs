using System;

namespace Calculator_Core_3._0
{
    internal class Presenter
    {
        private readonly Model model;
        private readonly MainWindow mainWindow;
        private int equalCount;

        public Presenter(MainWindow mainWindow)
        {
            model = new Model();
            this.mainWindow = mainWindow;
            this.mainWindow.TextBox.Text = "";
            this.mainWindow.Label.Content = "";

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
            this.mainWindow.But_Correct_Click += MainWindow_But_Correct_Click;

            #endregion
        }

        private bool TextBoxIsEmpty() => string.IsNullOrEmpty(mainWindow.TextBox.Text);
        private int TextBoxLength() => mainWindow.TextBox.Text.Length;
        private string TextBoxTextRemove(int startindex, int count) => mainWindow.TextBox.Text.Remove(startindex, count);
        private bool LabelIsEmpty() => string.IsNullOrEmpty(mainWindow.Label.Content.ToString());
        private bool LabelContains(string str) => mainWindow.Label.Content.ToString().Contains(str);
        private int LabelLength() => mainWindow.Label.Content.ToString().Length;
        private string LabelContentRemove(int startindex, int count) => mainWindow.Label.Content.ToString().Remove(startindex, count);

        /// <summary>
        /// Set first number and the sign of arithmetic operation.
        /// </summary>
        /// <param name="ch">Sign of arithmetic operation</param>
        private void SetNumbersAndSign(char ch)
        {
            if (!TextBoxIsEmpty())
            {
                model.SetSignOperation(ch);
                model.SetNumber1(mainWindow.TextBox.Text);
                model.SetNumber2(mainWindow.TextBox.Text);
                mainWindow.Label.Content = mainWindow.TextBox.Text;
                mainWindow.TextBox.Text = "";
                mainWindow.Label.Content += model.ArithmeticSignToLabel();
            }
            else mainWindow.TextBox.Text = "";
        }

        /// <summary>
        /// Filing out the Text_box and the Label.
        /// </summary>
        /// <param name="num">Number</param>
        private void FilingOutTextBoxAndLabel(string num)
        {
            if (num == "," && TextBoxIsEmpty())
            {
                mainWindow.TextBox.Text += "0" + num;
                mainWindow.Label.Content += "0" + num;
            }
            else
            {
                mainWindow.TextBox.Text += num;
                if (!LabelContains(model.ReturnSign())) mainWindow.Label.Content += num;
            }
        }

        #region Auxiliary buttons.

        /// <summary>
        /// Button "C", all clear.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_But_Res_Click(object sender, EventArgs e)
        {
            mainWindow.TextBox.Text = "";
            mainWindow.Label.Content = "";
            equalCount = 0;
            model.Reset();
        }

        /// <summary>
        /// Button "."
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_But_Point_Click(object sender, EventArgs e) => FilingOutTextBoxAndLabel(",");

        /// <summary>
        /// Button "="
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_But_Equals_Click(object sender, EventArgs e)
        {
            if (!model.SignSetOrNot()) return;

            if (!LabelIsEmpty())
                model.SetNumber2(LabelContentRemove(LabelLength() - 1, 1));

            if (!TextBoxIsEmpty() && equalCount == 0) model.SetNumber2(mainWindow.TextBox.Text);

            model.GetResult();
            mainWindow.TextBox.Text = model.ResultToTextBox();
            model.SetNumber1(mainWindow.TextBox.Text);
            mainWindow.Label.Content = "";
            equalCount = 1;
        }

        /// <summary>
        /// Button "+/-", change the sign of a number.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_But_ChangeSign_Click(object sender, EventArgs e)
        {
            mainWindow.TextBox.Text = mainWindow.TextBox.Text.StartsWith("-")
                ? TextBoxTextRemove(0, 1)
                : mainWindow.TextBox.Text.Insert(0, "-");
        }

        /// <summary>
        /// Button "<<", line adjustment.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_But_Correct_Click(object sender, EventArgs e)
        {
            if (TextBoxIsEmpty()) return;

            if (!LabelIsEmpty() && !LabelContains(model.ReturnSign()))
                mainWindow.Label.Content = LabelContentRemove(LabelLength() - 1, 1);

            mainWindow.TextBox.Text = TextBoxTextRemove(TextBoxLength() - 1, 1);
        }

        #endregion

        #region Arithmetic operations buttons.

        //
        //Buttons "/", "-", "*", "+".
        private void MainWindow_But_Dev_Click(object sender, EventArgs e) => SetNumbersAndSign('/');
        private void MainWindow_But_Sub_Click(object sender, EventArgs e) => SetNumbersAndSign('-');
        private void MainWindow_But_Mul_Click(object sender, EventArgs e) => SetNumbersAndSign('*');
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