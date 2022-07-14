using Microsoft.CodeAnalysis;
using System;
using System.Linq.Expressions;
using System.Reflection.Emit;

namespace MyNamespace
{
    public class Entrance
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine(MyNamespace.SnippetClass.Add(1, 2));
            //Console.WriteLine("333");
        }

        public static void DynamicExpression()
        {
            var pa = Expression.Parameter(typeof(int), "a");
            var pb = Expression.Parameter(typeof(int), "b");
            var ae = Expression.Add(pa, pb);
            var fe = (Func<int, int, int>)Expression.Lambda(ae, pa, pb).Compile();
            Console.WriteLine(fe(1, 2));
        }

        public static void DynamicMethodCase()
        {
            var dm = new DynamicMethod("Add", typeof(int), new[] { typeof(int), typeof(int) });
            var g = dm.GetILGenerator();
            g.Emit(OpCodes.Ldarg_0);
            g.Emit(OpCodes.Ldarg_1);
            g.Emit(OpCodes.Add);
            g.Emit(OpCodes.Ret);
            var f = (Func<int, int, int>)dm.CreateDelegate(typeof(Func<int, int, int>));
            Console.WriteLine(f(1, 2));
        }
    }
}