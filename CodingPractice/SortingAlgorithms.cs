using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPrograms
{
    public class SortingAlgorithms
    {
        #region Merge Sort
        public List<int> MergeSort(List<int> input)
        {
            if (input.Count <= 1)
                return input;
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            int middle = input.Count / 2;
            left.AddRange(input.Take(middle));
            right.AddRange(input.Skip(middle));
            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }
        private List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                   else if (left.First() > right.First())
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else
                {
                    if (left.Count > 0 )
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    if (right.Count > 0)
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
            }
            return result;
        }
        #endregion
    }
}
