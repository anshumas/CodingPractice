using System;
using CrackingTheCoding;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingPractice.Test.CrackingTheCoding
{
    [TestClass]
    public class Chapter01Test
    {
        [TestMethod]
        public void IsUniqueTest()
        {
            var result=Chapter01.IsUnique("absdskdbddkssdks");
            Assert.IsFalse(result);
        }
    }
}
