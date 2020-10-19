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

        public EventHandler BtnClic;
        private event BtnClic getStr;
        public event BtnClic GetStr
        {
            add { getStr += value; }
            remove { getStr -= value; }
        }


        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            BtnName = ((Button)sender).Content.ToString();
            getStr?.Invoke();
        }

        public void ShowResult(string result)
        {
            TextBox.Text = result;

        }
    }
}