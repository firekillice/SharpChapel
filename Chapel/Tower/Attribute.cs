using System.ComponentModel.DataAnnotations;

namespace Tower
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class AnimalAttrbute : Attribute
    {
        public string Name { get; set; }
        public int Level { get; set; }

        public AnimalAttrbute(string name, int level)
        {
            Name = name;
            Level = level;
        }
    }

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class IsEmptyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var inputValue = value as string;
            return !string.IsNullOrEmpty(inputValue);
        }
    }

    [AttributeUsage(AttributeTargets.All)]
    public class CustomAttribute : Attribute
    {
        // Provides name of the member
        private string name;

        // Provides description of the member
        private string action;

        // Constructor
        public CustomAttribute(string name, string action)
        {
            this.name = name;
            this.action = action;
        }

        // property to get name
        public string Name
        {
            get { return name; }
        }

        // property to get description
        public string Action
        {
            get { return action; }
        }
    }

    [CustomAttribute("Modifier", "Assigns the Student Details")]
    class Student
    {
        // Private fields of class Student
        private int rollNo;

        [StringLength(50, MinimumLength = 10, ErrorMessage = "Name length limit.")]
        private string stuName;

        private double marks;

        // The attribute MyAttribute is applied 
        // to methods of class Student
        // Providing details of their utility
        [CustomAttribute("Modifier", "Assigns the Student Details")]
        public void setDetails(int r, string sn, double m)
        {
            rollNo = r;
            stuName = sn;
            marks = m;
        }

        [CustomAttribute("Accessor", "Returns Value of rollNo")]
        public int getRollNo()
        {
            return rollNo;
        }


        [CustomAttribute("Accessor", "Returns Value of stuName")]
        public string getStuName()
        {
            return stuName;
        }

        [CustomAttribute("Accessor", "Returns Value of marks")]
        public double getMarks()
        {
            return marks;
        }
    }

    public class TestAttributes
    {
        // Main Method
        public static void TestAttribute()
        {
            Student s = new Student();
            s.setDetails(1, "Taylor", 92.5);

            System.Attribute[] customAttrs = System.Attribute.GetCustomAttributes(typeof(Student));

            foreach (System.Attribute attr in customAttrs)
            {
                if (attr is CustomAttribute)
                {
                    CustomAttribute a = (CustomAttribute)attr;
                }
            }

            var memberInfos = typeof(Student).GetMethods();

            for (int i = 0; i < memberInfos.Length; i++)
            {
                CustomAttribute? att = (CustomAttribute)Attribute.GetCustomAttribute(memberInfos[i], typeof(CustomAttribute));
                if (att == null)
                {
                    Console.WriteLine("No attribute in member function {0}.\n", memberInfos[i].ToString());
                }
                else
                {
                    Console.WriteLine("The Name Attribute for the {0} member is: {1}.", memberInfos[i].ToString(), att.Name);
                }
            }

            Console.ReadKey();
        }
    }
}
