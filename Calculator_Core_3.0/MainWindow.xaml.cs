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
        public string btnName;
        public MainWindow()
        {

            InitializeComponent();
            new Presenter(this);

            foreach (Button item in LayOut.Children)
            {
                if (item is Button btn)
                {
                    item.Click += Btn_Click;
                }
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            btnName = ((Button)sender).ToString();
            TextBlock.Text = btnName;
        }
    }
}