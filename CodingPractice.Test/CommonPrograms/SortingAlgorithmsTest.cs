using System;
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

            for (int i = 0; i < 2000000; i++)
            {
                unsorted.Add(random.Next(1, 2000000));
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            sorted = _object.MergeSort(unsorted);
            stopwatch.Stop();
            string totaltime = stopwatch.Elapsed.ToString();
            Assert.AreEqual(totaltime, 10);
            /*
             20,000  -00:00:00.1306896
             2,00,000-00:00:02.6504209
             20,00,000-
             */
        }
        [TestMethod]
        public void MergeSortArrayTest()
        {
            int[] unsorted = new int[2000000];

            Random random = new Random();

            for (int i = 0; i < 2000000; i++)
            {
                unsorted[i] = (random.Next(1, 2000000));
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[] result = _object.MergeSort(unsorted);
            stopwatch.Stop();
            string totaltime = stopwatch.Elapsed.ToString();
            Assert.AreEqual(totaltime, 10);
            /*
             20,000  -00:00:00.1306896
             2,00,000-00:00:02.6504209
             20,00,000-
             */
        }
        [TestMethod]
        public void QuickSortTest()
        {
            List<int> unsorted = new List<int>();
            List<int> sorted;
            Random random = new Random();

            for (int i = 0; i < 2000000; i++)
            {
                unsorted.Add(random.Next(1, 2000000));
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            sorted = _object.QuickSort(unsorted);
            stopwatch.Stop();
            string totaltime = stopwatch.Elapsed.ToString();
            Assert.AreEqual(sorted.Count, unsorted.Count);
            /*
             20,000  -00:00:00.0076616
             2,00,000-00:00:00.0455105
             20,00,000-00:00:00.9556085
             */
        }
        [TestMethod]
        public void BubbleSortTest()
        {
            int[] unsorted = new int[20000];

            Random random = new Random();

            for (int i = 0; i < 20000; i++)
            {
                unsorted[i] = (random.Next(1, 200));
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[] result = _object.BubbleSort(unsorted);
            stopwatch.Stop();
            string totaltime = stopwatch.Elapsed.ToString();
            Assert.AreEqual(totaltime, 10);
            /*
             20,000  -00:00:00.1306896
             2,00,000-00:00:02.6504209
             20,00,000-
             */
        }
        [TestMethod]
        public void SelectionSortTest()
        {
            int[] unsorted = new int[20000];

            Random random = new Random();

            for (int i = 0; i < 20000; i++)
            {
                unsorted[i] = (random.Next(1, 200));
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[] result = _object.SelectionSort(unsorted);
            stopwatch.Stop();
            string totaltime = stopwatch.Elapsed.ToString();
            Assert.AreEqual(totaltime, 10);
            /*
             20,000  -00:00:00.1306896
             2,00,000-00:00:02.6504209
             20,00,000-
             */
        }
        [TestMethod]
        public void HeapSortTest()
        {
            int[] unsorted = new int[2000000];

            Random random = new Random();

            for (int i = 0; i < 2000000; i++)
            {
                unsorted[i] = (random.Next(1, 2000000));
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int[] result = _object.HeapSort(unsorted);
            stopwatch.Stop();
            string totaltime = stopwatch.Elapsed.ToString();
            Assert.AreEqual(totaltime, 10);
            /*
             20,000  -00:00:00.0192972
             2,00,000-00:00:00.2128037
             20,00,000-02.1107629
             */
        }
    }
}
