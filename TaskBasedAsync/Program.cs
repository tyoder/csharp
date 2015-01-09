using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBasedAsync
{
    /// <summary>
    /// http://www.infoq.com/articles/Tasks-Async-Await
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // First Sample
            /*var fs = File.OpenRead("lipsum.txt");
            var readBuffer = new byte[fs.Length];
            fs.ReadAsync(readBuffer, 0, (int) fs.Length)
                .ContinueWith(task =>
                {
                    if (task.Status == TaskStatus.RanToCompletion)
                    {
                        Console.WriteLine("Read {0} bytes successfully", task.Result);
                    }
                    else
                    {
                        Console.WriteLine("Exception occurred");
                    }

                    fs.Dispose();

                });
            */


            //Second Sample using WhenAll
            var read1 = ReadFileAsync("lipsum.txt");
            var read2 = ReadFileAsync("lipsum2.txt");

            Console.WriteLine("Just before WhenAll...");

            // WhenAll does not block the main thread and utilizes a Continuation
            Task.WhenAll(read1, read2)
                .ContinueWith(task =>
                {
                    Console.WriteLine("All files have been read successfully.");

                });
           
            // Compare WhenAll to WaitAll...WaitAll blocks until the tasks are done
            //Task.WaitAll(read1, read2);
            //Console.WriteLine("All files have been read successfully.");



            // do other work here
            Console.WriteLine("Other work being done.....");
            Console.ReadLine();
        }

        private static Task<int> ReadFileAsync(string filePath)
        {
            Console.WriteLine("Entered ReadFileAsync...");
            var fs = File.OpenRead(filePath);
            var readBuffer = new byte[fs.Length];
            var readTask = fs.ReadAsync(readBuffer, 0, (int) fs.Length);

            readTask.ContinueWith(task =>
            {
                if (task.Status == TaskStatus.RanToCompletion)
                    Console.WriteLine("Read {0} bytes successfully from file {1}", task.Result, filePath);
                else
                    Console.WriteLine("Exception occurred while reading file {0}", filePath);

                fs.Dispose();
            });

            return readTask;
        }
    }
}
