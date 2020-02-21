using System;
using System.Windows.Controls;

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
            this.mainWindow.TextBlock.Text = "";

            #region Subscribe to events.

            this.mainWindow.But_0_Click += MainWindow_Num_Button_Click;
            this.mainWindow.But_1_Click += MainWindow_Num_Button_Click;
            this.mainWindow.But_2_Click += MainWindow_Num_Button_Click;
            this.mainWindow.But_3_Click += MainWindow_Num_Button_Click;
            this.mainWindow.But_4_Click += MainWindow_Num_Button_Click;
            this.mainWindow.But_5_Click += MainWindow_Num_Button_Click;
            this.mainWindow.But_6_Click += MainWindow_Num_Button_Click;
            this.mainWindow.But_7_Click += MainWindow_Num_Button_Click;
            this.mainWindow.But_8_Click += MainWindow_Num_Button_Click;
            this.mainWindow.But_9_Click += MainWindow_Num_Button_Click;

            this.mainWindow.But_Add_Click += MainWindow_Oper_Batton_Click;
            this.mainWindow.But_Sub_Click += MainWindow_Oper_Batton_Click;
            this.mainWindow.But_Mul_Click += MainWindow_Oper_Batton_Click;
            this.mainWindow.But_Dev_Click += MainWindow_Oper_Batton_Click;

            this.mainWindow.But_ChangeSign_Click += MainWindow_But_ChangeSign_Click;
            this.mainWindow.But_Equals_Click += MainWindow_But_Equals_Click;
            this.mainWindow.But_Point_Click += MainWindow_But_Point_Click;
            this.mainWindow.But_Res_Click += MainWindow_But_Res_Click;
            this.mainWindow.But_Correct_Click += MainWindow_But_Correct_Click;

            #endregion
        }

        private bool TextBoxIsEmpty() =>
            string.IsNullOrEmpty(mainWindow.TextBox.Text);

        private int TextBoxTextLength() =>
            mainWindow.TextBox.Text.Length;

        private string TextBoxTextRemove(int startindex, int count) =>
            mainWindow.TextBox.Text.Remove(startindex, count);

        private bool BlockIsEmpty() =>
            string.IsNullOrEmpty(mainWindow.TextBlock.Text);

        private bool BlockContains(string str) =>
            mainWindow.TextBlock.Text.Contains(str);

        private int BlockTextLength() =>
            mainWindow.TextBlock.Text.Length;

        private string BlockTextRemove(int startindex, int count) =>
            mainWindow.TextBlock.Text.Remove(startindex,count);

        /// <summary>
        /// Set first number and the sign of arithmetic operation.
        /// </summary>
        /// <param name="ch">Sign of arithmetic operation</param>
        private void InitArgumentsAndSign(char ch)
        {
            if (!TextBoxIsEmpty())
            {
                model.SetArithmeticSign(ch);
                model.SetNumber1(mainWindow.TextBox.Text);
                model.SetNumber2(mainWindow.TextBox.Text);
                mainWindow.TextBlock.Text = mainWindow.TextBox.Text;
                mainWindow.TextBox.Text = "";
                mainWindow.TextBlock.Text += model.SignToString();
            }
            else
                mainWindow.TextBox.Text = "";
        }
        /// <summary>
        /// Вывод сообщения об ошибке.
        /// </summary>
        /// <param name="str"></param>
        private void ErrorMesage(string str)
        {
            mainWindow.TextBlock.Text = "";
            mainWindow.TextBox.Text = str;
        }

        /// <summary>
        /// Filing out the Text_box and the Label.
        /// </summary>
        /// <param name="num">Number</param>
        private void AddTextToBoxAndLabel(string num)
        {
            if (num == "," && TextBoxIsEmpty())
            {
                mainWindow.TextBox.Text += "0" + num;
                mainWindow.TextBlock.Text += "0" + num;
            }
            else
            {
                mainWindow.TextBox.Text += num;

                if (!BlockContains(model.SignToString()))
                    mainWindow.TextBlock.Text += num;
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
            mainWindow.TextBlock.Text = "";
            equalCount = 0;
            model.Reset();
        }

        /// <summary>
        /// Button "." .
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_But_Point_Click(object sender, EventArgs e) =>
            AddTextToBoxAndLabel(",");

        /// <summary>
        /// Button "=".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_But_Equals_Click(object sender, EventArgs e)
        {
            if (!model.SignInitCheck())
                return;

            if (!BlockIsEmpty())
                model.SetNumber2(BlockTextRemove(BlockTextLength() - 1, 1));

            if (!TextBoxIsEmpty() && equalCount == 0)
                model.SetNumber2(mainWindow.TextBox.Text);

            if (Math.Abs(model.GetNumber2()) == 0 && model.GetArithmeticSign() == '/')
            {
                ErrorMesage("Деление на 0");
                model.Reset();
                return;
            }

            model.GetResult();
            mainWindow.TextBox.Text = model.ResultToString();
            model.SetNumber1(mainWindow.TextBox.Text);
            mainWindow.TextBlock.Text = "";
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
            if (TextBoxIsEmpty())
                return;

            if (!BlockIsEmpty() && !BlockContains(model.SignToString()))
                mainWindow.TextBlock.Text = BlockTextRemove(BlockTextLength() - 1, 1);

            mainWindow.TextBox.Text = TextBoxTextRemove(TextBoxTextLength() - 1, 1);
        }
        #endregion

        /// <summary>
        /// Возвращает часть имени нажатой клавиши.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="startindex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private string PressedButton(object sender, int startindex, int count)
        {
            Button button = (Button)sender;
            return button.Name.Substring(startindex, count);
        }

        /// <summary>
        /// Обработчик нажатия операционных клавиш.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Oper_Batton_Click(object sender, EventArgs e)
        {
            switch (PressedButton(sender, 6, 3))
            {
                case "Div":
                    InitArgumentsAndSign('/');
                    break;
                case "Sub":
                    InitArgumentsAndSign('-');
                    break;
                case "Mul":
                    InitArgumentsAndSign('*');
                    break;
                case "Add":
                    InitArgumentsAndSign('+');
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Обработчик нажатия числовых клавиш.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Num_Button_Click(object sender, EventArgs e) =>
            AddTextToBoxAndLabel(PressedButton(sender, 6, 1));
    }
}