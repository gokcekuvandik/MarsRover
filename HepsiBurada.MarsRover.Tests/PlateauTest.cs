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
        [TestCase("5", false, Category = "1 Numeric Input.")]
        [TestCase("5 5 5", false, Category = "3 Numeric Inputs.")]
        [TestCase("a", false, Category = "String Input.")]
        [TestCase("aB65+", false, Category = "Random Input.")]
        [TestCase("5 5", true, Category = "Valid Input.")]
        [TestCase("0 5", false, Category = "Invalid Input.")]
        [TestCase("5 0", false, Category = "Invalid Input.")]
        [TestCase("0 0", false, Category = "Invalid Input.")]
        [TestCase("-10 -10", false, Category = "Invalid Input.")]
        [TestCase("LLRMLRMMRL", false, Category = "Action like Input.")]
        [TestCase("1 2 N", false, Category = "Location like Input.")]
       
        public void IsValidTests(string input, bool expected)
        {
            var result = new Plateau().IsValid(input);
            Assert.AreEqual(expected, result);
        }
    }
}
