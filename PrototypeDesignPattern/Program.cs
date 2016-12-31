using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        { 
            Cat cat = new Cat();
            Cat cloneCat = (Cat)cat.CLone();
          
            Dog dog = new Dog();

            Dog cloneDog = (Dog)dog.CLone();

            Console.ReadLine();
        }
    }

    public interface Animal
    {
        Animal CLone();
    }

    public class Cat : Animal
    {
        public Animal CLone()
        {
            Cat cat = null;
            cat = (Cat) this.MemberwiseClone();
            return cat;
        }
    }
    public class  Dog:Animal
    {
        public Animal CLone()
        {
            Dog dog = null;
            dog = (Dog)this.MemberwiseClone();
            return dog;
        }
    }
}
