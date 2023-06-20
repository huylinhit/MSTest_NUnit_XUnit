using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class BankAccount
    {
        private readonly ILogBook _logBook;

        public int Balance { get; set; }
        public BankAccount(ILogBook logBook)
        {
            Balance = 0;
            _logBook = logBook ?? throw new ArgumentNullException(nameof(logBook));
        }

        public bool Deposit(int amount)
        {
            _logBook.Message("Deposit invoked");
            _logBook.Message("Test");
            _logBook.LogSeverity = 101;

            var temp = _logBook.LogSeverity;
            Balance += amount;
            return true;
        }

        public bool WithDraws(int  amount)
        {
            _logBook.Message($"Withdraws {amount}");
            if (Balance >= amount)
            {
                _logBook.LogToDb("Widthdraws Amount: " + amount.ToString());
                Balance -= amount;
                return true;
            }
            _logBook.LogBalanceAfterWithdrawal(Balance - amount);
            return false;
        }

        public int GetBalance()
        {
            return Balance;
        }
    }
}
