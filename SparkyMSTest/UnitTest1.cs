

using Sparky;

namespace SparkyMSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddNumbers_TwoInputInt_CorrectAddition()
        {
            //Arrange 
            Calculator calc = new Calculator();


            //Act
            var result = calc.AddNumbers(10, 20);

            
            //Assert
            Assert.AreEqual(30, result);
            
        }
    }
}