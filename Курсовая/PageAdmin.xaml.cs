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
    public partial class PageAdmin : Page
    {
        public PageAdmin()
        {
            InitializeComponent();
            DGrid.ItemsSource = КППEntities.GetContext().Проход.ToList();
            listCategory.SelectedIndex = 0;
        }
        // Отображения выбранной таблицы
        public void Collapsed()
        {
            DGrid.Visibility = Visibility.Collapsed;
            DGrid1.Visibility = Visibility.Collapsed;
            DGrid2.Visibility = Visibility.Collapsed;
            DGrid3.Visibility = Visibility.Collapsed;
            DGrid4.Visibility = Visibility.Collapsed;
            DGrid5.Visibility = Visibility.Collapsed;
            DGrid6.Visibility = Visibility.Collapsed;
            DGrid7.Visibility = Visibility.Collapsed;
            DGrid8.Visibility = Visibility.Collapsed;
        }
        // Выбо таблицы
        private void listCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (listCategory.SelectedIndex)
            {
                case 0:
                    DGrid.ItemsSource = КППEntities.GetContext().Проход.ToList();
                    Collapsed();
                    DGrid.Visibility = Visibility.Visible;
                    break;
                case 1:
                    DGrid1.ItemsSource = КППEntities.GetContext().Доступ.ToList();
                    Collapsed();
                    DGrid1.Visibility = Visibility.Visible;
                    break;
                case 2:
                    DGrid2.ItemsSource = КППEntities.GetContext().КПП.ToList();
                    Collapsed();
                    DGrid2.Visibility = Visibility.Visible;
                    break;
                case 3:
                    DGrid3.ItemsSource = КППEntities.GetContext().Пользователь.ToList();
                    Collapsed();
                    DGrid3.Visibility = Visibility.Visible;
                    break;
                case 4:
                    DGrid4.ItemsSource = КППEntities.GetContext().Посетитель.ToList();
                    Collapsed();
                    DGrid4.Visibility = Visibility.Visible;
                    break;
                case 5:
                    DGrid5.ItemsSource = КППEntities.GetContext().Пропуск.ToList();
                    Collapsed();
                    DGrid5.Visibility = Visibility.Visible;
                    break;
                case 6:
                    DGrid6.ItemsSource = КППEntities.GetContext().Роль.ToList();
                    Collapsed();
                    DGrid6.Visibility = Visibility.Visible;
                    break;
                case 7:
                    DGrid7.ItemsSource = КППEntities.GetContext().Транспорт.ToList();
                    Collapsed();
                    DGrid7.Visibility = Visibility.Visible;
                    break;
                case 8:
                    DGrid8.ItemsSource = КППEntities.GetContext().Ячейка_хранения.ToList();
                    Collapsed();
                    DGrid8.Visibility = Visibility.Visible;
                    break;
            }
        }
        // Поиск
        private void Poisc_TextChanged(object sender, TextChangedEventArgs e)
        {
            switch (listCategory.SelectedIndex)
            {
                case 0:
                    var currentProduct = КППEntities.GetContext().Проход.ToList();
                    currentProduct = currentProduct.Where(p => p.Посетитель.Фамилия.ToString().ToLower().Trim().Contains(Poisc.Text.ToLower())).ToList();
                    DGrid.ItemsSource = currentProduct.OrderBy(p => p.id).ToList();
                    break;
                case 4:
                    var currentProduct1 = КППEntities.GetContext().Посетитель.ToList();
                    currentProduct1 = currentProduct1.Where(p => p.Фамилия.ToString().ToLower().Trim().Contains(Poisc.Text.ToLower())).ToList();
                    DGrid4.ItemsSource = currentProduct1.OrderBy(p => p.id).ToList();
                    break;
                case 5:
                    var currentProduct2 = КППEntities.GetContext().Пропуск.ToList();
                    currentProduct2 = currentProduct2.Where(p => p.Посетитель.Фамилия.ToString().ToLower().Trim().Contains(Poisc.Text.ToLower())).ToList();
                    DGrid5.ItemsSource = currentProduct2.OrderBy(p => p.id).ToList();
                    break;
                case 7:
                    var currentProduct3 = КППEntities.GetContext().Транспорт.ToList();
                    currentProduct3 = currentProduct3.Where(p => p.Посетитель.Фамилия.ToString().ToLower().Trim().Contains(Poisc.Text.ToLower())).ToList();
                    DGrid7.ItemsSource = currentProduct3.OrderBy(p => p.id).ToList();
                    break;
            }
        }
        // Сохранение
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            КППEntities.GetContext().SaveChanges();
        }
    }
}