using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool Inprogress
        { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            Clear_all();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var inputButton = sender as Button;
            string buttonValue = Convert.ToString(inputButton.Content);
            switch (buttonValue)
            {
                case "+":
                case "-":
                case "/":
                case "*":
                    Calc(buttonValue);
                    break;
                default:
                    break;
            }
            OutputText.Text += inputButton.Content;
        }

        private void Clear_all()
        {
            OutputText.Text = string.Empty;
            Operation.Text = string.Empty;
        }

        private void Calc(string operation)
        {
            
        }
    }
}
