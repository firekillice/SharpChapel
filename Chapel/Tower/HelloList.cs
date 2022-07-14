using System.Collections;

namespace Tower
{
    public sealed class HelloReadOnlyAnimalList : IReadOnlyList<Animal>
    {
        private List<Animal> _animals;

        public HelloReadOnlyAnimalList(List<Animal> list)
        {
            _animals = list;
        }

        public Animal this[int index] => _animals[index];

        Animal IReadOnlyList<Animal>.this[int index] => _animals[index];

        public int Count => _animals.Count;

        public IEnumerator<Animal> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<Animal> IEnumerable<Animal>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public sealed class AnimalListEnumerator : IEnumerator<Animal>
    {
        private HelloReadOnlyAnimalList _list;
        private int _index;
        private Animal _current;

        public AnimalListEnumerator(HelloReadOnlyAnimalList list)
        {
            _list = list;
        }

        public Animal Current => _current;

        object IEnumerator.Current => _current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (++_index >= _list.Count)
            {
                return false;
            }
            else
            {
                _current = _list[_index];
                return true;
            }
        }

        public void Reset()
        {
            _index = -1;
            _current = default;
        }
    }


    public sealed class HelloReadOnlyList<T> : IReadOnlyList<T>
    {
        private readonly T[] _list;
        public HelloReadOnlyList(T[] list)
        {
            _list = list;
        }
        public T this[int index] => _list[index];

        public int Count => _list.Length;

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    public sealed class HelloReadOnlyListEnumerator<T> : IEnumerator<T>
    {
        private readonly HelloReadOnlyList<T> _list;
        private int _index;
        private T _current;

        HelloReadOnlyListEnumerator(HelloReadOnlyList<T> list)
        {
            _list = list;
        }

        public T Current => _list[_index];

        object IEnumerator.Current => _current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (++_index >= _list.Count)
            {
                return false;
            }
            else
            {
                _current = _list[_index];
                return true;
            }
        }

        public void Reset()
        {
            _index = -1;
            _current = default;
        }
    }


    public static class HelloList
    {
        public static void FirstView()
        {
            List<Animal> animalList = new List<Animal>();
            animalList.Add(new Animal(1, 32));
            animalList.Add(new Animal(1, 33));
            Animal[] animals = Array.Empty<Animal>();

            var readOnlyAnimalList = new HelloReadOnlyAnimalList(animalList);
            Console.WriteLine(readOnlyAnimalList.Count);

            //new Animal[] { new Animal(1, 32), new Animal(1, 33), new Animal(1, 33)};
            HelloReadOnlyList<Animal> _animalReadOnlyList = new HelloReadOnlyList<Animal>(animals);
            Console.WriteLine(_animalReadOnlyList.Count);
        }
    }
}
