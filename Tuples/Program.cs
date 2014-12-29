using System;
using System.Collections.Generic;
using System.Linq;

namespace Tuples
{
    /// <summary>
    /// A Tuple is a class, not a struct
    /// It is excellent as a short-term container.
    /// The properties of a Tuple (Item1, Item2, etc) do not have setters.
    /// Values of properties can only be set upon construction - they are immutable
    /// Reference:  http://www.dotnetperls.com/tuple
    /// </summary>
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

            // Tuple.Create
            var createdTuple = Tuple.Create("cat", 2, true);

            WriteCreatedTuple(createdTuple);

            //SortTupleList();

            SortTupleWithLinq();

            Console.Read();
        }

        static void WriteCreatedTuple(Tuple<string, int, bool> myCreatedTuple)
        {
            Console.WriteLine(myCreatedTuple.Item1);
            Console.WriteLine(myCreatedTuple.Item2);
            Console.WriteLine(myCreatedTuple.Item3);
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

        static void SortTupleList()
        {
            var tupleList = new List<Tuple<int, string>>();
            tupleList.Add(new Tuple<int, string>(1, "cat"));
            tupleList.Add(new Tuple<int, string>(100, "apple"));
            tupleList.Add(new Tuple<int, string>(2, "zebra"));

            // Use Sort method with Comparison delegate.
            tupleList.Sort((a,b) => a.Item2.CompareTo(b.Item2));

            foreach (var element in tupleList)
            {
                Console.WriteLine(element);
            }
            
        }

        static void SortTupleWithLinq()
        {
            var tupleList = new List<Tuple<int, string>>();
            tupleList.Add(new Tuple<int, string>(1, "cat"));
            tupleList.Add(new Tuple<int, string>(100, "apple"));
            tupleList.Add(new Tuple<int, string>(2, "zebra"));

            var tupleListSorted = from thing in tupleList
                orderby thing.Item1
                select thing;

            foreach (var tupleThing in tupleListSorted)
            {
                Console.WriteLine(tupleThing);
            }
        }
    }
}
