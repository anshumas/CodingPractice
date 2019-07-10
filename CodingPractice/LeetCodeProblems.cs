using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CommonPrograms
{
    public class LeetCodeProblems
    {
        private SortingAlgorithms _sortingAlgorithms;
        public LeetCodeProblems()
        {
            _sortingAlgorithms = new SortingAlgorithms();
        }

        public bool IsPalindrome(int x)
        {
            if (x < 0 || x /% 10 == 0)
                return false;
            int len = x.ToString().Length;
            if (len == 1)
                return true;
            string xValue = x.ToString();
            int left = Convert.ToInt32(xValue.Substring(0, len / 2));
            int right;
            if (len % 2 == 0)
            {
                right = Convert.ToInt32(ReverseString(xValue.Substring(len / 2, len / 2)));
            }
            else
            {
                right = Convert.ToInt32(ReverseString(xValue.Substring((len / 2) + 1, len / 2)));
            }
            if (left == right)
                return true;
            return false;
        }
        public string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        public int ReverseInteger(int x)
        {
            int rev = 0;
            while (x != 0)
            {
                int pop = x % 10;
                x /= 10;
                if (rev > int.MaxValue / 10 || (rev == int.MaxValue / 10 && pop > 7)) return 0;
                if (rev < int.MinValue / 10 || (rev == int.MinValue / 10 && pop < -8)) return 0;
                rev = rev * 10 + pop;
            }
            return rev;
        }
    }

}
