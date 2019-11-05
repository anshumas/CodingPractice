using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using App.Metrics.Concurrency;
using CommonPrograms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingPractice.Test.CommonPrograms
{
    [TestClass]
    public class LeetCode2Test
    {
        LeetCodeProblems _testObject;
        [TestInitialize]
        public void TestInitialize()
        {
            _testObject = new LeetCodeProblems();
        }
        #region 189. Rotate Array
        /// <summary>
        /// 189. Rotate Array
        /// </summary>
        [TestMethod]
        public void RotateTest()
        {
            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            Rotate(arr, 0);
            arr = new int[] { 1, 2, 3 };
            Rotate(arr, 1);

        }
        public void Rotate(int[] nums, int k)
        {
            Stack<BinaryTree> ss = new Stack<BinaryTree>();
            ss.ToArray();
            int n = nums.Length;
            int r = k % n;
            if (r == 0 || n == 1) return;
            int[] shiftingArray = new int[r];
            int j = 0;
            for (int i = n - r; i < n; i++)
            {
                shiftingArray[j] = nums[i];
                j++;
            }
            j = n - 1;
            if (r > 2)
                for (int i = r; i >= 0; i--)
                {
                    nums[j] = nums[i];
                    j--;
                }
            else
            {
                for (int i = ((r - 2) < 0 ? 0 : (r - 2)); i >= 0; i--)
                {
                    nums[j] = nums[i];
                    j--;
                }
            }
            j = 0;
            for (int i = 0; j < r; i++)
            {
                nums[i] = shiftingArray[j];
                j++;
            }

        }
        #endregion
        #region 94. Binary Tree Inorder Traversal
        [TestMethod]
        public void InorderTraversalTest()
        {
            TreeNode root = new TreeNode(1)
            {
                left = null,
                right = new TreeNode(2)
                {
                    left = new TreeNode(3),
                    right = null
                }
            };
            var result = InorderTraversal(root);
        }
        private Queue<int> queue = new Queue<int>();
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            inOrderTrevers(root);
            while (queue.Count > 0)
            {
                int node = queue.Dequeue();
                result.Add(node);
            }
            return result;
        }
        private void inOrderTrevers(TreeNode root)
        {
            if (root == null) return;
            inOrderTrevers(root.left);
            visitNode(root);
            inOrderTrevers(root.right);
        }
        private void visitNode(TreeNode root)
        {
            queue.Enqueue(root.val);
        }
        #endregion

        [TestMethod]
        public void SuperReduceStringTest()
        {
            string s = "aaabccddd";

            int index = 0;
            int len = s.Length;
            while (index < len-1)
            {
                
                string currentChar = s.Substring(index, 1);
                
                string nextChar = s.Substring(index + 1, 1);
                if (currentChar == nextChar)
                {
                    s = s.Replace(currentChar + nextChar, "");
                    len = s.Length;
                    index--;
                }
                else
                {
                    index++;
                }
                index = index < 0 ? 0 : index;
            }
             

        }

        [TestMethod]
        public void ShrinkStringTest()
        {
            string input = "ansssssshhuuumansiiiingh";
            string result = string.Empty;
            char[] inputArr = input.ToCharArray();
            char oldchar = inputArr[0];
            int count = 1;
            for (int i = 1; i <= inputArr.Length; i++)
            {
                if (i < inputArr.Length && inputArr[i] == oldchar)
                {
                    count++;
                    continue;
                }
                else
                {
                    result = result + oldchar + count;
                    oldchar = i < inputArr.Length ? inputArr[i] : inputArr[0];
                    count = 1;
                }
            }
            Assert.AreEqual(result, "a1n1s6h2u3m1a1n1s1i4n1g1h1");
        }
        [TestMethod]
        public void NumberToStringTest()
        {
            double num = 9001.56;
            string result = string.Empty;
            int key = 0;
            int intPart = (int)num;
            int fractionPart = (int)(num * 100 - intPart * 100);
            Dictionary<int, string> onesDict = new Dictionary<int, string>();
            onesDict.Add(1, "one");
            onesDict.Add(2, "two");
            onesDict.Add(3, "three");
            onesDict.Add(4, "four");
            onesDict.Add(5, "five");
            onesDict.Add(6, "six");
            onesDict.Add(7, "seven");
            onesDict.Add(8, "eight");
            onesDict.Add(9, "nine");
            onesDict.Add(10, "ten");
            onesDict.Add(11, "eleven");
            onesDict.Add(12, "twelve");
            onesDict.Add(13, "thirteen");
            onesDict.Add(14, "fourteen");
            onesDict.Add(15, "fifteen");
            onesDict.Add(16, "sixteen");
            onesDict.Add(17, "seventeen");
            onesDict.Add(18, "eighteen");
            onesDict.Add(19, "nineteen");

            Dictionary<int, string> twosDict = new Dictionary<int, string>();
            twosDict.Add(2, "twenty");
            twosDict.Add(3, "thirty");
            twosDict.Add(4, "fourty");
            twosDict.Add(5, "fifty");
            twosDict.Add(6, "sixty");
            twosDict.Add(7, "seventy");
            twosDict.Add(8, "eighty");
            twosDict.Add(9, "ninety");
            //thousand
            key = (int)(intPart / 1000);
            if (key > 0)
            {
                result = result + onesDict[key] + " thousand ";
                intPart = (intPart % 1000);
            }
            //hundrad
            key = (int)(intPart / 100);
            if (key > 0)
            {
                result = result + onesDict[key] + " hundrad ";
                intPart = (intPart % 100);
            }
            //under undred
            key = (int)(intPart / 10);
            if (key > 0)
            {
                result = result + twosDict[key] + " ";
                intPart = (intPart % 10);
            }
            //ones
            key = (int)(intPart % 10);
            if (key > 0)
            {
                result = result + onesDict[key] + " and ";

            }
            //cent
            //under undred
            key = (int)(fractionPart / 10);
            if (key > 0)
            {
                result = result + twosDict[key] + " ";
                fractionPart = (fractionPart % 10);
            }
            key = (int)(fractionPart % 10);
            if (key > 0)
            {
                result = result + onesDict[key] + " cent ";

            }
            Assert.IsNotNull(result);
        }

    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
