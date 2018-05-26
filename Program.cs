using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var task1 = Task.Run(() => {
                Thread.Sleep(1000);
                return 1;
            });
            var task2 = Task.Run(() => {
                Thread.Sleep(500);
                return 2;
            });
            var task3 = Task.Run(() => {
                Thread.Sleep(2000);
                return "3";
            });
            var task4 = Task.Run(() => {
                Thread.Sleep(2000);
                return "4";
            });
            var tasks = new Task[]{
                task1, task2, task3, task4
            };
            Task
            .WhenAll(tasks)
            .Wait();
            System.Console.WriteLine(task1.Result);
            System.Console.WriteLine(task2.Result);
            System.Console.WriteLine(task3.Result);
            System.Console.WriteLine(task4.Result);
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
