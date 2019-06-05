﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            
            for (int i = 0; i < 200000; i++)
            {
                unsorted.Add(random.Next(0, 100000));
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            sorted =_object.MergeSort(unsorted);
            stopwatch.Stop();
           string totaltime= stopwatch.Elapsed.ToString();
            Assert.AreEqual(sorted.Count, 10);
            /*
             20,000  -00:00:00.1306896
             2,00,000-00:00:02.6504209
             */
        }
    }
}
