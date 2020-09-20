using System;
using System.Windows.Controls;

namespace Calculator_Core_3._0
{
    internal class Presenter
    {
        #region Поля и свойства.

        private readonly Calculation calculation;
        private readonly MainWindow mainWindow;
        private int equalCount;
        private int memory;
        private string BoxText
        {
            get { return (mainWindow.TextBox.Text); }
            set { mainWindow.TextBox.Text = value; }
        }
        private string BlockText
        {
            get { return mainWindow.TextBlock.Text; }
            set { mainWindow.TextBlock.Text = value; }
        }

        #endregion

        #region Конструктор.
        public Presenter(MainWindow mainWindow)
        {
            calculation = new Calculation();
            this.mainWindow = mainWindow;
            BoxText = "0";
            BlockText = "";
            memory = 0;

            #region Subscribe to events.

            this.mainWindow.But_0_Click += MainWindow_Numeric_Buttons_Click;
            this.mainWindow.But_1_Click += MainWindow_Numeric_Buttons_Click;
            this.mainWindow.But_2_Click += MainWindow_Numeric_Buttons_Click;
            this.mainWindow.But_3_Click += MainWindow_Numeric_Buttons_Click;
            this.mainWindow.But_4_Click += MainWindow_Numeric_Buttons_Click;
            this.mainWindow.But_5_Click += MainWindow_Numeric_Buttons_Click;
            this.mainWindow.But_6_Click += MainWindow_Numeric_Buttons_Click;
            this.mainWindow.But_7_Click += MainWindow_Numeric_Buttons_Click;
            this.mainWindow.But_8_Click += MainWindow_Numeric_Buttons_Click;
            this.mainWindow.But_9_Click += MainWindow_Numeric_Buttons_Click;

            this.mainWindow.But_Add_Click += MainWindow_Operation_Buttons_Click;
            this.mainWindow.But_Sub_Click += MainWindow_Operation_Buttons_Click;
            this.mainWindow.But_Mul_Click += MainWindow_Operation_Buttons_Click;
            this.mainWindow.But_Dev_Click += MainWindow_Operation_Buttons_Click;
            this.mainWindow.But_Sqr_Click += MainWindow_But_Sqr_Click;

            this.mainWindow.But_ChangeSign_Click += MainWindow_But_InvertSign_Click;
            this.mainWindow.But_Equals_Click += MainWindow_But_Equals_Click;
            this.mainWindow.But_Point_Click += MainWindow_But_Point_Click;
            this.mainWindow.But_Res_Click += MainWindow_But_Reset_Click;
            this.mainWindow.But_Correct_Click += MainWindow_But_Correct_Click;

            this.mainWindow.But_Memory_Add += MainWindow_Memory_Buttons_Click;
            this.mainWindow.But_Memory_Sub += MainWindow_Memory_Buttons_Click;
            this.mainWindow.But_Memory_Read += MainWindow_Memory_Buttons_Click;

            #endregion
        }
        #endregion

        #region Вспомогательные методы.

        private bool BoxTextIsEmpty() =>
            string.IsNullOrEmpty(BoxText);

        private int BoxTextLength() =>
            BoxText.Length;

        private string BoxTextRemove(int startindex, int count) =>
            BoxText.Remove(startindex, count);

        private bool BlockTextIsEmpty() =>
            string.IsNullOrEmpty(BlockText);

        private bool BlockTextContains(string str) =>
           BlockText.Contains(str);

        private int BlockTextLength() =>
           BlockText.Length;

        private string BlockTextRemove(int startindex, int count) =>
            BlockText.Remove(startindex, count);

        private void ErrorMesage(string str)
        {
            BlockText = "";
            BoxText = str;
        }

        #endregion

        private void FirstArgument_ArithmeticSign_Init(char sign)
        {
            if (!BoxTextIsEmpty())
            {
                calculation.ArithmeticSign = sign;
                calculation.FirstArgument = double.Parse(BoxText);
                calculation.SecondArgument = double.Parse(BoxText);
                BlockText = BoxText;
                BoxText = "";
                BlockText += " " + calculation.ArithmeticSign;
            }
            else
                BoxText = "";
        }

        private void AddTextToBoxAndBlock(string str)
        {
            if (str == "," && BoxText == "0")
            {
                BoxText += str;
                BlockText += "0";
            }
            else
            {
                BoxText = BoxText == "0" ? "" : BoxText;
                BoxText += str;
            }

            if (!BlockTextContains(calculation.ArithmeticSign.ToString()))
                BlockText += str;
        }

        #region Обработка нажатия клавиш.

        #region Обработка функциональных клавиш.
        private void MainWindow_But_Reset_Click(object sender, EventArgs e)
        {
            BoxText = "0";
            BlockText = "";
            equalCount = 0;
            calculation.Reset();
        }

        private void MainWindow_But_Point_Click(object sender, EventArgs e) =>
            AddTextToBoxAndBlock(",");

        private void MainWindow_But_Sqr_Click(object sender, EventArgs e)
        {
            FirstArgument_ArithmeticSign_Init('\0');
            calculation.SqrCalculation();
            BoxText = calculation.Result.ToString();
            BlockText = "";
        }

        private void MainWindow_But_Equals_Click(object sender, EventArgs e)
        {

            if (equalCount == 1)
                return; //TODO повторное нажатие "=".

            if (!calculation.SignInitCheck())
                return;

            if (!BlockTextIsEmpty())
                calculation.SecondArgument = double.Parse(BlockTextRemove(BlockTextLength() - 1, 1));

            if (!BoxTextIsEmpty() && equalCount == 0)
                calculation.SecondArgument = double.Parse(BoxText);

            if (Math.Abs(calculation.SecondArgument) == 0 && calculation.ArithmeticSign == '/')
            {
                ErrorMesage("Деление на 0");
                calculation.Reset();
                return;
            }

            calculation.ArithmeticOpCalculation();
            BoxText = calculation.Result.ToString();
            calculation.FirstArgument = double.Parse(BoxText);
            BlockText += " " + calculation.SecondArgument + " =";
            equalCount = 1;
        }

        private void MainWindow_But_InvertSign_Click(object sender, EventArgs e)
        {
            BoxText = BoxText.StartsWith("-")
                ? BoxTextRemove(0, 1)
                : BoxText.Insert(0, "-");
        }

        private void MainWindow_But_Correct_Click(object sender, EventArgs e)
        {
            if (BoxTextIsEmpty())
                return;

            if (!BlockTextIsEmpty() && !BlockTextContains(calculation.ArithmeticSign.ToString()))
                BlockText = BlockTextRemove(BlockTextLength() - 1, 1);

            BoxText = BoxTextRemove(BoxTextLength() - 1, 1);
        }
        #endregion

        private string PressedButton(object sender, int startindex, int count)
        {
            Button button = (Button)sender;
            return button.Name.Substring(startindex, count);
        }

        private void MainWindow_Operation_Buttons_Click(object sender, EventArgs e)
        {
            switch (PressedButton(sender, 6, 3))
            {
                case "Div":
                    FirstArgument_ArithmeticSign_Init('/');
                    break;
                case "Sub":
                    FirstArgument_ArithmeticSign_Init('-');
                    break;
                case "Mul":
                    FirstArgument_ArithmeticSign_Init('*');
                    break;
                case "Add":
                    FirstArgument_ArithmeticSign_Init('+');
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        private void MainWindow_Memory_Buttons_Click(object sender, EventArgs e)
        {
            switch (PressedButton(sender, 6, 1))
            {
                case "A":
                    memory += Convert.ToInt32(BoxText);
                    break;
                case "S":
                    memory -= Convert.ToInt32(BoxText);
                    break;
                case "R":
                    BoxText = Convert.ToString(memory);
                    break;
                default:
                    throw new InvalidOperationException();
            }
        }

        private void MainWindow_Numeric_Buttons_Click(object sender, EventArgs e)
        {
            AddTextToBoxAndBlock(PressedButton(sender, 6, 1));
        }

        #endregion
    }
}