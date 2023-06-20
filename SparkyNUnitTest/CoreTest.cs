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
    public class CoreTest
    {
        private CoreCalculator coreCalculator;
        [SetUp]
        public void SetUp()
        {
            coreCalculator = new CoreCalculator();
        }

        [Test]
        public void GetGrade_ScoreMoreThan90AndAttendacePercentageMoreThan70_ReturnRankA()
        {
            coreCalculator.Score = 91;
            coreCalculator.AttendancePercentage = 71;
            var result = coreCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("A"));
        }
        [Test]
        public void GetGrade_ScoreMoreThan80AndAttendacePercentageMoreThan60_ReturnRankB()
        {
            coreCalculator.Score = 81;
            coreCalculator.AttendancePercentage = 61;
            var result = coreCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("B"));
        }
        [Test]
        public void GetGrade_ScoreMoreThan60AndAttendacePercentageMoreThan60_ReturnRankC()
        {
            coreCalculator.Score = 61;
            coreCalculator.AttendancePercentage = 61;
            var result = coreCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("C"));
        }
        [Test]
        public void GetGrade_ScoreMoreThan95AndAttendacePercentageMoreThan65_ReturnRankB()
        {
            coreCalculator.Score = 95;
            coreCalculator.AttendancePercentage = 65;
            var result = coreCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("B"));
        }
        [Test]
        [TestCase(95,55)]
        [TestCase(65,55)]
        [TestCase(50,90)]
        public void GetGrade_ScoreMoreThan90AndAttendacePercentageMoreThan70_ReturnRankF(int score, int attendence)
        {
            coreCalculator.Score = score;
            coreCalculator.AttendancePercentage = attendence;
            var result = coreCalculator.GetGrade();

            Assert.That(result, Is.EqualTo("F"));
        }

        [Test]
        [TestCase(95,90, ExpectedResult = "A")]
        [TestCase(85,90, ExpectedResult = "B")]
        [TestCase(65,90, ExpectedResult = "C")]
        [TestCase(95,65, ExpectedResult = "B")]
        [TestCase(95,55, ExpectedResult = "F")]
        [TestCase(65,55, ExpectedResult = "F")]
        [TestCase(50,55, ExpectedResult = "F")]
        public string GetGrade_Score_InputScoreAndAttendancePercentage_GetCorrectAddition(int score, int attendencePercentage)
        {
            coreCalculator.Score = score;
            coreCalculator.AttendancePercentage = attendencePercentage;

            var result = coreCalculator.GetGrade();

            return result;
        }
    }
}
