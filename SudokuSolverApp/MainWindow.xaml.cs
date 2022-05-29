using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace SudokuSolverApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("SudokuSolveLib.dll")]
        static extern bool solve(StringBuilder dest, string src);
        ComboBox[] comboBoxes = new ComboBox[81];
        public MainWindow()
        {
            InitializeComponent();
            StringBuilder dest = new StringBuilder(1024);
            string src = "005608000000071000000000507780406001900700004001050000042000100000000800100002700";
            bool b = solve(dest, src);
            if (b)
            {
                Console.WriteLine(dest);
            }
            else
            {
                Console.WriteLine("ERROR :(");
            }
            
            for (int i = 0; i < 81; i++)
            {
                comboBoxes[i] = new ComboBox();
                comboBoxes[i].Name = "box" + i;
                comboBoxes[i].Items.Add(" ");
                int tmp = i + (i / 9) * 2;
                if(i % 9 >= 3 && i % 9 <= 5)
                {
                    tmp += 1;
                }
                else if(i % 9 >= 6 && i % 9 <= 8)
                {
                    tmp += 2;
                }
                if(i / 9 >= 3 && i / 9 <= 5)
                {
                    tmp += 11;
                }
                else if(i / 9 >= 6 && i / 9 <= 8)
                {
                    tmp += 22;
                }
                for(int j = 1; j < 10; j++)
                {
                    comboBoxes[i].Items.Add(j);
                    comboBoxes[i].FontSize = 20;
                }
                comboBoxes[i].SelectedIndex = 0;
                Grid.SetColumn(comboBoxes[i], tmp % 11);
                Grid.SetRow(comboBoxes[i], tmp / 11);
                box_grid.Children.Add(comboBoxes[i]);
            }
        }

        private void solve_button_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            for(int i = 0; i < 81; i++)
            {
                if(comboBoxes[i].SelectedItem.ToString().Equals(" "))
                {
                    s += "0";
                }
                else
                {
                    s += comboBoxes[i].SelectedItem.ToString();
                }
            }
            StringBuilder dest = new StringBuilder(1024);
            if(solve(dest, s))
            {
                Console.WriteLine(dest);
                AnsWindow ansWindow = new AnsWindow(dest);
                ansWindow.Show();
                this.IsEnabled = false;
            }
            else
            {
                Console.WriteLine("ERROR :(");
            }
        }
    }
}
