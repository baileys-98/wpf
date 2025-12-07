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

namespace PoorCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Op_Click(object sender, RoutedEventArgs e)
        {
            double a, b;
            if (!double.TryParse(A.Text, out a) || !double.TryParse(B.Text, out b))
            {
                Result.Text = "ошибка: отсутствие текста.";
                return;
            }

            var btn = sender as Button;
            try
            {
                switch (btn.Content.ToString())
                {
                 case "+": Result.Text = (a + b).ToString(); break;
                 case "-": Result.Text = (a - b).ToString(); break;
                 case "×": Result.Text = (a * b).ToString(); break;
                 case "÷":
                      if (b == 0) { Result.Text = "ошибка: / на 0"; }
                      else Result.Text = (a / b).ToString();
                      break;
                 default: Result.Text = "ошибка операции"; break;
                }
            }
            catch (Exception ex)
            {
                Result.Text = "ошибка: " + ex.Message;
            }
        }
    }
}
