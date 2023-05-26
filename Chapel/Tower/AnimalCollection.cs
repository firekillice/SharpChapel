using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Tower
{
    public class Animal : IEquatable<Animal>
    {
        public delegate int MessageDelegate<T>(T m, long num);
        public delegate void AnotherMessageDelegate(int m, long num);
        
        public readonly int b2 = 30 + 30;
        const int b3 = 50 + 50;
        const string b4 = "50" + "50";
        const string b5 = $"{b4}";

        [IsEmpty(ErrorMessage = "Name should not be null or empty.")]
        [DataType(DataType.Time, ErrorMessage = "Should be datatype Time.")]
        [StringLength(50, MinimumLength = 10, ErrorMessage = "Name length limit.")]
        public string Name { get; set; }

        [Required]
        public int Volume { get; set; }

        public int Life { get; set; }

        public Animal(int volume, int life)
        {
            this.Volume = volume;
            this.Life = life;
            b2 = 40;
        }
        public Animal(int volume, int life, string name )
        {
            this.Volume = volume;
            this.Life = life;
            Name = name;
            b2 = 40;
        }
        public Animal(int volume, int life, int other)
        {
            this.Volume = volume;
            this.Life = life;
            b2 = 50;
        }

        public Animal()
        {
            
        }

        [AnimalAttrbute("chick", 30, Name = "chick", Level = 40)]
        internal void AddLife(int life)
        {
            Life += life;
        }

        public void SetVolume(int v)
        {
            this.Volume = v;
        }

        public bool Equals(Animal? other)
        {
            return this.Volume == other.Volume && this.Life == other.Life;
        }

        public static void Add<T>(T b)
        {
            var _c = new List<T>();
            _c.Add(b);
        }

        public void View(Action<int> action)
        {
            action(Volume);
        }

        public void AnimalDelegate(int m, float num)
        {
            Console.WriteLine(m);
            this.AddLife(m);
        }

        public static void AnimalDelegate(int m, long num)
        {
            Console.WriteLine(m);
        }

        public static int AnimalDelegate(int m, int num)
        {
            Console.WriteLine(m);
            return 1;
        }

        public void DelegateEntrance(AnotherMessageDelegate func)
        {
            
        }
    }

    public class AnimalCollection : ICollection<Animal>
    {
        private List<Animal>? InnerCol;

        public int Count => InnerCol.Count;

        public bool IsReadOnly => false;

       public AnimalCollection()
        {
            InnerCol = new List<Animal>(); 
        }

        public void Add(Animal item)
        {
            InnerCol.Add(item);
        }

        public void Clear()
        {
            InnerCol.Clear();
        }

        public bool Contains(Animal item)
        {
            var count = InnerCol.Count;
            for (int i = 0; i < count; i++)
            {
                if (InnerCol[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public void CopyTo(Animal[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("The array cannot be null.");
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("The starting array index cannot be negative.");
            if (Count > array.Length - arrayIndex + 1)
                throw new ArgumentException("The destination array has fewer elements than the collection.");

            for (int i = 0; i < InnerCol.Count; i++)
            {
                array[i + arrayIndex] = InnerCol[i];
            }
        }

        public IEnumerator<Animal> GetEnumerator()
        {
            return new AnimalEnumerator(this);
        }

        public Animal this[int index]
        {
            get { return (Animal)InnerCol[index]; }
            set { InnerCol[index] = value; }
        }

        public bool Remove(Animal item)
        {
            bool result = false;
            for (int i = 0; i < InnerCol.Count; i++)
            {
                Animal animal = (Animal)InnerCol[i];
                animal.AddLife(30);
                if (animal.Equals(item))
                {
                    InnerCol.RemoveAt(i);
                    result = true;
                    break;
                }
            }
            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new AnimalEnumerator(this);
        }
    }

    public class AnimalEnumerator : IEnumerator<Animal>
    {
        private AnimalCollection _collection;
        private int _curIndex;
        private Animal? _animal;

        public Animal Current => _animal;

        object IEnumerator.Current => _animal;

        public AnimalEnumerator(AnimalCollection collection)
        {
            _collection = collection;
            _curIndex = -1;
            _animal = default;
        }

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if (++_curIndex >= _collection.Count)
            {
                return false;
            }
            else
            {
                _animal = _collection[_curIndex];
                return true;
            }
        }

        public void Reset()
        {
            _curIndex = -1;
            _animal = default;
        }


    }
}
