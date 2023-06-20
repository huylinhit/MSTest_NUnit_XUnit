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
    public class FiboTest
    {
        private FiboCalculator fiboCalculator;
        [SetUp]
        public void SetUp()
        {
            fiboCalculator = new FiboCalculator();
        }

        [Test]
        public void GetFiboSeries_InputRange1_GetCorrectAddition()
        {
            fiboCalculator.Range = 1;

            List<int> result = fiboCalculator.GetFiboSeries();

            List<int> expected = new List<int> { 0 };

            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.Ordered);
            Assert.That(result, Does.Contain(0));
            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void GetFiboSeries_InputRange6_GetCorrectAddition()
        {
            fiboCalculator.Range = 6;

            List<int> result = fiboCalculator.GetFiboSeries();

            List<int> expected = new List<int>() { 0, 1, 1, 2, 3, 5 };

            Assert.That(result, Does.Contain(3));
            Assert.That(result.Count(), Is.EqualTo(6));
            Assert.That(result, Has.No.Contain(4));
            Assert.That(result, Is.EquivalentTo(expected));
        }
    }
}
