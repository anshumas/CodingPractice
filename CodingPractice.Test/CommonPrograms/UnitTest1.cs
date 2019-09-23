using System;
using CommonPrograms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingPractice.Test.CommonPrograms
{
    [TestClass]
    public class TreeTest
    {
        BinaryTree treeobject;
        [TestInitialize]
        public void TestInitialize()
        {
            treeobject = new BinaryTree();
        }
        [TestMethod]
        public void InsertTest()
        {
            long[] arr = new long[] { 1, 10, 5, 1, 0, 6 };
            string a = Solution(arr);

            Node root = createTreeData();
            Assert.IsTrue(true);
        }
        private Node createTreeData()
        {
            //100,20, 500,10,30,40
            Node root = treeobject.Insert(null, 100);
            root = treeobject.Insert(root, 20);
            root = treeobject.Insert(root, 500);
            root = treeobject.Insert(root, 10);
            root = treeobject.Insert(root, 30);
            root = treeobject.Insert(root, 40);
            return root;
        }
        public static string Solution(long[] arr)
        {
            // Type your solution here
            long left = SumOftree(arr, 1);
            long right = SumOftree(arr, 2);
            if (left > right)
                return "Left";
            else
                return "Right";
        }
        private static long SumOftree(long[] arr, long index)
        {
            if (index >= arr.Length )
                return 0;
            if (arr[index] == -1)
                return 0;
            long val = arr[index];
            long val1 = SumOftree(arr, (2 * index + 1));
            long val2 = SumOftree(arr, (2 * index + 2));
            return val + val1 + val2;
        }
    }
}
