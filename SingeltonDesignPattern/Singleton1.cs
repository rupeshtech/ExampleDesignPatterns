using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingeltonDesignPattern
{
    public sealed class Singleton1
    {
        private static readonly Singleton1 instance = new Singleton1();

        private Singleton1() { }

        public static Singleton1 Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
