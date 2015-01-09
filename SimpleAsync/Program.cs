using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SimpleAsync
{
    /// <summary>
    /// Taken from http://www.dotnetperls.com/async
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Create task and start it
            // ... Wait for it to complete
            Task task = new Task(ProcessDataAsync);
            Console.WriteLine("Before task.Start...."); //1. 
            task.Start();
            Console.WriteLine("After task.Start, before task.Wait..."); //2.
            task.Wait();

            Console.WriteLine("After task.Wait..."); //7.
            Console.WriteLine("The Last line in Main..."); //8.
            Console.ReadLine();

        }

        static async void ProcessDataAsync()
        {
            // Start the HandleFile method
            Console.WriteLine("Starting the HandleFile method..."); //3.
            Task<int> task = HandleFileAsync("lipsum.txt");

            // Control returns here before HandleFileAsync returns.
            // ... Prompt the user.
            Console.WriteLine("Please wait patiently " + 
                "while I do something important");  //5.

            // Wait for the HandleFile task to complete.
            // ... display its results
            int x = await task;
            Console.WriteLine("Count: " + x); //11.
        }

        static async Task<int> HandleFileAsync(string file)
        {
            Console.WriteLine("Entered HandleFileAsync method..."); //4.
            int count = 0;

            // Read in the specified file.
            // .. Use async StreamReader method.
            using (StreamReader reader = new StreamReader(file))
            {
                string v = await reader.ReadToEndAsync();

                // ... Process the file data somehow.
                count += v.Length;

                // ... A slow-running computation.
                //      Dummy code.
                Console.WriteLine("Before loop..."); //6.
                for (int i = 0; i < 1000; i++)
                {
                    int x = v.GetHashCode();
                    if (x == 0)
                    {
                        count--;
                    }
               }
                Console.WriteLine("After loop..."); //9.
            }
            Console.WriteLine("HandleFileAsync exiting..."); //10.
            return count;

        }
    }
}
