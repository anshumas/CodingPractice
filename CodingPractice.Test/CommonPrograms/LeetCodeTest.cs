using System;
using System.Collections.Generic;
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
        /// <summary>
        /// https://leetcode.com/contest/weekly-contest-155/problems/ugly-number-iii/
        /// </summary>
        [TestMethod]
        public void NthUglyNumber()
        {
            int result = _testObject.NthUglyNumber(3, 2, 3, 5);
            Assert.AreEqual(result, 4);

            int result1 = _testObject.NthUglyNumber(4, 2, 3, 4);
            Assert.AreEqual(result1, 6);

            int result2 = _testObject.NthUglyNumber(5, 2, 11, 13);
            Assert.AreEqual(result2, 10);

            int result3 = _testObject.NthUglyNumber(1000000000, 2, 217983653, 336916467);
            Assert.AreEqual(result3, 1999999984);

        }
        /// <summary>
        /// https://leetcode.com/contest/weekly-contest-155/problems/smallest-string-with-swaps/
        /// </summary>
        [TestMethod]
        public void SmallestStringWithSwaps()
        {
            IList<IList<int>> pairs = new List<IList<int>>();
            IList<int> a = new List<int>();
            IList<int> b = new List<int>();
            IList<int> c = new List<int>();
            a.Add(0);
            a.Add(3);
            pairs.Add(a);
            b.Add(1);
            b.Add(2);
            pairs.Add(b);
            var result = _testObject.SmallestStringWithSwaps("dcab", pairs);
            Assert.AreEqual(result, "bacd");
            pairs = new List<IList<int>>();
            a = new List<int>();
            b = new List<int>();
            c = new List<int>();
            a.Add(0);
            a.Add(3);
            pairs.Add(a);
            
            c.Add(0);
            c.Add(2);
            pairs.Add(c);
            b.Add(1);
            b.Add(2);
            pairs.Add(b);
            var result1 = _testObject.SmallestStringWithSwaps("dcab", pairs);
            Assert.AreEqual(result1, "abcd");

            pairs = new List<IList<int>>();
            a = new List<int>();
            b = new List<int>();
            c = new List<int>();
            a.Add(0);
            a.Add(1);
            pairs.Add(a);
            b.Add(1);
            b.Add(2);
            pairs.Add(b);
            c.Add(0);
            c.Add(1);
            pairs.Add(c);
            var result2 = _testObject.SmallestStringWithSwaps("cba", pairs);
            Assert.AreEqual(result2, "abc");

        }
    }
}
