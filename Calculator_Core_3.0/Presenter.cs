using System;
using System.Windows.Controls;

namespace Calculator_Core_3._0
{
    internal class Presenter
    {
        private readonly Model model;
        private readonly MainWindow mainWindow;
        private int equalCount;

        private string BoxText
        {
            get { return mainWindow.TextBox.Text; }
            set { mainWindow.TextBox.Text = value; }
        }

        private string BlockText
        {
            get { return mainWindow.TextBlock.Text; }
            set { mainWindow.TextBlock.Text = value; }
        }

        public Presenter(MainWindow mainWindow)
        {
            model = new Model();
            this.mainWindow = mainWindow;
            BoxText = "";
            BlockText = "";

            #region Subscribe to events.

            this.mainWindow.But_0_Click += MainWindow_Numeric_Button_Click;
            this.mainWindow.But_1_Click += MainWindow_Numeric_Button_Click;
            this.mainWindow.But_2_Click += MainWindow_Numeric_Button_Click;
            this.mainWindow.But_3_Click += MainWindow_Numeric_Button_Click;
            this.mainWindow.But_4_Click += MainWindow_Numeric_Button_Click;
            this.mainWindow.But_5_Click += MainWindow_Numeric_Button_Click;
            this.mainWindow.But_6_Click += MainWindow_Numeric_Button_Click;
            this.mainWindow.But_7_Click += MainWindow_Numeric_Button_Click;
            this.mainWindow.But_8_Click += MainWindow_Numeric_Button_Click;
            this.mainWindow.But_9_Click += MainWindow_Numeric_Button_Click;

            this.mainWindow.But_Add_Click += MainWindow_Operation_Button_Click;
            this.mainWindow.But_Sub_Click += MainWindow_Operation_Button_Click;
            this.mainWindow.But_Mul_Click += MainWindow_Operation_Button_Click;
            this.mainWindow.But_Dev_Click += MainWindow_Operation_Button_Click;
            this.mainWindow.But_Sqr_Click += MainWindow_But_Sqr_Click;

            this.mainWindow.But_ChangeSign_Click += MainWindow_But_InvertSign_Click;
            this.mainWindow.But_Equals_Click += MainWindow_But_Equals_Click;
            this.mainWindow.But_Point_Click += MainWindow_But_Point_Click;
            this.mainWindow.But_Res_Click += MainWindow_But_Reset_Click;
            this.mainWindow.But_Correct_Click += MainWindow_But_Correct_Click;

            #endregion
        }

        #region Вспомогательные методы.

        /// <summary>
        /// Проверка TextBox на наличие в нем строки.
        /// </summary>
        /// <returns></returns>
        private bool BoxTextIsEmpty() =>
            string.IsNullOrEmpty(BoxText);

        /// <summary>
        /// Возвращает количество символов в TextBox.
        /// </summary>
        /// <returns></returns>
        private int BoxTextLength() =>
            BoxText.Length;

        /// <summary>
        /// Удаляет символы в TextBox.
        /// </summary>
        /// <param name="startindex">Начальная позиция.</param>
        /// <param name="count">Количество удаляемых символов.</param>
        /// <returns></returns>
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
        #endregion


        private void InitArgument_1_AndSign(char ch)
        {
            if (!BoxTextIsEmpty())
            {
                model.SetArithmeticSign(ch);
                model.SetArgument_1(BoxText);
                model.SetArgument_2(BoxText);
                BlockText = BoxText;
                BoxText = "";
                BlockText += " " + model.SignToString();
            }
            else
                BoxText = "";
        }

        private void ErrorMesage(string str)
        {
            BlockText = "";
            BoxText = str;
        }

        private void AddTextToBoxAndBlock(string num)
        {
            if (num == "," && BoxTextIsEmpty())
            {
                BoxText += "0" + num;
                BlockText += "0";
            }
            else
                BoxText += num;

            if (!BlockTextContains(model.SignToString()))
                BlockText += num;
        }

        #region Auxiliary buttons.

        private void MainWindow_But_Reset_Click(object sender, EventArgs e)
        {
            BoxText = "";
            BlockText = "";
            equalCount = 0;
            model.Reset();
        }

        private void MainWindow_But_Point_Click(object sender, EventArgs e) =>
            AddTextToBoxAndBlock(",");

        private void MainWindow_But_Sqr_Click(object sender, EventArgs e)
        {
            InitArgument_1_AndSign('\0');
            model.GetSqr();
            BoxText = model.ResultToString();
            BlockText = "";
        }

        private void MainWindow_But_Equals_Click(object sender, EventArgs e)
        {

            if (equalCount == 1) return; //TODO повторное нажатие "=".

            if (!model.SignInitCheck())
                return;

            if (!BlockTextIsEmpty())
                model.SetArgument_2(BlockTextRemove(BlockTextLength() - 1, 1));

            if (!BoxTextIsEmpty() && equalCount == 0)
                model.SetArgument_2(BoxText);

            if (Math.Abs(model.GetArgument_2()) == 0 && model.GetArithmeticSign() == '/')
            {
                ErrorMesage("Деление на 0");
                model.Reset();
                return;
            }

            model.GetResult();
            BoxText = model.ResultToString();
            model.SetArgument_1(BoxText);
            BlockText += " " + model.GetArgument_2() + " =";
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

            if (!BlockTextIsEmpty() && !BlockTextContains(model.SignToString()))
                BlockText = BlockTextRemove(BlockTextLength() - 1, 1);

            BoxText = BoxTextRemove(BoxTextLength() - 1, 1);
        }
        #endregion

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
        private void MainWindow_Operation_Button_Click(object sender, EventArgs e)
        {
            switch (PressedButton(sender, 6, 3))
            {
                case "Div":
                    InitArgument_1_AndSign('/');
                    break;
                case "Sub":
                    InitArgument_1_AndSign('-');
                    break;
                case "Mul":
                    InitArgument_1_AndSign('*');
                    break;
                case "Add":
                    InitArgument_1_AndSign('+');
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
        private void MainWindow_Numeric_Button_Click(object sender, EventArgs e) =>
            AddTextToBoxAndBlock(PressedButton(sender, 6, 1));
    }
}