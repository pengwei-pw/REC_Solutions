using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfForThreadDemo
{

    record City(string Name, long Population);
    record Country(string Name, double Area, long Population, List<City> Cities);
    record Product(string Name, string Category);
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static readonly City[] cities = new City[] {
            new City("Tokyo", 37_833_000),
            new City("Delhi", 30_290_000),
            new City("Shanghai", 27_110_000),
            new City("São Paulo", 22_043_000),
            new City("Mumbai", 20_412_000),
            new City("Beijing", 20_384_000),
            new City("Cairo", 18_772_000),
            new City("Dhaka", 17_598_000),
            new City("Osaka", 19_281_000),
            new City("New York-Newark", 18_604_000),
            new City("Karachi", 16_094_000),
            new City("Chongqing", 15_872_000),
            new City("Istanbul", 15_029_000),
            new City("Buenos Aires", 15_024_000),
            new City("Kolkata", 14_850_000),
            new City("Lagos", 14_368_000),
            new City("Kinshasa", 14_342_000),
            new City("Manila", 13_923_000),
            new City("Rio de Janeiro", 13_374_000),
            new City("Tianjin", 13_215_000)
        };
        static readonly Country[] countries = new Country[] {
            new Country("Vatican City", 0.44, 526, new List<City> {new City("Vatican City", 826) }),
            new Country("Monaco", 2.02, 38_000, new List<City> {new City("Monte Carlo", 38_000) }),
            new Country("Nauru", 21, 10_900, new List<City> {new City("Yaren", 1_100)}),
            new Country("Tuvalu", 26, 11_600, new List<City>{new City("Funafuti", 6_200) }),
            new Country("San Marino", 61, 33_900, new List<City> {new City("San Marino", 4_500) }),
            new Country("Liechtenstein", 160, 38_000, new List<City> {new City("Vaduz", 5_200)}),
            new Country("Marshall Islands", 181, 58_000, new List<City> {new City("Majuro", 28_000)}),
            new Country("Saint Kitts & Nevis", 261, 53_000, new List<City> {new City("Basseterre", 13_000) })
        };


        public MainWindow()
        {
            InitializeComponent();
            ThreadDemo.Click += ThreadDemo_Click;
            LinqDemo1.Click += LinqDemo_Click;
            LinqDemo2.Click += LinqDemo2_Click;
            LinqDemo3.Click += LinqDemo3_Click;
        }
        /// <summary>
        /// linq demo3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void LinqDemo3_Click(object sender, RoutedEventArgs e)
        {
            var largeCitiesList = (
                from country in countries
                from city in country.Cities
                where city.Population > 10000
                select city
            ).ToList();

            // or split the expression
            IEnumerable<City> largeCitiesQuery =
                from country in countries
                from city in country.Cities
                where city.Population > 10000
                select city;
            var largeCitiesList2 = largeCitiesQuery.ToList();
        }

        /// <summary>
        /// linqDemo2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinqDemo2_Click(object sender, RoutedEventArgs e)
        {
            City[] cities = new City[]
            {
                new City("Tokyo", 37_833_000),
                new City("Delhi", 30_290_000),
                new City("Shanghai", 27_110_000),
                new City("São Paulo", 22_043_000)
            };

            //Query syntax
            IEnumerable<City> queryMajorCities =
                from city in cities
                where city.Population > 100000
                select city;

            // Execute the query to produce the results
            foreach (City city in queryMajorCities)
            {
                Trace.WriteLine(city);
            }

            // Output:
            // City { Population = 120000 }
            // City { Population = 112000 }
            // City { Population = 150340 }

            // Method-based syntax
            IEnumerable<City> queryMajorCities2 = cities.Where(c => c.Population > 100000);
        }

        /// <summary>
        /// linqDemo1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinqDemo_Click(object sender, RoutedEventArgs e)
        {
            // data resource
            int[] scores = { 97, 92, 81, 60 };

            // Define the query expression.未执行查询
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            //将查询结果存储
            var scoreQuerylist = scoreQuery.ToList();
            Trace.WriteLine(scoreQuerylist[2]);

            scores[2] = 88;
            Trace.WriteLine(scoreQuerylist[2]);

            var scoreQuerylistRe = scoreQuery.ToList();
            Trace.WriteLine(scoreQuerylistRe[2]);
            //打印结果 81 81 88 
            //由此结果得出每次查询都是对数据源的重新查询

            // Execute the query. 立即查询
            foreach (int i in scoreQuery)
            {
                Trace.Write(i + " ");
            }

            // Output: 97 92 81
        }

        private void ThreadDemo_Click(object sender, RoutedEventArgs e)
        {
            //使用Thread类来异步编程
            //Thread thread = new Thread(new ThreadStart(() =>
            //{
            //    Thread.Sleep(5000);
            //    MessageBox.Show("time is over");
            //}));

            //thread.Start();
            //通过async和await关键字
            ToDoWorking();
            //通过线程池
            //ThreadPool.SetMaxThreads(10, 5);
            //WaitCallback waitCallback = new WaitCallback((obj) => {
            //    int? str = (int?)obj;
            //    Console.WriteLine(str);
            //    Trace.WriteLine(str);
            //});
            //for (int i = 0; i < 10; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(waitCallback, i);
            //}
            //Parallel class
            //Parallel.Invoke();
        }
        public async Task<String> doSomeConsumeTimeAsync()
        {
            await Task.Delay(5000);
            return "i am ok";
        } 
        public void DoJ()
        {
            //Thread.Sleep(2000);
            MessageBox.Show("doj ok");
            //do some work
        }
        public async void ToDoWorking()
        {
            Task<string> cc = doSomeConsumeTimeAsync();
            
            DoJ();

            string value = await cc;
            MessageBox.Show(value);
        }
    }
}
