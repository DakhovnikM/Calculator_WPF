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

        EventHandler but_0_Click = null;
        public event EventHandler But_0_Click
        {
            add { but_0_Click += value; }
            remove { but_0_Click -= value; }
        }

        EventHandler but_1_Click = null;
        public event EventHandler But_1_Click
        {
            add { but_1_Click += value; }
            remove { but_1_Click -= value; }
        }

        EventHandler but_2_Click = null;
        public event EventHandler But_2_Click
        {
            add { but_2_Click += value; }
            remove { but_2_Click -= value; }
        }

        EventHandler but_3_Click = null;
        public event EventHandler But_3_Click
        {
            add { but_3_Click += value; }
            remove { but_3_Click -= value; }
        }

        EventHandler but_4_Click = null;
        public event EventHandler But_4_Click
        {
            add { but_4_Click += value; }
            remove { but_4_Click -= value; }
        }

        EventHandler but_5_Click = null;
        public event EventHandler But_5_Click
        {
            add { but_5_Click += value; }
            remove { but_5_Click -= value; }
        }

        EventHandler but_6_Click = null;
        public event EventHandler But_6_Click
        {
            add { but_6_Click += value; }
            remove { but_6_Click -= value; }
        }

        EventHandler but_7_Click = null;
        public event EventHandler But_7_Click
        {
            add { but_7_Click += value; }
            remove { but_7_Click -= value; }
        }

        EventHandler but_8_Click = null;
        public event EventHandler But_8_Click
        {
            add { but_8_Click += value; }
            remove { but_8_Click -= value; }
        }

        EventHandler but_9_Click = null;
        public event EventHandler But_9_Click
        {
            add { but_9_Click += value; }
            remove { but_9_Click -= value; }
        }

        EventHandler but_Add_Click = null;
        public event EventHandler But_Add_Click
        {
            add { but_Add_Click += value; }
            remove { but_Add_Click -= value; }
        }

        EventHandler but_Equals_Click = null;
        public event EventHandler But_Equals_Click
        {
            add { but_Equals_Click += value; }
            remove { but_Equals_Click -= value; }
        }

        EventHandler but_Point_Click = null;
        public event EventHandler But_Point_Click
        {
            add { but_Point_Click += value; }
            remove { but_Point_Click -= value; }
        }

        EventHandler but_Sub_Click = null;
        public event EventHandler But_Sub_Click
        {
            add { but_Sub_Click += value; }
            remove { but_Sub_Click -= value; }
        }

        EventHandler but_Mul_Click = null;
        public event EventHandler But_Mul_Click
        {
            add { but_Mul_Click += value; }
            remove { but_Mul_Click -= value; }
        }

        EventHandler but_Dev_Click = null;
        public event EventHandler But_Dev_Click
        {
            add { but_Dev_Click += value; }
            remove { but_Dev_Click -= value; }
        }

        EventHandler but_Res_Click = null;
        public event EventHandler But_Res_Click
        {
            add { but_Res_Click += value; }
            remove { but_Res_Click -= value; }
        }

        EventHandler but_ChangeSign_Click = null;
        public event EventHandler But_ChangeSign_Click
        {
            add { but_ChangeSign_Click += value; }
            remove { but_ChangeSign_Click -= value; }
        }

        EventHandler but_Correct_Click = null;
        public event EventHandler But_Correct_Click
        {
            add { but_Correct_Click += value; }
            remove { but_Correct_Click -= value; }
        }

        #endregion

        private void Button_0_Click(object sender, RoutedEventArgs e) => but_0_Click.Invoke(sender, e);
        private void Button_1_Click(object sender, RoutedEventArgs e) => but_1_Click.Invoke(sender, e);
        private void Button_2_Click(object sender, RoutedEventArgs e) => but_2_Click.Invoke(sender, e);
        private void Button_3_Click(object sender, RoutedEventArgs e) => but_3_Click.Invoke(sender, e);
        private void Button_4_Click(object sender, RoutedEventArgs e) => but_4_Click.Invoke(sender, e);
        private void Button_5_Click(object sender, RoutedEventArgs e) => but_5_Click.Invoke(sender, e);
        private void Button_6_Click(object sender, RoutedEventArgs e) => but_6_Click.Invoke(sender, e);
        private void Button_7_Click(object sender, RoutedEventArgs e) => but_7_Click.Invoke(sender, e);
        private void Button_8_Click(object sender, RoutedEventArgs e) => but_8_Click.Invoke(sender, e);
        private void Button_9_Click(object sender, RoutedEventArgs e) => but_9_Click.Invoke(sender, e);
        private void Button_Point_Click(object sender, RoutedEventArgs e) => but_Point_Click.Invoke(sender, e);
        private void Button_Equals_Click(object sender, RoutedEventArgs e) => but_Equals_Click.Invoke(sender, e);
        private void Button_Addition_Click(object sender, RoutedEventArgs e) => but_Add_Click.Invoke(sender, e);
        private void Button_Subtraction_Click(object sender, RoutedEventArgs e) => but_Sub_Click.Invoke(sender, e);
        private void Button_Multiplication_Click(object sender, RoutedEventArgs e) => but_Mul_Click.Invoke(sender, e);
        private void Button_Division_Click(object sender, RoutedEventArgs e) => but_Dev_Click.Invoke(sender, e);
        private void Button_Reset_Click(object sender, RoutedEventArgs e) => but_Res_Click.Invoke(sender, e);
        private void Button_ChangeSign_Click(object sender, RoutedEventArgs e) => but_ChangeSign_Click.Invoke(sender, e);
        private void ButtonCorrect_Click(object sender, RoutedEventArgs e) => but_Correct_Click.Invoke(sender, e);
    }
}
