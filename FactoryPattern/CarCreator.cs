using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class CarCreator
    {
        public Car CreateCar(string typeOfCar)
        {
            if (typeOfCar == "Mercedes")
                return new Mercedes();
            else if (typeOfCar == "BMW")
                return new BMW();
            else return new OtherCar();
        }
    }
}
