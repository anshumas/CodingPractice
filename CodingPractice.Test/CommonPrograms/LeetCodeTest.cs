using System;
using System.Collections.Generic;
using System.Text;
using App.Metrics.Concurrency;
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
            int result = _testObject.NthUglyNumber(9, 2, 3, 5);
            Assert.AreEqual(result, 12);
            result = _testObject.NthUglyNumber(3, 2, 3, 5);
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
        /// <summary>
        /// https://leetcode.com/problems/median-of-two-sorted-arrays/
        /// </summary>
        [TestMethod]
        public void FindMedianSortedArrays()
        {
            var nums1 = new int[] { 1, 3 };
            var nums2 = new int[] { 2 };
            var result = _testObject.FindMedianSortedArrays(nums1, nums2);
            Assert.AreEqual(result, 2.0);


            nums1 = new int[] { 1, 2 };
            nums2 = new int[] { 3, 4 };
            result = _testObject.FindMedianSortedArrays(nums1, nums2);
            Assert.AreEqual(result, 2.5);


            nums1 = new int[] { 0, 0 };
            nums2 = new int[] { 0, 0 };
            result = _testObject.FindMedianSortedArrays(nums1, nums2);
            Assert.AreEqual(result, 0);
        }
        /// <summary>
        /// https://leetcode.com/problems/merge-k-sorted-lists/
        /// </summary>
        [TestMethod]
        public void MergeKLists()
        {
            ListNode[] input = new ListNode[3];
            var a1 = new ListNode(1) { next = new ListNode(4) { next = new ListNode(5) } };
            input[0] = a1;
            var a2 = new ListNode(1) { next = new ListNode(3) { next = new ListNode(4) } };
            input[1] = a2;
            var a3 = new ListNode(2) { next = new ListNode(6) };
            input[2] = a3;

            var result = _testObject.MergeKLists(input);
            var r = new ListNode(1)
            {
                next = new ListNode(1)
                {
                    next = new ListNode(2)
                    {
                        next = new ListNode(3)
                        {
                            next = new ListNode(4)
                            {
                                next = new ListNode(4)
                                {
                                    next = new ListNode(5)
                                    {
                                        next = new ListNode(6)
                                    }
                                }
                            }
                        }
                    }
                }
            };

            Assert.Equals(result, r);
        }
        /// <summary>
        /// https://leetcode.com/problems/first-missing-positive/
        /// </summary>
        [TestMethod]
        public void firstMissingPositive()
        {
            int[] a = new int[] { 2, 1 };
            int result = _testObject.FirstMissingPositive(a);
            Assert.AreEqual(result, 8);


            a = new int[] { 3, 4, -1, 1 };
            result = _testObject.FirstMissingPositive(a);
            Assert.AreEqual(result, 2);

            a = new int[] { 7, 8, 9, 11, 12 };
            result = _testObject.FirstMissingPositive(a);
            Assert.AreEqual(result, 1);
        }
        /// <summary>
        /// https://leetcode.com/explore/learn/card/binary-search/138/background/1038/
        /// </summary>
        [TestMethod]
        public void BinarySearch()
        {
            int[] a = new int[] { -1, 0, 3, 5, 9, 12 };
            int result = _testObject.BinarySearch(a, 9);
            Assert.AreEqual(result, 4);

            a = new int[] { 2, 5 };
            result = _testObject.BinarySearch(a, 2);
            Assert.AreEqual(result, 0);

            a = new int[] { -1, 0, 3, 5, 9, 12 };
            result = _testObject.BinarySearch(a, 2);
            Assert.AreEqual(result, -1);


        }
        /// <summary>
        /// https://leetcode.com/problems/longest-substring-without-repeating-characters/
        /// </summary>
        [TestMethod]
        public void LengthOfLongestSubstring()
        {

            //test1
            int result = _testObject.LengthOfLongestSubstring("au");
            Assert.AreEqual(result, 3);
            //test1
            result = _testObject.LengthOfLongestSubstring("rtjhdfzbdghsrthsrtt");
            Assert.AreEqual(result, 3);
            //test2
            result = _testObject.LengthOfLongestSubstring("bbbbb");
            Assert.AreEqual(result, 1);

            //test3
            result = _testObject.LengthOfLongestSubstring("pwwkew");
            Assert.AreEqual(result, 3);

        }
        /// <summary>
        /// https://leetcode.com/problems/longest-palindromic-substring/
        /// </summary>
        [TestMethod]
        public void LongestPalindrome()
        {
            //test1
            string result = _testObject.LongestPalindrome("aa");
            Assert.AreEqual(result, "aa");

            result = _testObject.LongestPalindrome("abb");
            Assert.AreEqual(result, "bb");
            result = _testObject.LongestPalindrome("ac");
            Assert.AreEqual(result, "a");


            result = _testObject.LongestPalindrome("aabbccdddd");
            Assert.AreEqual(result, "aa");
            //test1
            result = _testObject.LongestPalindrome("abcxcba");
            Assert.AreEqual(result, "abcxcba");

            result = _testObject.LongestPalindrome("pabcxcbaq");
            Assert.AreEqual(result, "abcxcba");
            //test2
            result = _testObject.LongestPalindrome("cbbd");
            Assert.AreEqual(result, "bb");



        }
        /// <summary>
        /// https://leetcode.com/problems/longest-palindromic-substring/
        /// </summary>
        [TestMethod]
        public void Sqrt()
        {
            //test1
            int result = _testObject.MySqrt(8);
            Assert.AreEqual(result, 2);
            result = _testObject.MySqrt(49);
            Assert.AreEqual(result, 7);
            result = _testObject.MySqrt(2147395600);
            Assert.AreEqual(result, 46340);
        }
        [TestMethod]
        public void MyPow()
        {
            //test1
            double result = _testObject.MyPow(0.00001, 2147483647);
            Assert.AreEqual(result, 2);
            result = _testObject.MyPow(2.1, 3);
            Assert.AreEqual(result, 9.26100);
            result = _testObject.MyPow(2, -3);
            Assert.AreEqual(result, 0.25000);
        }

        [TestMethod]
        public void testEmpData()
        {
            //int[,] d = new int[5, 5] {
            //    { 1, 4, 7, 11, 15},
            //    { 2, 5, 8, 12, 19},
            //    { 3, 6, 9, 16, 22 },
            //    { 10, 13, 14, 17, 24 },
            //    { 18, 21, 23, 26, 30 }
            //};
            int[][] d = new int[3][];
            d[0] = new int[4] { 1, 3, 5, 7 };
            d[1] = new int[4] { 10, 11, 16, 20 };
            d[2] = new int[4] { 23, 30, 34, 50 };
            bool result = SearchMatrix(d, 9);
            Assert.IsTrue(result);
        }
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int row = 0;
            int col = n - 1;
            while (row < m && col >= 0)
            {
                if (matrix[row][col] == target)
                {
                    return true;
                }
                if (matrix[row][col] < target)
                    row++;
                else if (matrix[row][col] > target)
                    col--;
            }
            return false;
        }
        [TestMethod]
        public void testLongestCommonPrefix()
        {
            string[] strs = new string[] { "flower", "flow", "flight" };
            var result = LongestCommonPrefix(strs);
        }
        public string LongestCommonPrefix(string[] strs)
        {
            int n = strs.Length;
            string result = FindLCP(strs[0], strs[1]);
            if (n > 2)
            {
                for (int i = 2; i < n; i++)
                {
                    result = FindLCP(result, strs[i]);
                }
            }
            return result;
        }

        private string FindLCP(string A, string B)
        {
            char[] arrA = A.ToCharArray();
            char[] arrB = B.ToCharArray();
            int count = A.Length > B.Length ? B.Length : A.Length;
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                if (arrA[i] != arrB[i])
                {
                    break;
                }
                result.Append(arrA[i]);
            }
            return result.ToString();
        }
        [TestMethod]
        public void RemoveDuplicatestest()
        {
            int[] nums = new int[] { 1,1,1,1,1,2,2,2,2,2,2,3};
            var result = RemoveDuplicates(nums);

        }

        public int RemoveDuplicates(int[] nums)
        {
            int prev = nums[0];
            int newLength = 0;
            int seenInARow = 1;

            AtomicInteger ff = new AtomicInteger(0);
            ff.GetValue();
            for (int i = 1; i < nums.Length; i++)
            {

                seenInARow = (nums[i] == prev) ? seenInARow + 1 : 1;

                if (seenInARow < 3)
                {
                    newLength++;
                    nums[newLength] = nums[i];
                    prev = nums[i];
                }
            }

            return newLength;
        }
    }
}
