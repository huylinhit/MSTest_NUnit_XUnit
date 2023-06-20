using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }　
        public string Description { get; set; }

        public float GetPrice(ICustomer customer)
        {
            if (customer.IsPlatinum)
            {
                return (float)(Price * 0.8);
            }
            return Price;
        }   
    }
}
