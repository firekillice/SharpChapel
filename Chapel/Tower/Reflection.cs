using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    public static class HelloReflection
    {
        public static void Firstview()
        {
            int i = 42;
            Type type = i.GetType();
            Console.WriteLine(type);

            Type rt = typeof(HelloReflection);
            Assembly info = typeof(HelloReflection).Assembly;
            Console.WriteLine(info);
        }

        public static void ViewExeTypes()
        {
            Assembly a = Assembly.LoadFrom("./Tower.dll");
            Type[] types = a.GetTypes();
            foreach (Type t in types)
            {
                Console.WriteLine(t.FullName);
            }
        }

        public static void ViewConstructor()
        {
            Type t = typeof(System.String);
            ConstructorInfo[] ci = t.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            foreach (MemberInfo m in ci)
            {
                Console.WriteLine("{0}{1}", "     ", m);
            }
            Console.WriteLine();
        }

        public static void ViewMembers()
        {
            Type at = typeof(Animal);
            MemberInfo[] myMemberInfoArray = at.GetMembers();
            foreach (MemberInfo m in myMemberInfoArray)
            {
                Console.WriteLine("{0}{1}", "     ", m);
            }
            Console.WriteLine();
        }
    }
}
