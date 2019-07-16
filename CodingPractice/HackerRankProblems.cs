using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CommonPrograms
{
    public class HackerRankProblems
    {
        private SortingAlgorithms _sortingAlgorithms;
        public HackerRankProblems()
        {
            _sortingAlgorithms = new SortingAlgorithms();
        }

        #region sherlock-and-anagrams
        /// <summary>
        /// https://www.hackerrank.com/challenges/sherlock-and-anagrams/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
        /// </summary>
        public int SherlockAndAnagrams(string s)
        {
            var length = s.Length;
            Dictionary<string, int> subsets = new Dictionary<string, int>();
            var resultCount = 0;
            for (int i = 1; i < length; i++)
            {
                for (int j = 0; j + i <= length; j++)
                {
                    var tmp = string.Concat(s.Substring(j, i).OrderBy(c => c));
                    if (subsets.Keys.Contains(tmp))
                        subsets[tmp] = subsets[tmp] + 1;
                    else
                        subsets.Add(tmp, 1);
                }
            }
            resultCount = subsets.Sum(k => k.Value * (k.Value - 1) / 2);
            return resultCount;
        }
        #endregion

        #region count-triplets
        /// <summary>
        /// https://www.hackerrank.com/challenges/count-triplets-1/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
        /// </summary>
        public long CountTriplets(List<long> arr, long r)
        {
            long count = 0;
            long V = 0L;
            var d1 = arr.Distinct().ToDictionary(Key => Key, Value => V);
            var d2 = new Dictionary<long, long>(d1); // 

            foreach (var i in arr.Reverse<long>())
            {
                long ir = i * r;

                if (d2.TryGetValue(ir, out long j))
                {
                    count += j;
                }

                if (d1.TryGetValue(ir, out long k))
                {
                    d2[i] += k;
                }

                d1[i]++;
            }

            return count;

        }
        #endregion
        #region Frequency Queries
        /// <summary>
        /// https://www.hackerrank.com/challenges/frequency-queries/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=dictionaries-hashmaps
        /// </summary>

        public List<int> freqQuery(List<List<int>> queries)
        {
            Dictionary<int, int> collectionItems = new Dictionary<int, int>();
            List<int> result = new List<int>();
            foreach (var item in queries)
            {
                switch (item[0])
                {
                    case 1:
                        {
                            if (collectionItems.TryGetValue(item[1], out int i))
                                collectionItems[item[1]] += i;
                            else
                                collectionItems.Add(item[1], 1);
                            break;
                        }
                    case 2:
                        {
                            if (collectionItems.TryGetValue(item[1], out int i))
                            {
                                if (i == 1)
                                    collectionItems.Remove(item[1]);
                                else
                                    collectionItems[item[1]] -= i;
                            }
                            break;
                        }
                    case 3:
                        {
                            result.Add((collectionItems.Any(s => s.Value == item[1]) ? 1 : 0));
                            break;
                        }
                    default:
                        break;
                }
            }

            return result;

        }
        #endregion 

        #region Mark and Toys
        /// <summary>
        /// https://www.hackerrank.com/challenges/mark-and-toys/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=sorting
        /// </summary>
        /// <param name="prices"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MaximumToys(int[] prices, int k)
        {
            prices = _sortingAlgorithms.HeapSort(prices);
            int totalPrice = 0;
            int count = 0;
            while (totalPrice + prices[count] <= k)
            {
                totalPrice += prices[count];
                count++;

            }
            return count++;
        }
        //https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii/
        #endregion


        #region comparer



        public Player[] processPlayerList(Player[] players)
        {
            Checker chk = new Checker();
            Array.Sort(players, chk);
            return players;
        }

        #endregion

        #region Fraudulent Activity Notifications
        /// <summary>
        /// ///https://www.hackerrank.com/challenges/fraudulent-activity-notifications/problem?h_l=interview&playlist_slugs%5B%5D=interview-preparation-kit&playlist_slugs%5B%5D=sorting
        /// this is not working
        /// help https://stackoverflow.com/questions/11361320/data-structure-to-find-median
        /// </summary>
        /// <param name="expenditure"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public int ActivityNotifications(int[] expenditure, int d)
        {
            int[] medianArray = new int[d];


            int result = 0;

            for (int i = d; i < expenditure.Length; i++)
            {
                Array.Copy(expenditure, i - d, medianArray, 0, d);
                double medianValue = GetMedian(medianArray);
                if (medianValue * 2 <= expenditure[i])
                {
                    result++;
                }
            }
            return result;
        }
        private double GetMedian(int[] array)
        {
            Array.Sort(array);
            int midlen = array.Length / 2;
            if (array.Length % 2 == 0)
            {
                return (double)(array[midlen - 1] + array[midlen]) / 2;
            }
            else
            {
                return array[midlen];
            }
        }
        #endregion

        /// <summary>
        /// hackerlandRadioTransmitters
        /// https://www.hackerrank.com/challenges/hackerland-radio-transmitters/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
        /// </summary>
        /// <param name="x"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int HackerlandRadioTransmitters(int[] x, int k)
        {
            Array.Sort(x);
            int findNext = 0;
            int currnet = 0;
            int count = 0;
            while (findNext <= x.Length)
            {
                findNext = currnet + k;
                if (x[currnet] + k == x[findNext])
                {
                    currnet = findNext + k;
                    count += 1;
                }
                else
                {
                    currnet += 1;
                }
                

            }
            return count;
        }
    }
    public class Player
    {
        public String name;
        public int score;

        public Player(String name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }
    public class Checker : IComparer<Player>
    {
        // complete this method
        public int Compare(Player a, Player b)
        {
            if (a.score > b.score) return -1;
            if (a.score < b.score) return 1;

            return a.name.CompareTo(b.name);


        }
        int stringCompare(String a, String b)
        {
            int len = a.Length < b.Length ? a.Length : b.Length;
            char[] aArr = a.ToCharArray();
            char[] bArr = b.ToCharArray();
            for (int i = 0; i < len; i++)
            {
                if (aArr[i] > bArr[i]) return 1;
                if (aArr[i] < bArr[i]) return -1;
            }
            return 1;
        }
    }
}
