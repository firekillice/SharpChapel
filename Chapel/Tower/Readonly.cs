namespace Tower
{
    public class ReadonlyList
    {
        private readonly List<int> _list;

        public ReadonlyList()
        {
            _list = new List<int>();
        }

        public void Add(int value)
        {
            _list.Add(value);
        }

        public void Remove(int value)
        {
            _list.Remove(value);
        }
    }
}
