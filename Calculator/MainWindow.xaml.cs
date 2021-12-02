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
        
        private string FirstInput { get; set; }
        private string SecondInput { get; set; }
        public MainWindow()
        {
            FirstInput = null;
            SecondInput = null;
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
                    Operation.Text = buttonValue;
                    break;
                case "=":
                    Calc(FirstInput, SecondInput, Operation.Text);
                    break;
                default:
                    CalcLogic(buttonValue);
                    OutputText.Text += buttonValue;                
                    break;
            }

            
        }

        private void Clear_all()
        {
            OutputText.Text = string.Empty;
            Operation.Text = string.Empty;
            FirstInput = null;
            SecondInput = null;
        }

        private void Calc(string firstInput, string secondInput, string operation)
        {
            double first = Convert.ToDouble(firstInput);
            double second = Convert.ToDouble(secondInput);

            double result = 0;

            switch (operation)
            {
                case "+":
                    result = first + second;
                    break;
                case "-":
                    result = first - second;
                    break;
                case "*":
                    result = first * second;
                    break;
                case "/":
                    if (first == 0 || second == 0)
                    {
                        Clear_all();
                        OutputText.Text = "you can't devide with 0 xd";
                        return;
                    }
                    result = first / second;
                    break;

            }

            OutputText.Text = Convert.ToString(result);
            FirstInput = Convert.ToString(result);
            SecondInput = null;
            Operation.Text = null;
        }

        private void CalcLogic(string buttonValue)
        {
            if (SecondInput != null && IsOperationSign(buttonValue))
            {
                FirstInput = OutputText.Text;
                SecondInput = null;
            }
            else if (Operation.Text != string.Empty && FirstInput != null)
            {
                if (SecondInput == null)
                {
                    OutputText.Text = string.Empty;

                }
                SecondInput += buttonValue;
            }
            else //(SecondInput == null)
            {
                FirstInput += buttonValue;
            }
        }
        private bool IsOperationSign(string val)
        {
            string[] operationSigns = new string[] {"+","-","*","/" };

            foreach (var item in operationSigns)
            {
                if (val.Contains(item))
                {
                    return true;
                }
            }
            return false;
        }
    }

    
}
