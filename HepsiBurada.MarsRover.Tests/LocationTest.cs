using HepsiBurada.MarsRover.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada.MarsRover.Tests
{
    [TestFixture]
    public class LocationTest
    {
        [Test]
        [TestCase(null, 5, 5, false, Category = "Null Input.")]
        [TestCase("", 5, 5, false, Category = "Empty Input.")]
        [TestCase(" ", 5, 5, false, Category = "Space Input.")]
        [TestCase("\n", 5, 5, false, Category = "Escape character Input.")]
        [TestCase("*", 5, 5, false, Category = "Special Character Input.")]
        [TestCase("5", 5, 5, false, Category = "Numeric Input.")]
        [TestCase("a", 5, 5, false, Category = "String Input.")]
        [TestCase("5 5", 5, 5, false, Category = "Plateau like Input.")]
        [TestCase("LLRMLRMMRL", 5, 5, false, Category = "Action like Input.")]
        [TestCase("1 2 n", 5, 5, false, Category = "Lowercase Input.")]
        [TestCase("1 2 N", 5, 5, true, Category = "Valid Input.")]
        [TestCase("1 2 N", 0, 5, false, Category = "Valid Input with x=0.")]
        [TestCase("1 2 N", 5, 0, false, Category = "Valid Input with y=0.")]
        [TestCase("1 2 N", 0, 0, false, Category = "Valid Input with x=0, y=0.")]
        [TestCase("1 2 N", -10, -10, false, Category = "Negative Input.")]
        public void IsValidTests(string input, int maxRowNo, int maxColumnNo, bool expected)
        {
            var result = new Location().IsValid(input, maxRowNo, maxColumnNo);
            Assert.AreEqual(expected, result);
        }

        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(new Actions("L"), new Plateau("5 5"), new Location("1 2 N"), new Location("1 2 W"));
                yield return new TestCaseData(new Actions("R"), new Plateau("5 5"), new Location("1 2 N"), new Location("1 2 E"));
                yield return new TestCaseData(new Actions("M"), new Plateau("5 5"), new Location("1 2 N"), new Location("1 3 N"));
                yield return new TestCaseData(new Actions("LL"), new Plateau("5 5"), new Location("1 2 N"), new Location("1 2 S"));
                yield return new TestCaseData(new Actions("RR"), new Plateau("5 5"), new Location("1 2 N"), new Location("1 2 S"));
                yield return new TestCaseData(new Actions("MM"), new Plateau("5 5"), new Location("1 2 N"), new Location("1 4 N"));
                yield return new TestCaseData(new Actions("LR"), new Plateau("5 5"), new Location("1 2 N"), new Location("1 2 N"));
                yield return new TestCaseData(new Actions("RM"), new Plateau("5 5"), new Location("1 2 N"), new Location("2 2 E"));
                yield return new TestCaseData(new Actions("ML"), new Plateau("5 5"), new Location("1 2 N"), new Location("1 3 W"));
                yield return new TestCaseData(new Actions("RML"), new Plateau("5 5"), new Location("1 2 N"), new Location("2 2 N"));
                yield return new TestCaseData(new Actions("RMLMRMLMRMLM"), new Plateau("5 5"), new Location("1 2 N"), new Location("4 5 N"));
                yield return new TestCaseData(new Actions("MMMMMMMMMMMMMM"), new Plateau("5 5"), new Location("1 2 N"), new Location("1 5 N"));
                yield return new TestCaseData(new Actions("RMMMMMMMMMMMMMM"), new Plateau("5 5"), new Location("1 2 N"), new Location("5 2 E"));
            }
        }


        [Test]
        [TestCaseSource("TestCases")]
        public void UpdateTests(Actions actions, Plateau plateau,Location current, Location expected)
        { 
            current.Update(actions, plateau);
            Assert.AreEqual (expected.RowNo, current.RowNo);
            Assert.AreEqual (expected.ColumnNo, current.ColumnNo);
            Assert.AreEqual (expected.Heading, current.Heading);
        }
    }
}
