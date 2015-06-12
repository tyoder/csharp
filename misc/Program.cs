using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace misc
{
    class Program
    {
        static void Main(string[] args)
        {
            //var decimal1 = new decimal(25);
            //var decimal2 = new decimal(25.0);

            //Console.WriteLine(string.Compare(decimal1.ToString(), decimal2.ToString()) == 0);

            //Console.WriteLine(decimal1.ToString() + "  " + decimal2.ToString());

            //var number3 = "3";
            //var number3point0 = "3.0";
            //Console.WriteLine(string.Compare(number3, number3point0) == 0);

            //var number3Decimal = decimal.Parse(number3);
            //var number3point0Decimal = decimal.Parse(number3point0);

            //Console.WriteLine(decimal.Compare(number3Decimal, number3point0Decimal) == 0);

            testCompare();

            Console.Read();
        }


        static void testCompare()
        {
            String _nullString = null;
            String _nonNullString = "test";

            if (string.Compare(_nonNullString, _nullString, true) == 0)
                Console.WriteLine("equal");
            else
            {
                Console.WriteLine("not equal");
            }
        }
    }
}
