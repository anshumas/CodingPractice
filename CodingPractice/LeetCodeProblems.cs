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
            if (x < 0 || x % 10 == 0)
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

        /// <summary>
        /// https://leetcode.com/contest/weekly-contest-155/problems/ugly-number-iii/
        /// </summary>
        /// <param name="n"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int NthUglyNumber(int n, int a, int b, int c)
        {
            /*
             F(N) = a + b + c - a ∩ c - a ∩ b - b ∩ c + a ∩ b ∩ c
        F(N) = N/a + N/b + N/c - N/lcm(a, c) - N/lcm(a, b) - N/lcm(b, c) + N/lcm(a, b, c)(lcm = least common multiple)
             */
            long low = Math.Min(a, b);
            low = Math.Min(low, c);

            long high = low * n;
            long lcm_ab = LCM(a, b);
            long lcm_ac = LCM(a, c);
            long lcm_bc = LCM(b, c);
            long lcm_abc = LCM(a, lcm_bc);
            while (low < high)
            {
                long mid = low + (high - low) / 2;
                long cnt = mid / a + mid / b + mid / c - mid / lcm_ab - mid / lcm_bc - mid / lcm_ac + mid / lcm_abc;
                if (cnt < n)
                    low = mid + 1;
                else
                    //the condition: F(N) >= k
                    high = mid;
            }
            return (int)low;

        }
        // Use Euclid's algorithm to calculate the
        // greatest common divisor (GCD) of two numbers.
        private long GCD(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            // Pull out remainders.
            for (; ; )
            {
                long remainder = a % b;
                if (remainder == 0) return b;
                a = b;
                b = remainder;
            };
        }
        // Return the least common multiple
        // (LCM) of two numbers.
        private long LCM(long a, long b)
        {
            return a * b / GCD(a, b);
        }

        /// <summary>
        /// https://leetcode.com/contest/weekly-contest-155/problems/smallest-string-with-swaps/
        /// </summary>
        /// <param name="n"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
        {
            char[] charArray = s.ToCharArray();
            foreach (var pair in pairs)
            {
                char tmp = charArray[pair[0]];
                charArray[pair[0]] = charArray[pair[1]];
                charArray[pair[1]] = tmp;
            }
            return new String(charArray);
        }
    }

}
