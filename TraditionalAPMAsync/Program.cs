using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraditionalAPMAsync
{
    /// <summary>
    /// http://www.infoq.com/articles/Tasks-Async-Await
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // First Method
            /*byte[] readBuffer;
            var fs = File.OpenRead("lipsum.txt");
            readBuffer = new byte[fs.Length];
            var result = fs.BeginRead(readBuffer, 0, (int)fs.Length, OnReadComplete, fs);*/

            // Second Method
            byte[] readBuffer;
            var fs = File.OpenRead("lipsum.txt");
            readBuffer = new byte[fs.Length];
            var result = fs.BeginRead(readBuffer, 0, (int) fs.Length, asyncResult =>
            {
                var bytesRead = fs.EndRead(asyncResult);
                Console.WriteLine("Read {0} bytes successfully.", bytesRead);
                fs.Dispose();
            }, null);
            

            // do other work

            Console.ReadLine();
        }

        private static void OnReadComplete(IAsyncResult result)
        {
            var stream = (FileStream) result.AsyncState;
            var bytesRead = stream.EndRead(result);
            Console.WriteLine("Read {0} bytes successfully.", bytesRead);
            stream.Dispose();
        }
    }
}
