using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    internal static class Expression
    {
        public static void FirstViewQuery()
        {
            var scores = new[] { 1,2,3,4,5,6,7,8,9,10};
            IEnumerable<int> highScoresQuery =
                from score in scores
                where score > 5
                orderby score descending
                select score;
            Console.WriteLine(string.Join(" ", highScoresQuery));
        }

    }
}
