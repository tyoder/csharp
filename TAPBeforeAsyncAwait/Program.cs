using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TAPBeforeAsyncAwait
{
    /// <summary>
    /// This program demonstrates the speed gained by using Tasks
    /// and Task-based Asnyc Programming (TAP in .NET 4.0 
    /// (Before async and await were introduced.)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            RunSyncronously();
            stopwatch.Stop();
            Console.WriteLine("Time elapsed for syncronous job: {0}", stopwatch.Elapsed);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            RunAsyncWithTasks();
            stopwatch.Stop();
            Console.WriteLine("Time elapsed for async job: {0}", stopwatch.Elapsed);

            Console.Read();
        }

        private static void RunSyncronously()
        {
            Console.WriteLine("Starting syncronous method...");
            for (int i = 0; i < 10; i++)
            {
                DoSomethingThatTakesAWhile();
            }
        }

        private static void RunAsyncWithTasks()
        {
            Console.WriteLine("Starting async method...");
            var taskList = new List<Task>();
            for (int i = 0; i < 10; i++)
            {
                var myTask = new Task(() => DoSomethingThatTakesAWhile());
                taskList.Add(myTask);
                myTask.Start();
            }
            Task.WaitAll(taskList.ToArray());
        }

        private static void DoSomethingThatTakesAWhile()
        {
            Thread.Sleep(1000);
        }


    }
}
