using HepsiBurada.MarsRover.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBurada.MarsRover.Tests
{
    [TestFixture]
    public class PlateauTest
    {
        [Test]
        [TestCase(null, false, Category = "Null Input.")]
        [TestCase("", false, Category = "Empty Input.")]
        [TestCase(" ", false, Category = "Space Input.")]
        [TestCase("\n", false, Category = "Escape character Input.")]
        [TestCase("*", false, Category = "Special Character Input.")]
        [TestCase("5", false, Category = "Numeric Input.")]
        [TestCase("5 5 5", false, Category = "Numeric Input.")]
        [TestCase("a", false, Category = "String Input.")]
        [TestCase("aB65+", false, Category = "Random Input.")]
        [TestCase("5 5", true, Category = "Valid Input.")]
        [TestCase("0 5", false, Category = "Valid Input.")]
        [TestCase("5 0", false, Category = "Valid Input.")]
        [TestCase("0 0", false, Category = "Valid Input.")]
        [TestCase("-10 -10", false, Category = "Valid Input.")]
        [TestCase("LLRMLRMMRL", false, Category = "Action like Input.")]
       
        public void IsValidTests(string input, bool expected)
        {
            var result = new Plateau().IsValid(input);
            Assert.AreEqual(expected, result);
        }
    }
}
