namespace Tower
{
    public static class AnimalExtension
    {
        public static void AddVolume(this IAnimal animal, int v)
        {
            Console.WriteLine(animal.ToString());
        }

        public static void AddVolume(this Animal animal, int v)
        {
            Console.WriteLine(animal.ToString());
        }
    }
}
