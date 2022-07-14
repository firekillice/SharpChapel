
namespace Tower
{
    public interface IBeing
    {
        public int Volume { get; set; }
    }

    public interface IAnimal : IBeing
    {
        public int Life();
    }

    public interface IFlying
    {
        public int Fly();
    }

    public interface IBuildNest
    {
        public int BuildNest();
    }

    public interface IBird : IAnimal, IFlying, IBuildNest
    {
        
    }

    public abstract class Chick : IBird
    {
        public int Volume { set; get; }

        public virtual int Fly() { return 1; }
        public int Life() { return 1; }
       
        public int BuildNest()  { return 1; }

        public abstract int Eat();
    }

    public class Cock : Chick
    {
        public override int Eat()
        {
            throw new NotImplementedException();
        }
        public override int Fly() { return 1; }
    }

    public class Hen : Chick
    {
        public override int Eat()
        {
            throw new NotImplementedException();
        }
        public override int Fly() { return 1; }
    }
}
