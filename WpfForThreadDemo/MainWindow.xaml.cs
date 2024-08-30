using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ThreadDemo.Click += ThreadDemo_Click;
        }

        private void ThreadDemo_Click(object sender, RoutedEventArgs e)
        {
            //使用Thread类来异步编程
            Thread thread = new Thread(new ThreadStart(() =>
            {
                Thread.Sleep(5000);
                MessageBox.Show("time is over");
            }));
            
            thread.Start();
            //通过async和await关键字
            //ToDoWorking();

        }

        public async void ToDoWorking()
        {
            await Task.Run(() => {
                Thread.Sleep(8000);
                MessageBox.Show("show by async");
                Thread.Sleep(8000);
            }); 
           
        }
    }
}
