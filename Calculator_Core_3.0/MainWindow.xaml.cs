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

        private EventHandler _but0Click = null;

        public event EventHandler But_0_Click
        {
            add => _but0Click += value;
            remove => _but0Click -= value;
        }

        private EventHandler _but1Click = null;

        public event EventHandler But_1_Click
        {
            add => _but1Click += value;
            remove => _but1Click -= value;
        }

        private EventHandler _but2Click = null;

        public event EventHandler But_2_Click
        {
            add => _but2Click += value;
            remove => _but2Click -= value;
        }

        private EventHandler _but3Click = null;

        public event EventHandler But_3_Click
        {
            add => _but3Click += value;
            remove => _but3Click -= value;
        }

        private EventHandler _but4Click = null;

        public event EventHandler But_4_Click
        {
            add => _but4Click += value;
            remove => _but4Click -= value;
        }

        private EventHandler _but5Click = null;

        public event EventHandler But_5_Click
        {
            add => _but5Click += value;
            remove => _but5Click -= value;
        }

        private EventHandler _but6Click = null;

        public event EventHandler But_6_Click
        {
            add => _but6Click += value;
            remove => _but6Click -= value;
        }

        private EventHandler _but7Click = null;

        public event EventHandler But_7_Click
        {
            add => _but7Click += value;
            remove => _but7Click -= value;
        }

        private EventHandler _but8Click = null;

        public event EventHandler But_8_Click
        {
            add => _but8Click += value;
            remove => _but8Click -= value;
        }

        private EventHandler _but9Click = null;

        public event EventHandler But_9_Click
        {
            add => _but9Click += value;
            remove => _but9Click -= value;
        }

        private EventHandler _butAddClick = null;

        public event EventHandler But_Add_Click
        {
            add => _butAddClick += value;
            remove => _butAddClick -= value;
        }

        private EventHandler _butEqualsClick = null;

        public event EventHandler But_Equals_Click
        {
            add => _butEqualsClick += value;
            remove => _butEqualsClick -= value;
        }

        private EventHandler _butPointClick = null;

        public event EventHandler But_Point_Click
        {
            add => _butPointClick += value;
            remove => _butPointClick -= value;
        }

        private EventHandler _butSubClick = null;

        public event EventHandler But_Sub_Click
        {
            add => _butSubClick += value;
            remove => _butSubClick -= value;
        }

        private EventHandler _butMulClick = null;

        public event EventHandler But_Mul_Click
        {
            add => _butMulClick += value;
            remove => _butMulClick -= value;
        }

        private EventHandler _butDevClick = null;

        public event EventHandler But_Dev_Click
        {
            add => _butDevClick += value;
            remove => _butDevClick -= value;
        }

        private EventHandler _butResClick = null;

        public event EventHandler But_Res_Click
        {
            add => _butResClick += value;
            remove => _butResClick -= value;
        }

        private EventHandler _butChangeSignClick = null;

        public event EventHandler But_ChangeSign_Click
        {
            add => _butChangeSignClick += value;
            remove => _butChangeSignClick -= value;
        }

        private EventHandler _butCorrectClick = null;

        public event EventHandler But_Correct_Click
        {
            add => _butCorrectClick += value;
            remove => _butCorrectClick -= value;
        }

        #endregion

        private void Button_0_Click(object sender, RoutedEventArgs e) => _but0Click.Invoke(sender, e);
        private void Button_1_Click(object sender, RoutedEventArgs e) => _but1Click.Invoke(sender, e);
        private void Button_2_Click(object sender, RoutedEventArgs e) => _but2Click.Invoke(sender, e);
        private void Button_3_Click(object sender, RoutedEventArgs e) => _but3Click.Invoke(sender, e);
        private void Button_4_Click(object sender, RoutedEventArgs e) => _but4Click.Invoke(sender, e);
        private void Button_5_Click(object sender, RoutedEventArgs e) => _but5Click.Invoke(sender, e);
        private void Button_6_Click(object sender, RoutedEventArgs e) => _but6Click.Invoke(sender, e);
        private void Button_7_Click(object sender, RoutedEventArgs e) => _but7Click.Invoke(sender, e);
        private void Button_8_Click(object sender, RoutedEventArgs e) => _but8Click.Invoke(sender, e);
        private void Button_9_Click(object sender, RoutedEventArgs e) => _but9Click.Invoke(sender, e);
        private void Button_Point_Click(object sender, RoutedEventArgs e) => _butPointClick.Invoke(sender, e);
        private void Button_Equals_Click(object sender, RoutedEventArgs e) => _butEqualsClick.Invoke(sender, e);
        private void Button_Addition_Click(object sender, RoutedEventArgs e) => _butAddClick.Invoke(sender, e);
        private void Button_Subtraction_Click(object sender, RoutedEventArgs e) => _butSubClick.Invoke(sender, e);
        private void Button_Multiplication_Click(object sender, RoutedEventArgs e) => _butMulClick.Invoke(sender, e);
        private void Button_Division_Click(object sender, RoutedEventArgs e) => _butDevClick.Invoke(sender, e);
        private void Button_Reset_Click(object sender, RoutedEventArgs e) => _butResClick.Invoke(sender, e);
        private void Button_ChangeSign_Click(object sender, RoutedEventArgs e) => _butChangeSignClick.Invoke(sender, e);
        private void ButtonCorrect_Click(object sender, RoutedEventArgs e) => _butCorrectClick.Invoke(sender, e);
    }
}