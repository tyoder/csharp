using System;

namespace Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            var tuple = new Tuple<string, string[], int, int[]>(
                "perl",
                new string[] {"java", "c#"},
                1,
                new int[] {2,3});

            // pass tuple as an argument
            WriteTuple(tuple);
            Console.Read();
    }

        static void WriteTuple(Tuple<string, string[], int, int[]> myTuple)
        {
            Console.WriteLine(myTuple.Item1);
            foreach(string value in myTuple.Item2)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine(myTuple.Item3);
            foreach(int value in myTuple.Item4)
            {
                Console.WriteLine(value);
            }

        }
    }
}
