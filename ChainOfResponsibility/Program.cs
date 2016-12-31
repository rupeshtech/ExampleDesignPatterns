using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup Chain of Responsibility
            var h1 = new TeamLeader();
            var h2 = new Manager();
            var h3 = new Director();
            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);

            // Generate and process request
            int[] numberOfDaysRequested = { 2,7,4,12,8,5,3,14 };

            foreach (int numberOfDays in numberOfDaysRequested)
            {
                h1.ApproveLeave(numberOfDays);
            }
            Console.ReadLine();
        }
    }

    abstract class Handler
    {
        protected Handler successor;

        public void SetSuccessor(Handler successor)
        {
            this.successor = successor;
        }

        public abstract void ApproveLeave(int numberOfDays);
    }

    class TeamLeader : Handler
    {
        public override void ApproveLeave(int numberOfDays)
        {
            if (numberOfDays < 5)
            {
                Console.WriteLine($"{numberOfDays} leave approved by TeamLeader");
            }
            else if (successor != null)
            {
                successor.ApproveLeave(numberOfDays);
            }
        }
    }

    class Manager : Handler
    {
        public override void ApproveLeave(int numberOfDays)
        {
            if (numberOfDays >= 5 && numberOfDays <10)
            {
                Console.WriteLine($"{numberOfDays} leave approved by Manager");
            }
            else if (successor != null)
            {
                successor.ApproveLeave(numberOfDays);
            }
        }
    }

    class Director : Handler
    {
        public override void ApproveLeave(int numberOfDays)
        {
            if (numberOfDays >=10)
            {
                Console.WriteLine($"{numberOfDays} leave approved by Director");
            }
            else if (successor != null)
            {
                successor.ApproveLeave(numberOfDays);
            }
        }
    }
}