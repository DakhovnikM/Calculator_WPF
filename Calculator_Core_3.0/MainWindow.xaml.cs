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
        public string BtnContent { get; private set; }

        public Action<string> getButtonContent;

        /// <summary>
        /// Ctor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            new Controller(this);

            foreach (UIElement uielement in LayOut.Children)
            {
                if (uielement is Button button)
                {
                    button.Click += Btn_Click;
                }
            }
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            BtnContent = ((Button)sender).Content.ToString();
            getButtonContent?.Invoke(BtnContent);
        }
    }
}