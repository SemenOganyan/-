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

namespace Курсовая
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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

        private void OnPassword(object sender, RoutedEventArgs e)
        {
            if (textBoxPass.Password.Length > 0)
            {
                WaterMark.Visibility = Visibility.Collapsed;
            }
            else
            {
                WaterMark.Visibility = Visibility.Visible;
            }
        }
        string autorizKey = null;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string login = textBoxName.Text;
            string Pass = textBoxPass.Password;
            Пользователь autoriz = null;

            using (КППEntities db = new КППEntities())
            {
                autoriz = db.Пользователь.Where(b => b.Логин == login && b.Пароль == Pass).FirstOrDefault();
                if (autoriz != null)
                {
                    autorizKey = autoriz.Роль.Название.Trim();
                    Courier.DATA = autorizKey;
                }
            }
            if (autoriz != null)
            {
                MessageBox.Show("Вы вошли под: " + autorizKey);
                MainGrid grid = new MainGrid();
                grid.Show();
                window.Close();
            }
            else
            {
                MessageBox.Show("Введены неверные данные");
            }
        }
        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click_1(this, e);
            }
            if (e.Key == Key.Escape)
            {
                Button_Click(this, e);
            }
        }
    }
}
