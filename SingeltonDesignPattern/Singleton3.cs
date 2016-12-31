using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingeltonDesignPattern
{
    public sealed class Singleton3
    {
        private static volatile Singleton3 instance;
        private static object _lock;

        private Singleton3()
        {
            
        }

        public static Singleton3 Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                        instance = new Singleton3();
                    }
                }
                return instance;
            }

        }
    }
}
