using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    internal static class Iterator
    {
        private static List<int> _list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        public static void FirstView()
        {
            foreach (int number in MultiNumber())
            {
                Console.Write(number.ToString() + " ");
            }

            System.Collections.IEnumerable _listEnumerator = _list;
            foreach (int number in _listEnumerator)
            {
                Console.Write(number.ToString() + " ");
            }
        }

        public static System.Collections.IEnumerable MultiNumber()
        {
            yield return 3;
            yield return 5;
            yield return 8;
            yield break;
            yield return 13;
        }
    }
}
