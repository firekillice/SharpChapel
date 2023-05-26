using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower.Async
{
    public class MyClosure
    {
        public void FirstView()
        {
            var closure = CreateClosure();
            closure();
        }

        private static Action CreateClosure()
        {
            int a = 5;
            void Closure() => Console.WriteLine(a);
            return Closure;
        }
    }
}
