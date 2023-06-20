using Moq;
using NUnit.Framework;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class ProductTest
    {
        [Test]
        public void GetPrice_InputPrice100_ReturnTrue()
        {
            Product product = new Product();

            product.Price = 100;

            var result = product.GetPrice(new Customer { IsPlatinum = true });

            Assert.That(result, Is.EqualTo(80));
        }

        [Test]
        public void GetPrice_IsPlatinum_ReturnTrue()
        {
            Product product = new Product();
            product.Price = 100;


            var mock = new Mock<ICustomer>();
            mock.Setup(c => c.IsPlatinum).Returns(true);

            var result = product.GetPrice(mock.Object);

            Assert.That(result, Is.EqualTo(80));
        }
    }
}
