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
    public class BankAccountTest
    {
        private BankAccount bankAccount;
        [SetUp]
        public void SetUp()
        {
        }
        //[Test]
        //public void BankAccount_InputDeposit100_ReturnTrue()
        //{
        //    BankAccount account = new BankAccount(new LogFakker());

        //    bool result = account.Deposit(100);
        //    Assert.IsTrue(result);
        //    Assert.That(result, Is.True);
        //    Assert.That(account.GetBalance(), Is.EqualTo(100));
        //}
        [Test]
        public void BankAccount_InputDeposit100WithMoq_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup((x) => x.Message(""));

            BankAccount account = new BankAccount(logMock.Object);

            bool result = account.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(result, Is.True);
            Assert.That(account.GetBalance(), Is.EqualTo(100));
        }

        [Test]
        [TestCase(200, 100)]
        [TestCase(200, 150)]
        public void BankWithDraws_Withdraws100WithBalance200_ReturnsTrue(int balance, int amount)
        {
            var logMock = new Mock<ILogBook>();

            logMock.Setup(c => c.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(c => c.LogBalanceAfterWithdrawal(It.Is<int>(c => c > 0))).Returns(true);

            BankAccount bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.WithDraws(amount); 
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(200, 300)]
        [TestCase(300, 450)]
        public void BankWithDraws_Withdraws100WithBalance200_ReturnsFalse(int balance, int amount)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(c => c.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(c => c.LogBalanceAfterWithdrawal(It.Is<int>(c => c > 0))).Returns(true);
            logMock.Setup(c => c.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);


            BankAccount bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(balance);
            var result = bankAccount.WithDraws(amount);

            Assert.IsFalse(result);
        }

        [Test]
        public void BankLogDummy_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();

            string result = "hello";

            logMock.Setup(c => c.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());

            Assert.That(logMock.Object.MessageWithReturnStr("Hello"), Is.EqualTo(result));
        }

        [Test]
        public void LogWithOutputResult_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOuput = "Hello";
            logMock.Setup(c => c.LogWithOutputResult(It.IsAny<string>(), out desiredOuput)).Returns(true);
            string result = "";

            Assert.That(logMock.Object.LogWithOutputResult("Linh", out result), Is.EqualTo(true));
            Assert.That(result, Is.EqualTo(desiredOuput));
        }

        [Test]
        public void BankLogDummy_LogRefChecker_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();

            Customer customer = new Customer();
            Customer customerNotUsed = new Customer();

            logMock.Setup(c => c.LogWithRefResult(ref customer)).Returns(true);

            Assert.That(logMock.Object.LogWithRefResult(ref customer), Is.EqualTo(true));
        }

        [Test]
        public void BankLogDummy_LogProperty_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.SetupAllProperties();

            logMock.Setup(c => c.LogSeverity).Returns(10);
            logMock.Setup(c => c.LogType).Returns("hello");

            Assert.Multiple(() =>
            {
                Assert.That(logMock.Object.LogSeverity, Is.EqualTo(10));
                Assert.That(logMock.Object.LogType, Is.EqualTo("hello"));
            });

            string result = "";

            logMock.Setup(c => c.LogToDb(It.IsAny<string>()))
                .Returns(true)
                .Callback((string str) => result += str);

            logMock.Object.LogToDb("Hello");
            Assert.That(result, Is.EqualTo("Hello"));

            int number = 0;

            logMock.Setup(c => c.LogToDb(It.IsAny<string>()))
                .Returns(true)
                .Callback(() =>  number++);

            logMock.Object.LogToDb("");
            logMock.Object.LogToDb("");

            Assert.That(number, Is.EqualTo(2));
        }
        //Kiểm tra hàm trong hàm thì những chức năng trong hàm chạy bao nhiu 
        //Hoàn thành xong, đọc lại toàn bộ code. Ngày mai code lại (CHỉ code lại test)
        [Test]
        public void BankLogDummy_CheckNumberOfFunction_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();

            BankAccount bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(100);

            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));

            logMock.Verify(c => c.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(c => c.Message("Test"), Times.AtLeastOnce());
            logMock.VerifySet(c => c.LogSeverity = 101, Times.Once);
            logMock.VerifyGet(c => c.LogSeverity, Times.Exactly(1));

        }

    }
}
