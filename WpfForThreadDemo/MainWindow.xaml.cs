﻿using System;
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
            LinqDemo.Click += LinqDemo_Click;
        }
        /**
         * Linq demo
         */
        private void LinqDemo_Click(object sender, RoutedEventArgs e)
        {
            // Specify the data source.
            int[] scores = { 97, 92, 81, 60 };

            // Define the query expression.
            IEnumerable<int> scoreQuery =
                from score in scores
                where score > 80
                select score;

            // Execute the query.
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
