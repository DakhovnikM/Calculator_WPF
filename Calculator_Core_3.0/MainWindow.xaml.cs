using System;
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
            new Presenter(this);

            foreach (UIElement item in LayOut.Children)
            {
                if (item is Button btn)
                {
                    btn.Click += Btn_Click;
                }
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            BtnName = ((Button)sender).Content.ToString();
            //TextBox.Text = btnName;
        }
    }
}