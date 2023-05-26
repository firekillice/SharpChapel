using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tower
{
    internal static class LINQ
    {
        public static void Practice()
        {
            var scores = new[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var maximumSquare = scores.Max(x => x * x);
            Console.WriteLine(maximumSquare);

            var minSquare = scores.Select(x => x * x).Min();
            Console.WriteLine(minSquare);

            var students = new[] {
                new Student{ Score = 20, Age = 12 },
                new Student { Score = 30, Age = 13 },
                new Student { Score = 40, Age = 14 },
                new Student{ Score = 50, Age = 15 }};

            var maxBy = students.MaxBy(x => x.Age);
            Console.WriteLine($"{maxBy.Score} {maxBy.Age}");
        }

        private class Student
        {
            internal int Score { get; set; }
            internal int Age { get; set; }
        }
    }
}


