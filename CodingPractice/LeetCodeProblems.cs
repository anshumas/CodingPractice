using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CommonPrograms
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
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
            int len = s.Length;
            int[] parent = new int[len];
            for (int i = 0; i < len; i++)
            {
                parent[i] = i;
            }
            foreach (var pair in pairs)
            {
                union(parent, pair[0], pair[1]);
            }
            var disjointSets = new Dictionary<int, IList<char>>();
            for (int i = 0; i < len; i++)
            {
                int key = find(parent, i);
                if (!disjointSets.ContainsKey(key))
                {
                    disjointSets.Add(key, new List<char>());
                }
                disjointSets[key].Add(s[i]);
            }
            var sorted = new Dictionary<int, Queue<char>>();
            foreach (var set in disjointSets)
            {
                var key = set.Key;
                var value = set.Value;
                var values = value.ToArray();
                Array.Sort(values);
                var queue = new Queue<char>(values);
                sorted.Add(key, queue);
            }
            var sb = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                var key = find(parent, i);
                var item = sorted[key].Dequeue();
                sb.Append(item);
            }
            return sb.ToString();
        }
        private void union(int[] parent, int i, int j)
        {
            int p1 = find(parent, i);
            int p2 = find(parent, j);
            if (p1 == p2)
                return;
            parent[p1] = p2;
        }
        private int find(int[] parent, int node)
        {
            return (node == parent[node]) ? node : parent[node] = find(parent, parent[node]);
        }
        /// <summary>
        /// https://leetcode.com/problems/median-of-two-sorted-arrays/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int L1 = nums1.Length;
            int L2 = nums2.Length;

            double result = 0;
            if ((L1 + L2) % 2 != 0)
            {
                int mid = (L1 + L2) / 2 + 1;
                if (mid <= L1 - 1)
                {

                }

            }

            return result;
        }
        public double FindMedianSortedArrays1(int[] nums1, int[] nums2)
        {
            int L1 = nums1.Length;
            int L2 = nums2.Length;
            int mid = (L1 + L2) / 2;
            var combinedArray = new int[mid + 1];
            int i = 0, j = 0, k = 0;
            while ((i < L1 || j < L2) && k < mid + 1)
            {
                if (i < L1 && j < L2)
                {
                    if (nums1[i] < nums2[j])
                    {
                        combinedArray[k] = nums1[i];
                        k++;
                        i++;
                    }
                    else
                    {
                        combinedArray[k] = nums2[j];
                        k++;
                        j++;
                    }
                }
                else if (i == L1 && j < L2)
                {
                    combinedArray[k] = nums2[j];
                    k++;
                    j++;
                }
                else if (i < L1 && j == L2)
                {
                    combinedArray[k] = nums1[i];
                    k++;
                    i++;
                }
            }
            double result;
            if ((L1 + L2) % 2 == 0)
            {
                result = (double)(combinedArray[mid - 1] + combinedArray[mid]) / 2;

            }
            else
            {
                result = combinedArray[mid];
            }
            return result;
        }
        /// <summary>
        /// https://leetcode.com/problems/merge-k-sorted-lists/
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>

        public ListNode MergeKLists(ListNode[] lists)
        {
            if (lists.Length == 0)
            {
                return null;
            }
            if (lists.Length == 1)
            {
                return lists[0];
            }
            ListNode result = null;
            for (int i = 0; i < lists.Length - 1; i++)
            {
                if (result == null)
                {
                    result = MergeLists(lists[i], lists[i + 1]);
                }
                else
                {
                    result = MergeLists(result, lists[i + 1]);
                }
            }
            return result;
        }
        private ListNode MergeLists(ListNode list1, ListNode list2)
        {
            ListNode dummay = new ListNode(0);
            if (list1 == null) { return list2; }
            if (list2 == null) { return list1; }
            ListNode tail = dummay;
            while (list1 != null && list2 != null)
            {
                if (list1.val < list2.val)
                {
                    tail.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    tail.next = list2;
                    list2 = list2.next;
                }
                tail = tail.next;
            }
            if (list1 == null)
            {
                tail.next = list2;
            }
            if (list2 == null)
            {
                tail.next = list1;
            }
            return dummay.next;
        }
        /// <summary>
        /// https://leetcode.com/problems/first-missing-positive/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FirstMissingPositive(int[] nums)
        {
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] <= 0 || nums[i] > n)
                {
                    nums[i] = n + 1;
                }
            }

            for (int i = 0; i < n; i++)
            {
                var index = (nums[i] < 0 ? -nums[i] : nums[i]) - 1;
                if (index != nums.Length && nums[index] > 0)
                {
                    nums[index] = -nums[index];
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (nums[i] > 0)
                {
                    return i + 1;
                }
            }
            return n + 1;
        }
        public int FirstMissingPositive1(int[] nums)
        {
            if (nums.Length == 1)
            {
                return nums[0] == 1 ? 2 : 1;
            }
            int n = nums.Length;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != i + 1)
                {
                    ShiftToRightPlace(nums, nums[i]);
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (nums[i] != i + 1)
                {
                    return i + 1;
                }
            }
            return n + 1;
        }
        private void ShiftToRightPlace(int[] nums, int n)
        {
            if (n > 0 && n <= nums.Length && nums[n - 1] != n)
            {
                int tmp = nums[n - 1];
                nums[n - 1] = n;
                ShiftToRightPlace(nums, tmp);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int BinarySearch(int[] nums, int target)
        {

            int n = nums.Length;
            int index = FindTargetwithBinarySerch(nums, 0, n - 1, target);
            return index;
        }
        private int FindTargetwithBinarySerch(int[] nums, int start, int end, int target)
        {
            if (start > end)
            {
                return -1;
            }
            int midIndex = (start + end) / 2;
            if (nums[midIndex] == target)
                return midIndex;

            if (nums[midIndex] > target)
            {
                return FindTargetwithBinarySerch(nums, start, midIndex - 1, target);
            }
            else
            {
                return FindTargetwithBinarySerch(nums, midIndex + 1, end, target);
            }
        }


        #region 3. Longest Substring Without Repeating Characters
        /// <summary>
        /// 3.https://leetcode.com/problems/longest-substring-without-repeating-characters/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int LengthOfLongestSubstring(string s)
        {

            if (string.IsNullOrEmpty(s))
                return 0;
            int start = 0;
            int end = 0;
            int result = int.MinValue;
            int len = s.Length;
            if (len == 1)
                return 1;
            char[] stringArray = s.ToCharArray();

            Dictionary<char, int> freqTable = new Dictionary<char, int>();
            while (end < len)
            {
                char currentChar = stringArray[end];
                if (!freqTable.ContainsKey(currentChar))
                {
                    freqTable.Add(currentChar, end);
                    end++;
                }
                else
                {
                    if (result < end - start)
                    {
                        result = end - start;
                    }
                    int new_start = freqTable[currentChar] + 1;
                    for (int i = start; i < new_start; i++)
                    {
                        freqTable.Remove(stringArray[i]);
                    }
                    start = new_start;
                    freqTable.Add(currentChar, end);
                    end++;
                }
            }
            if (result < end - start)
            {
                result = end - start;
            }

            return result;
        }
        #endregion

        #region 5. Longest Palindromic Substring
        /// <summary>
        /// https://leetcode.com/problems/longest-palindromic-substring/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public String LongestPalindrome(String s)
        {
            int len = s.Length;
            char[] chars = s.ToCharArray();

            while (len >= 0)
            {
                for (int i = 0; i + len - 1 < chars.Length; i++)
                {
                    int left = i;
                    int right = i + len - 1;
                    bool flag = true;

                    while (left < right)
                    {
                        if (chars[left] != chars[right])
                        {
                            flag = false;
                            break;
                        }
                        left++;
                        right--;
                    }
                    if (flag)
                    {
                        return s.Substring(i, len);
                    }
                }
                len--;
            }

            return "";
        }
        public string LongestPalindrome2(string str)
        {
            // get length of input string 
            if (str.Length <= 1) return str;
            char[] input = InsertCharInString(str);
            if (str.Length == 2 && input.Length == str.Length)
            {
                return input[0].ToString();
            }
            int n = input.Length;
            int result = 1;
            int lowIndex = 0;
            int highIndex = n - 1;
            for (int i = 0; i < n / 2 + 1; i++)
            {
                int back = i - 1;
                int next = i + 1;
                bool atleast = false;
                while (back >= 0 && next < n)
                {
                    if (input[back] != input[next])
                    {
                        back += 1;
                        next -= 1;
                        break;
                    }
                    atleast = true;
                    if (back == 0 || next == n)
                    {
                        break;
                    }
                    back -= 1;
                    next += 1;
                }

                back = back < 0 ? 0 : back;
                next = next == n ? --next : next;

                if (atleast && result < (next - back))
                {
                    result = (next - back);
                    lowIndex = back;
                    highIndex = next;
                }
            }

            return GetSubStringFromArray(input, lowIndex, highIndex);
        }
        private string GetSubStringFromArray(char[] input, int start, int end)
        {
            StringBuilder result = new StringBuilder();
            for (int i = start; i <= end; i++)
            {
                char c = input[i];
                if (c != '|')
                {
                    result.Append(c);
                }
            }
            return result.ToString();
        }
        private char[] InsertCharInString(string str)
        {
            int n = str.Length;
            char[] oldString = str.ToCharArray();
            StringBuilder result = new StringBuilder(str);
            int count = 0;
            for (int i = 1; i < n; i++)
            {
                if (oldString[i] == oldString[i - 1])
                {
                    result.Insert(i + count, '|');
                    count++;
                }
            }

            return result.ToString().ToCharArray();
        }
        public string LongestPalindrome1(string str)
        {
            int n = str.Length;   // get length of input string 

            bool[,] table = new bool[n, n];

            // All substrings of length 1 are palindromes 
            int maxLength = 1;
            for (int i = 0; i < n; ++i)
                table[i, i] = true;

            // check for sub-string of length 2. 
            int start = 0;
            for (int i = 0; i < n - 1; ++i)
            {
                if (str.ElementAt(i) == str.ElementAt(i + 1))
                {
                    table[i, i + 1] = true;
                    start = i;
                    maxLength = 2;
                }
            }
            for (int k = 3; k <= n; ++k)
            {
                for (int i = 0; i < n - k + 1; ++i)
                {
                    int j = i + k - 1;

                    if (table[i + 1, j - 1] && str.ElementAt(i) == str.ElementAt(j))
                    {
                        table[i, j] = true;
                        if (k > maxLength)
                        {
                            start = i;
                            maxLength = k;
                        }
                    }
                }
            }
            return str.Substring(start, maxLength);
        }
        #endregion
        #region Sqrt
        public int MySqrt(int x)
        {
            if (x == 0 || x == 1)
                return x;
            long start = 1, end = x/2+1, ans = 0;
            while (start <= end)
            {
                long mid = (start + end) / 2;
                long sqr = mid * mid;
                if (sqr == x)
                    return (int)mid;

                if (sqr < x)
                {
                    start = mid + 1;
                    ans = mid;
                }
                else
                    end = mid - 1;
            }
            return (int)ans;

        }
        public double MyPow(double x, int n)
        {
            if (n == 0) return 1;
            bool flag = false;
            if (n < 0)
            {
                n *= (-1);
                flag = true;
            }
            double result = x;
            for (int i = 1; i < n; i++)
            {
                result *= x;
            }
            if (flag)
            {
                result = 1 / result;
            }
            return result;
        }
        #endregion
    }


}
