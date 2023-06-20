using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ICustomer
    {
        string MyString { get; set; }
        int GetTotalBill { get; set; }
        bool IsPlatinum { get; set; }
        void CompoundString(string firstName, string lastName);
        CustomerType GetCustomer();


    }
    public class Customer : ICustomer
    {
        public string MyString { get; set; }
        public int GetTotalBill { get; set; }
        public bool IsPlatinum { get; set; }

        public Customer()
        {
            IsPlatinum = true;
        }
        public void CompoundString(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Empty firstName");
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Empty lastName");
            }

            MyString = $"Hello, {firstName} {lastName}";
        }

        public CustomerType GetCustomer()
        {
            if (GetTotalBill < 100)
            {
                return new BasicCustomer();
            }
            return new PlatinumCustomer();
        }
    }


    public class CustomerType { };
    public class BasicCustomer: CustomerType { };
    public class PlatinumCustomer: CustomerType { };
}
