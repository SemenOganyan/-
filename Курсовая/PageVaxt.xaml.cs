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
    public partial class PageVaxt : Page
    {
        public PageVaxt()
        {
            InitializeComponent();
            DGrid.ItemsSource = КППEntities.GetContext().Проход.ToList();
        }

        // Поиск
        private void Poisc_TextChanged(object sender, TextChangedEventArgs e)
        {
            var currentProduct = КППEntities.GetContext().Проход.ToList();
            currentProduct = currentProduct.Where(p => p.Посетитель.Фамилия.ToString().ToLower().Trim().Contains(Poisc.Text.ToLower())).ToList();
            DGrid.ItemsSource = currentProduct.OrderBy(p => p.id).ToList();
        }
        // Добавление
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            bool one = true, two = false, three = false;
            if (comboBOX1.SelectedIndex.ToString() == 0.ToString())
                three = true;
            else
                three = false;
            using (КППEntities db = new КППEntities())
            {
                if (comboBOX.SelectedIndex.ToString() == 0.ToString())
                    one = true;
                else
                    one = false;
                if (comboBOX1.SelectedIndex.ToString() == 0.ToString())
                    two = true;
                else
                    two = false;
                Проход п1 = new Проход { Время_прохода = DateTime.Now, Вход_Выход = one, Код_КПП = rnd.Next(1,4), Код_посетителя = rnd.Next(10,14), Транспорт = two};
                db.Проход.Add(п1);
                db.SaveChanges();
                DGrid.ItemsSource = КППEntities.GetContext().Проход.ToList();
            }
            if (three == true)
            {
                using (КППEntities db = new КППEntities())
                {
                    Ячейка_хранения я1 = new Ячейка_хранения { Код_КПП = rnd.Next(1,4), Время_оставления = DateTime.Now, Код_посетителя = rnd.Next(10, 14)};
                    db.Ячейка_хранения.Add(я1);
                    db.SaveChanges();
                }
            }
        }
    }
}
