using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncAwaitReplaceTaskBased
{
    /// <summary>
    /// http://www.infoq.com/articles/Tasks-Async-Await
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Number of bytes is {0}", ReadFileAsync("lipsum.txt").Result);

            ReadFileAsync("lipsum.txt").ContinueWith(task => Console.Write("Number of bytes is {0}", task.Result));
            //do stuff while file read is taking place.
            Console.WriteLine("Doing stuff...");

            Console.ReadLine();
        }

        private static async Task<int> ReadFileAsync(string filePath)
        {
            Console.WriteLine("Entered ReadFileAsync...");
            var bytesRead = 0;
            try
            {
                using (var fileStream = File.OpenRead(filePath))
                {
                    var readBuffer = new Byte[fileStream.Length];
                    bytesRead = await fileStream.ReadAsync(readBuffer, 0, (int)fileStream.Length);
                    // Control should return to caller here...until ReadAsync is done...
                    // The following lines are a continuation...after the await above
                    Console.WriteLine("Read {0} bytes successfully from file {1}", bytesRead, filePath);
                    return bytesRead;

                    // Using await replaces using a continuation like the following
                    //fileStream.ReadAsync(readBuffer, 0, (int) fileStream.Length).ContinueWith(task =>
                    //{
                    //    bytesRead = task.Result;
                    //    Console.WriteLine("Read {0} bytes successfully from file {1}", bytesRead, filePath);
                    //    return bytesRead;
                    //});
                 
                   
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Exception occurred while reading file {0}.", filePath);

                return bytesRead;
            }
        }
    }
}
