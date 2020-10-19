using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;

namespace Calculator_Core_3._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string BtnName { get; private set; }

        /// <summary>
        /// Ctor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            new Controller(this);
            foreach (UIElement item in LayOut.Children)
            {
                if (item is Button btn)
                {
                    btn.Click += Btn_Click;
                }
            }
        }


        private RoutedEventHandler getStr;
        public event RoutedEventHandler GetStr
        {
            add { getStr += value; }
            remove { getStr -= value; }
        }


        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            BtnName += ((Button)sender).Content.ToString();
            TextBox.Text = BtnName;
            getStr?.Invoke(sender,e);
        }

        public void ShowResult(string result)
        {
            TextBox.Text = result;

        }
    }
}