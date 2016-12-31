using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    /// <summary>
    /// OtherCar
    /// </summary>
    public class OtherCar : Car
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>String Other Car</returns>
        public override string AssembleCar()
        {
            return "Other Car is assembled";
        }
    }
}
