using System;
using System.Collections.Generic;
using CommonPrograms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingPractice.Test.CommonPrograms
{
    [TestClass]
    public class SortingAlgorithmsTest
    {
        private SortingAlgorithms _object;
        [TestInitialize]
        public void Setup()
        {
            _object = new SortingAlgorithms();
        }
        [TestMethod]
        public void MergeSortTest()
        {
            List<int> unsorted = new List<int>();
            List<int> sorted;
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                unsorted.Add(random.Next(0, 100));
            }
            sorted=_object.MergeSort(unsorted);
            Assert.AreEqual(sorted.Count, 10);
        }
    }
}
