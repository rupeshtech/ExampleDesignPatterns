using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var factoryCreator = new FactoryCreator();

            //Create Car Factory
            var carFactory = factoryCreator.CreateFactory("Car");
            Console.WriteLine($"Created facory is {carFactory.GetType().Name}");
            var carCreator = carFactory.CreateVehicleCreator();

            // Assemble Mercedes
            var mercedes = carCreator.CreateVehicle("Mercedes");
            Console.WriteLine(mercedes.AssembleVehicle());

            // Assemble BMW
            var bmw = carCreator.CreateVehicle("BMW");
            Console.WriteLine(bmw.AssembleVehicle());

            // Assemble otherCar
            var otherCar = carCreator.CreateVehicle("Other");
            Console.WriteLine(otherCar.AssembleVehicle());


            // Creat Scooter Factory
            var scooterFactory = factoryCreator.CreateFactory("Scooter");
            Console.WriteLine($"Factory Created is {scooterFactory.GetType().Name}");
            var scooterCreator = scooterFactory.CreateVehicleCreator();

            // Assemble Scooter A
            var sccoterA = scooterCreator.CreateVehicle("ScooterA");
            Console.WriteLine(sccoterA.AssembleVehicle());

            // Assemble Scooter A
            var sccoterB = scooterCreator.CreateVehicle("ScooterB");
            Console.WriteLine(sccoterB .AssembleVehicle());

            // Assemble Scooter A
            var otherScooter = scooterCreator.CreateVehicle("Other");
            Console.WriteLine(otherScooter.AssembleVehicle());

            Console.ReadLine();
        }
    }

    public class FactoryCreator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeOfVehicle"></param>
        /// <returns></returns>
        public IFactory CreateFactory(string typeOfVehicle)
        {
            if (typeOfVehicle=="Car")
                return new CarFactory();
            else
                return new ScooterFactory();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ScooterFactory:IFactory
    {
    
        public IVehicleCreator CreateVehicleCreator()
        {
            return new ScooterCreator();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class CarFactory : IFactory
    {
        public IVehicleCreator CreateVehicleCreator()
        {
            return  new CarCreator();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface  IFactory
    {
        IVehicleCreator CreateVehicleCreator();
    }

    public  interface IVehicleCreator
    {
        IVehicle CreateVehicle(string vehilceType);
    }

    public interface IVehicle
    {
        string AssembleVehicle();
    }
    public class CarCreator:IVehicleCreator
    {
        public IVehicle CreateVehicle(string typeOfCar)
        {
            if (typeOfCar == "Mercedes")
                return new Mercedes();
            else if (typeOfCar == "BMW")
                return new BMW();
            else return new OtherCar();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public class BMW : Car,IVehicle
    {
        public string AssembleVehicle()
        {
            return "BMW assembled";
        }
    }

    /// <summary>
    /// Other Car
    /// </summary>
    public class OtherCar : Car,IVehicle
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string AssembleVehicle()
        {
            return "OtherCar assembled";
        }
    }

    /// <summary>
    /// Mercedes
    /// </summary>
    public class Mercedes : Car,IVehicle
    {
        public  string AssembleVehicle()
        {
            return "Mercedes assembled";
        }
    }

    /// <summary>
    /// Abstract class Car
    /// </summary>
    public abstract class Car
    {
    }

    /// <summary>
    /// ScooterCreator
    /// </summary>
    public class ScooterCreator:IVehicleCreator
    {
        public IVehicle CreateVehicle(string typeOfScooter)
        {
            if (typeOfScooter == "ScooterA")
                return new ScooterA();
            else if (typeOfScooter == "ScooterB")
                return new ScooterB();
            else return new OtherScooter();
        }
    }
    /// <summary>
    /// Other Scooter
    /// </summary>
    public class OtherScooter : Scooter,IVehicle
    {
        public string AssembleVehicle()
        {
            return "OtherScooter assembled";
        }
    }

    /// <summary>
    /// ScooterB
    /// </summary>
    public class ScooterB : Scooter,IVehicle
    {
        public string AssembleVehicle()
        {
            return "ScooterB assembled";
        }
    }

    /// <summary>
    /// ScooterA
    /// </summary>
    public class ScooterA : Scooter,IVehicle
    {
        public  string AssembleVehicle()
        {
            return "ScooterA assembled";
        }
    }
    /// <summary>
    /// abstarct class Scooter
    /// </summary>
    public abstract class Scooter
    {
    }
}
