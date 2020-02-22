using System;
using System.Windows.Controls;

namespace Calculator_Core_3._0
{
    internal class Presenter
    {
        #region Поля и свойства.

        private readonly Model model;
        private readonly MainWindow mainWindow;
        private int equalCount;

        private int memory;

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

        #endregion

        #region Конструктор.
        public Presenter(MainWindow mainWindow)
        {
            model = new Model();
            this.mainWindow = mainWindow;
            BoxText = "";
            BlockText = "";
            memory = 0;

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

            this.mainWindow.But_Memory_Add += MainWindow_But_Memory_Add_Click;
            this.mainWindow.But_Memory_Sub += MainWindow_But_Memory_Sub_Click;
            this.mainWindow.But_Memory_Read += MainWindow_But_Memory_Read_Click;

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

        private void InitArgument_1_AndSign(char sign)
        {
            if (!BoxTextIsEmpty())
            {
                model.SetArithmeticSign(sign);
                model.SetArgument_1(BoxText);
                model.SetArgument_2(BoxText);
                BlockText = BoxText;
                BoxText = "";
                BlockText += " " + model.SignToString();
            }
            else
                BoxText = "";
        }

        private void AddTextToBoxAndBlock(string str)
        {
            if (str == "," && BoxTextIsEmpty())
            {
                BoxText += "0" + str;
                BlockText += "0";
            }
            else
                BoxText += str;

            if (!BlockTextContains(model.SignToString()))
                BlockText += str;
        }

        #region Функциональные клавиши.
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

            if (equalCount == 1)
                return; //TODO повторное нажатие "=".

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

        #region Клавиши памяти.
        private void MainWindow_But_Memory_Read_Click(object sender, EventArgs e)
        {
            BoxText = Convert.ToString(memory);
        }

        private void MainWindow_But_Memory_Sub_Click(object sender, EventArgs e)
        {
            memory -= Convert.ToInt32(BoxText);
        }

        private void MainWindow_But_Memory_Add_Click(object sender, EventArgs e)
        {
            memory += Convert.ToInt32(BoxText);
        }
        #endregion

        #region Обработка нажатия клавиш.

        /// <summary>
        /// Определяем нажатую клавишу по ее имени.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="startindex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        private string GetPressedButton(object sender, int startindex, int count)
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
            switch (GetPressedButton(sender, 6, 3))
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
            AddTextToBoxAndBlock(GetPressedButton(sender, 6, 1));

        #endregion
    }
}