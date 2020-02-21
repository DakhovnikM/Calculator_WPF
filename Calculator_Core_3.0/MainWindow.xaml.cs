using System;
using System.Windows;

namespace Calculator_Core_3._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            new Presenter(this);
        }

        #region Enents.

        private EventHandler but0Click = null;
        public event EventHandler But_0_Click
        {
            add => but0Click += value;
            remove => but0Click -= value;
        }

        private EventHandler but1Click = null;
        public event EventHandler But_1_Click
        {
            add => but1Click += value;
            remove => but1Click -= value;
        }

        private EventHandler but2Click = null;
        public event EventHandler But_2_Click
        {
            add => but2Click += value;
            remove => but2Click -= value;
        }

        private EventHandler but3Click = null;
        public event EventHandler But_3_Click
        {
            add => but3Click += value;
            remove => but3Click -= value;
        }

        private EventHandler but4Click = null;
        public event EventHandler But_4_Click
        {
            add => but4Click += value;
            remove => but4Click -= value;
        }

        private EventHandler but5Click = null;
        public event EventHandler But_5_Click
        {
            add => but5Click += value;
            remove => but5Click -= value;
        }

        private EventHandler but6Click = null;
        public event EventHandler But_6_Click
        {
            add => but6Click += value;
            remove => but6Click -= value;
        }

        private EventHandler but7Click = null;
        public event EventHandler But_7_Click
        {
            add => but7Click += value;
            remove => but7Click -= value;
        }

        private EventHandler but8Click = null;
        public event EventHandler But_8_Click
        {
            add => but8Click += value;
            remove => but8Click -= value;
        }

        private EventHandler but9Click = null;
        public event EventHandler But_9_Click
        {
            add => but9Click += value;
            remove => but9Click -= value;
        }

        private EventHandler butAddClick = null;
        public event EventHandler But_Add_Click
        {
            add => butAddClick += value;
            remove => butAddClick -= value;
        }

        private EventHandler butEqualsClick = null;
        public event EventHandler But_Equals_Click
        {
            add => butEqualsClick += value;
            remove => butEqualsClick -= value;
        }

        private EventHandler butPointClick = null;
        public event EventHandler But_Point_Click
        {
            add => butPointClick += value;
            remove => butPointClick -= value;
        }

        private EventHandler butSubClick = null;
        public event EventHandler But_Sub_Click
        {
            add => butSubClick += value;
            remove => butSubClick -= value;
        }

        private EventHandler butMulClick = null;
        public event EventHandler But_Mul_Click
        {
            add => butMulClick += value;
            remove => butMulClick -= value;
        }

        private EventHandler butDevClick = null;
        public event EventHandler But_Dev_Click
        {
            add => butDevClick += value;
            remove => butDevClick -= value;
        }

        private EventHandler butResClick = null;
        public event EventHandler But_Res_Click
        {
            add => butResClick += value;
            remove => butResClick -= value;
        }

        private EventHandler butChangeSignClick = null;
        public event EventHandler But_ChangeSign_Click
        {
            add => butChangeSignClick += value;
            remove => butChangeSignClick -= value;
        }

        private EventHandler butCorrectClick = null;
        public event EventHandler But_Correct_Click
        {
            add => butCorrectClick += value;
            remove => butCorrectClick -= value;
        }

        #endregion

        private void Button_0_Click(object sender, RoutedEventArgs e) => but0Click.Invoke(sender, e);
        private void Button_1_Click(object sender, RoutedEventArgs e) => but1Click.Invoke(sender, e);
        private void Button_2_Click(object sender, RoutedEventArgs e) => but2Click.Invoke(sender, e);
        private void Button_3_Click(object sender, RoutedEventArgs e) => but3Click.Invoke(sender, e);
        private void Button_4_Click(object sender, RoutedEventArgs e) => but4Click.Invoke(sender, e);
        private void Button_5_Click(object sender, RoutedEventArgs e) => but5Click.Invoke(sender, e);
        private void Button_6_Click(object sender, RoutedEventArgs e) => but6Click.Invoke(sender, e);
        private void Button_7_Click(object sender, RoutedEventArgs e) => but7Click.Invoke(sender, e);
        private void Button_8_Click(object sender, RoutedEventArgs e) => but8Click.Invoke(sender, e);
        private void Button_9_Click(object sender, RoutedEventArgs e) => but9Click.Invoke(sender, e);
        private void Button_Point_Click(object sender, RoutedEventArgs e) => butPointClick.Invoke(sender, e);
        private void Button_Equals_Click(object sender, RoutedEventArgs e) => butEqualsClick.Invoke(sender, e);
        private void Button_Addition_Click(object sender, RoutedEventArgs e) => butAddClick.Invoke(sender, e);
        private void Button_Subtraction_Click(object sender, RoutedEventArgs e) => butSubClick.Invoke(sender, e);
        private void Button_Multiplication_Click(object sender, RoutedEventArgs e) => butMulClick.Invoke(sender, e);
        private void Button_Division_Click(object sender, RoutedEventArgs e) => butDevClick.Invoke(sender, e);
        private void Button_Reset_Click(object sender, RoutedEventArgs e) => butResClick.Invoke(sender, e);
        private void Button_ChangeSign_Click(object sender, RoutedEventArgs e) => butChangeSignClick.Invoke(sender, e);
        private void ButtonCorrect_Click(object sender, RoutedEventArgs e) => butCorrectClick.Invoke(sender, e);

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}