
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
       
        public int BuildNest()  { return 1; }

       

        public int Life()
        {
            throw new NotImplementedException();
        }
    }

    public class Cock 
    {
        public int Eat()
        {
            return this.Move();
        }
        internal int Move() { return 1; }
    }


    public sealed class Jick : Cock
    {
        public new int Eat()
        {
            var cock = new Cock(); 
            return cock.Move();
        }
    }

    
}
