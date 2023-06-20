using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ILogBook
    {
        public int LogSeverity { get; set; }
        public string  LogType { get; set; }
        void Message(string message);

        bool LogToDb(string message);
        bool LogBalanceAfterWithdrawal(int afterWidthdrawal);

        string MessageWithReturnStr(string str);

        bool LogWithOutputResult(string str, out string outputStr);

        bool LogWithRefResult(ref Customer customer);
    }
    public class LogBook : ILogBook
    {
        public int LogSeverity { get; set; }
        public string LogType { get; set; }

        public bool LogBalanceAfterWithdrawal(int afterWidthdrawal)
        {
            if (afterWidthdrawal < 0)
            {
                Console.WriteLine("Failure");
                return false;
            }
            Console.WriteLine("Sucess");
            return true;
        }

        public bool LogToDb(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public bool LogWithOutputResult(string str, out string outputStr)
        {
            outputStr = "Hello " + str;
            return true;
        }

        public bool LogWithRefResult(ref Customer customer)
        {
            return true;
        }

        public string MessageWithReturnStr(string str)
        {
            Console.WriteLine(str);
            return str.ToLower();
        }

        void ILogBook.Message(string message)
        {
            Console.WriteLine(message);
        }
    }
    //public class LogFakker : ILogBook
    //{
    //    void ILogBook.Message(string message)
    //    {
    //    }
    //}
}
