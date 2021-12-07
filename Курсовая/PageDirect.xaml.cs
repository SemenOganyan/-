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
using LiveCharts;
using LiveCharts.Wpf;

namespace Курсовая
{
    /// <summary>
    /// Логика взаимодействия для PageDirect.xaml
    /// </summary>
    public partial class PageDirect : Page
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public PageDirect()
        {
            InitializeComponent();
            КППEntities db = new КППEntities();
            List<int> lis = new List<int>();
            List<int> lis1 = new List<int>();
            lis.Add(22);
            for (int i = 9; i < 12; i++)
            {
                var query = db.Проход.Count(c => c.Время_прохода.Value.Month == i || c.Вход_Выход == true);
                lis.Add(query);
                var query1 = db.Проход.Count(c => c.Время_прохода.Value.Month == i || c.Вход_Выход == false);
                lis1.Add(query1);
            }
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Вход",
                    Values = new ChartValues<int> (lis)
                },
                new LineSeries
                {
                    Title = "Выход",
                    Values = new ChartValues<int> (lis1)
                }
            };
            Labels = new[] {"Сентябрь", "Ноябрь", "Декабрь"};

            SeriesCollection[1].Values.Add(12);

            DataContext = this;
        }
    }
}
