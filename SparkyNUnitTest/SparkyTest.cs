using NUnit.Framework;
using Sparky;
using System.Xml.Schema;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class SparkyTest
    {
        private Customer StringMethod { get; set; }
        private Calculator Calculator { get; set; }
        [SetUp]
        public void SetUp()
        {
            StringMethod = new Customer();
            Calculator = new Calculator();
        }

        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            var result = Calculator.AddNumbers(10, 20);

            Assert.AreEqual(30, result);
        }

        [Test]
        public void IsOddNumber_InputOneInt_GetCorrectAddition()
        {
            var result = Calculator.isOddNumber(9);

            //Assert.AreEqual(true, result);
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsOddNumber_InputEvenNumber_ReturnTrue()
        {

            bool isOdd = Calculator.isOddNumber(29);

            Assert.IsTrue(isOdd);
        }

        [Test]
        [TestCase(20)]
        [TestCase(10)]
        [TestCase(150)]
        [TestCase(1000000000)]
        public void IsOddNumber_InputEvenNumber_ReturnFalse(int a)
        {

            bool isOdd = Calculator.isOddNumber(a);

            Assert.IsFalse(isOdd);
        }

        [Test]
        [TestCase(11, ExpectedResult = true)]
        [TestCase(10, ExpectedResult = false)]
        public bool IsOddNumber_InputOddNumber_ReturnTrueIfOdd(int a)
        {

            bool isOdd = Calculator.isOddNumber(a);
            return isOdd;
        }

        [Test]
        [TestCase(5.4, 10.5)] //15.9
        [TestCase(5.43, 10.53)] //15.96
        [TestCase(5.49, 10.59)] //16.08
        public void AddDoubleNumbers_InputTwoDouble_GetCorrectAddition(double a, double b)
        {

           double total = Calculator.AddDoubleNumbers(a, b);

            Assert.AreEqual(15.9, total, .2);

        }

        [Test]
        [TestCase("Linh", "Huy")]
        public void CompoundString_InputTwoString_GetCorrectAddition(string firstname, string lastName)
        {

            StringMethod.CompoundString(firstname, lastName);

            Assert.Multiple(() =>
            {

                Assert.That(StringMethod.MyString, Is.EqualTo("Hello, Linh Huy"));
                Assert.That(StringMethod.MyString, Does.Contain("Hello, "));
                Assert.That(StringMethod.MyString, Does.Contain("hello, ").IgnoreCase);
                Assert.That(StringMethod.MyString, Does.StartWith("Hello, "));
                Assert.That(StringMethod.MyString, Does.EndWith("huy").IgnoreCase);
                Assert.That(StringMethod.MyString, Does.Match("[A-Z]{1}[a-z]+ [A-Z][a-z]"));
            });
        }

        [Test]
        public void CompounString_NotGreeted_ReturnNull()
        {
            Assert.IsNull(StringMethod.MyString);

        }

        [Test]
        public void GetRangeOfOddNumber_InputMinAndMaxInt_GetCorrectAddition()
        {
            var result = Calculator.GetRanngeOfOddNumber(5, 10);


            List<int> expectedValue = new List<int>
            {
                5, 7, 9
            };

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EquivalentTo(expectedValue));
                Assert.That(result, Does.Contain(5));
                Assert.That(result, Does.Not.Contain(8));
                Assert.That(result, Has.No.Contain(8));
                Assert.That(result.Count(), Is.EqualTo(3));
                Assert.That(result, Is.Ordered);
                Assert.That(result, Is.Unique);
                Assert.That(result, Is.Not.Empty);
                Assert.That(result, Has.No.Member(3));
            });

            

        }
        [Test]
        public void GetRangeOfOddNumber_DefaultMember_GetCorrectAddition()
        {
            var result = Calculator.Discount;

            var expectedValue = new List<int> { };

            Assert.That(result, Is.InRange(15, 25));
        }

        [Test]
        public void CompoundString_InputNullString_ReturnsExceptions()
        {
            var exceptionResult = Assert.Throws<ArgumentException>(()=> StringMethod.CompoundString("Linh", ""));

            Assert.AreEqual("Empty lastName", exceptionResult.Message);

            Assert.That(() => StringMethod.CompoundString("Linh", ""), Throws.ArgumentException.With.Message.EqualTo("Empty lastName"));

            Assert.AreEqual("Empty lastName", exceptionResult.Message);

            Assert.That(() => StringMethod.CompoundString("Linh", ""), Throws.ArgumentException);
        }

        [Test]
        public void GetCustomerType_InputBillIntEqual15_ReturnBasicCustomer()
        {
            StringMethod.GetTotalBill = 15;

            var result = StringMethod.GetCustomer();

            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }
        [Test]
        public void GetCustomerType_InputBillIntMoreThan100_ReturnBasicCustomer()
        {
            StringMethod.GetTotalBill = 101;

            var result = StringMethod.GetCustomer();

            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }   
}
