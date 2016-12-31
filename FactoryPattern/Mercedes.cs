using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class Mercedes : Car
    {
        public override string AssembleCar()
        {
            return "Mercedes assembled";
        }
    }
}
