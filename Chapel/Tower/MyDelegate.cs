using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    public class MyDelegate
    {
        public void Test()
        {
            Action<float> outputLine = delegate { Console.WriteLine("MyDelegate testing"); };

            Action<float> outputLine2 = static x => { Console.WriteLine(x); };
            outputLine(3);

            A(delegate { });
        }

        public void A(Action<Task> action)
        {
            var t = Task.Run(() => { });
            action(t);
        }
    }
}

