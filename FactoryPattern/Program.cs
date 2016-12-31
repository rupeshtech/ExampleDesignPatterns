using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var creator = new CarCreator();

            // get Mercedes
            var mercedes=creator.CreateCar("Mercedes");
            Console.WriteLine(mercedes.AssembleCar());

            // get BMW
            var bmw = creator.CreateCar("BMW");
            Console.WriteLine(bmw.AssembleCar());

            // get OtherCar
            var other = creator.CreateCar("Other");
            Console.WriteLine(other.AssembleCar());

            Console.ReadLine();
        }
    }

}
