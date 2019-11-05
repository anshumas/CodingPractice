using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommonPrograms
{
    [TestClass]
    public class InterviewBitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] arr = new int[] { 1, 5, 7, 8, 5, 3, 4, 2, 1 }; 
            var result = LongestSubsequence(arr,-2);
        }
        public int LongestSubsequence(int[] arr, int difference)
        {
            var dic = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (dic.ContainsKey(arr[i]))
                {
                    int value = dic[arr[i]] + 1;
                    dic.Remove(arr[i]);
                    if (dic.ContainsKey(arr[i] + difference))
                        dic[arr[i] + difference] = Math.Max(value, dic[arr[i] + difference]);
                    else dic.Add(arr[i] + difference, value);
                }
                else if (!dic.ContainsKey(arr[i] + difference))
                    dic.Add(arr[i] + difference, 1);
            }

            return dic.Values.Max();
        }
    }
}
