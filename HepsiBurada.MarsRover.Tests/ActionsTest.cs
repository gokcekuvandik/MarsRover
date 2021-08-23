using HepsiBurada.MarsRover.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada.MarsRover.Tests
{
    [TestFixture]
    public class ActionsTest
    {
        [Test]
        [TestCase(null, false, Category = "Null Input.")]
        [TestCase("", false, Category = "Empty Input.")]
        [TestCase(" ", false, Category = "Space Input.")]
        [TestCase("\n", false, Category = "Escape character Input.")]
        [TestCase("*", false, Category = "Special Character Input.")]
        [TestCase("5", false, Category = "Numeric Input.")]
        [TestCase("a", false, Category = "String Input.")]
        [TestCase("aB65+", false, Category = "Random Input.")]
        [TestCase("5 5", false, Category = "Plateau like Input.")]
        [TestCase("1 2 N", false, Category = "Location like Input.")]
        [TestCase("lrm", false, Category = "Lowercase Input.")]
        [TestCase("LLRMLRMMRL", true, Category = "Valid Input.")]

        public void IsValidTests(string input, bool expected)
        {
            var result = new Actions().IsValid(input);
            Assert.AreEqual(expected, result);
        }
    }
}
