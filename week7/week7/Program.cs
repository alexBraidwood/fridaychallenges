using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week7
{
    class Program
    {
        static void Main(string[] args)
        {
            Set s1 = new Set(new int[] { 1, 2, 1, 15, 45, 11, 14 });
            Set s2 = new Set(new List<int>() { 2, 45, 15, 26, 84, 23, 55, 98, 105, 32 });
            Set s3 = new Set(new int[] { 2, 1, 45, 15, 14, 11 });

            Set s1Copy = new Set(s1.Items);
            Set s1s2Union = Set.Union(s1, s2);
            Set s1s2Intersection = Set.Intersection(s1, s2);

            Console.WriteLine("\n\n\n-----Objects------");
            Console.WriteLine("s1: {0}", s1.ToString());
            Console.WriteLine("s2: {0}", s2.ToString());
            Console.WriteLine("s3: {0}", s3.ToString());
            Console.WriteLine("s1Copy: {0}", s1Copy.ToString());

            Console.WriteLine("\n\n\n-----Tests-----");
            Console.WriteLine("Equal Test 1 (false): {0}", Set.Equals(s1, s2));
            Console.WriteLine("Equal Test 2 (true): {0}", Set.Equals(s1, s3));
            Console.WriteLine("Contains Test 1 (false): {0}", s1.Contains(16));
            Console.WriteLine("Contains Test 2 (true): {0}", s2.Contains(105));
            Console.WriteLine("Union Test: {0}", s1s2Union.ToString());
            Console.WriteLine("Intersection Test: {0}", s1s2Intersection.ToString());
            
            Console.ReadKey();
        }
    }
}
