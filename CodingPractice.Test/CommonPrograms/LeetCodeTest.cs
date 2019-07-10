using System;
using CommonPrograms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingPractice.Test.CommonPrograms
{
    [TestClass]
    public class LeetCodeTest
    {
        LeetCodeProblems _testObject;
        [TestInitialize]
        public void TestInitialize()
        {
            _testObject = new LeetCodeProblems();
        }
        [TestMethod]
        public void isPalindrome()
        {

            bool result = _testObject.IsPalindrome(1001);
            Assert.IsTrue(result);
            result = _testObject.IsPalindrome(12221);
            Assert.IsTrue(result);

            result = _testObject.IsPalindrome(1221);
            Assert.IsTrue(result);
        }
    }
}
