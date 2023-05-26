using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    internal class Interpolation
    {
        public void FirstView()
        {
            var d = 3;
            var interpolation = $"hello,{(d > 0 ? 6 : 3)}";
            var interpolation2 = $"hello,{ d + 3}";
            Console.WriteLine(interpolation + interpolation2);
        }
    }
}
