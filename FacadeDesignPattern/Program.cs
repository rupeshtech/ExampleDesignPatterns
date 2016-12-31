using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadeDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var facade = new BankFacade(12345678,1234);

            facade.WithdrawCash(50);
            facade.WithdrawCash(100);
            facade.DepositCash(50);

            Console.ReadLine();
        }
    }

    internal class BankFacade
    {
        private int _accountNumber;
        private int _pin;
        AccountNumberCheck accountNumberCheck;
        PinCheck pinCheck;
        FundCheck fundCheck;

        public BankFacade(int accountNumber, int pin)
        {
            this._accountNumber = accountNumber;
            this._pin = pin;
            accountNumberCheck = new AccountNumberCheck();
            pinCheck=new PinCheck();
            fundCheck=new FundCheck();
        }

        internal void DepositCash(int amount)
        {
            if (accountNumberCheck.IsAccountValid(_accountNumber) && pinCheck.IsPinValid(_pin))
            {
                fundCheck.MakeDeposit(amount);
                Console.WriteLine($"Transaction Complete");
            }
        }

        internal void WithdrawCash(int amount)
        {
            if(accountNumberCheck.IsAccountValid(_accountNumber)&&pinCheck.IsPinValid(_pin)&&fundCheck.HasEnoughFund(amount))
                Console.WriteLine($"Transaction Complete");
        }
    }

    public class AccountNumberCheck
    {
        public bool IsAccountValid(int accountNumber)
        {
            if (accountNumber == 12345678)
                return true;
            return false;
        }
    }

    public class PinCheck
    {
        public bool IsPinValid(int pinNumber)
        {
            if (pinNumber == 1234)
                return true;
            return false;
        }
    }

    public class FundCheck
    {
        private double _totalAmount = 1000;

        public double GetTotakAmount()
        {
            return _totalAmount;
        }
        public void IncreaseFund(double amountDeposited)
        {
            _totalAmount += amountDeposited;
        }
        public void DecreaseFund(double amountWithdrawn)
        {
            _totalAmount -= amountWithdrawn;
        }

        public bool HasEnoughFund(int amountToWithDraw)
        {
            if (_totalAmount < amountToWithDraw)
            {
                Console.WriteLine($"Withdraw Fail.Insufficient amount. Current balance is {_totalAmount}");
                return false;
            }
            else
            {
                DecreaseFund(amountToWithDraw);
                Console.WriteLine($"Withdraw complete. Current balance is {_totalAmount}");
                return true;
            }
        }

        public void MakeDeposit(int amountToDeposit)
        {
            IncreaseFund(amountToDeposit);
            Console.WriteLine($"Deposit complete. Current balance is {_totalAmount}");
        }
    }
}
