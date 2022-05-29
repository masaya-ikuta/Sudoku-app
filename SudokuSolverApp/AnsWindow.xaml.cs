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
using System.Windows.Shapes;

namespace SudokuSolverApp
{
    /// <summary>
    /// AnsWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class AnsWindow : Window
    {
        public AnsWindow(StringBuilder s)
        {
            InitializeComponent();
            MainWindow mainWindow = new MainWindow();
            Label[] labels = new Label[81];
            for (int i = 0; i < 81; i++)
            {
                labels[i] = new Label();
                labels[i].Name = "label" + i;
                if (s[i].Equals("0"))
                {
                    labels[i].Content = "0";
                }
                else
                {
                    labels[i].Content = s[i];
                }
                int tmp = i + (i / 9) * 2;
                if (i % 9 >= 3 && i % 9 <= 5)
                {
                    tmp += 1;
                }
                else if (i % 9 >= 6 && i % 9 <= 8)
                {
                    tmp += 2;
                }
                if (i / 9 >= 3 && i / 9 <= 5)
                {
                    tmp += 11;
                }
                else if (i / 9 >= 6 && i / 9 <= 8)
                {
                    tmp += 22;
                }

                labels[i].FontSize = 20;
                Grid.SetColumn(labels[i], tmp % 11);
                Grid.SetRow(labels[i], tmp / 11);
                box_grid.Children.Add(labels[i]);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            App.Current.MainWindow.IsEnabled = true;
        }
    }
}
