using Set.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set
{
    class Program
    {
        static void Main(string[] args)
        {
            var set1 = new SimpleSet<int>(new int[] { 1, 2, 3, 4, 5 });
            var set2 = new SimpleSet<int>(new int[] { 4, 5, 6, 7, 8 });
            var set3 = new SimpleSet<int>(new int[] { 2, 3, 4});

            var resultSet = set1.Union(set2);

            Console.Write("Union A v B: ");

            foreach (int item in resultSet)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            Console.Write("Intersect A ^ B: ");

            resultSet = set1.Intersect(set2);

            foreach (int item in resultSet)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            Console.WriteLine("Difference A - B: ");

            resultSet = set1.Difference(set2);

            foreach (int item in resultSet)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            Console.WriteLine("SymmetricDifference A !| B");

            resultSet = set1.SymmetricDifference(set2);

            foreach (int item in resultSet)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();

            Console.Write("C Subset A: ");

            Console.WriteLine(set3.Subset(set1));

            Console.ReadLine();
        }
    }
}
