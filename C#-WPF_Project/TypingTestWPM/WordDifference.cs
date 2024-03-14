using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermProject
{
    class wordDifference
    {

        public static List<string> notInA;
        public static List<string> notInB;
        public static int Counter;

        public static void Difference(string a, string b)
        {
            var itemsA = a.Split(new[] { " ", ".", "," }, StringSplitOptions.RemoveEmptyEntries);
            var itemsB = b.Split(new[] { " ", ".", "," }, StringSplitOptions.RemoveEmptyEntries);

            var changedPairs =
                from x in itemsA
                from y in itemsB
                where (x.StartsWith(y) || y.StartsWith(x)) && y != x
                select new { x, y };

            var softChanged = changedPairs.SelectMany(p => new[] { p.x, p.y }).Distinct().ToList();

            notInA = itemsA.Except(itemsB).Except(softChanged).ToList();
            notInB = itemsB.Except(itemsA).Except(softChanged).ToList();

            Counter = notInA.Count + notInB.Count;

        }
    }
}
