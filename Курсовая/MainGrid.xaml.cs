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

namespace Курсовая
{
    /// <summary>
    /// Логика взаимодействия для MainGrid.xaml
    /// </summary>
    public partial class MainGrid : Window
    {
        public MainGrid()
        {
            InitializeComponent();
            if(Courier.DATA == "Администратор")
            {
                MainFrame.Content = new PageAdmin();
            }
            else if (Courier.DATA == "Вахтер")
            {
                MainFrame.Content = new PageVaxt();
            }
            else if (Courier.DATA == "Директор")
            {
                MainFrame.Content = new PageDirect();
            }
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            window.Close();
        }

        private void window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Button_Click(this, e);
            }
        }
    }
}
