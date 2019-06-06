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
                    if (left.Count > 0)
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
        #region quick sort
        public List<int> QuickSort(List<int> inputList)
        {
            QuickSort(inputList, 0, inputList.Count - 1);
            return inputList;
        }
        private void QuickSort(List<int> inputList, int left, int right)
        {
            if (left >= right)
                return;
            int pivot = inputList[(right - left) / 2];
            int index = partition(inputList, left, right, pivot);
            if (index > 1)
            {
                QuickSort(inputList, left, index - 1);
            }
            if (index + 1 < right)
            {
                QuickSort(inputList, index + 1, right);
            }
        }
        private int partition(List<int> inputlist, int left, int right, int pivot)
        {

            while (left <= right)
            {
                while (inputlist[left] < pivot)
                {
                    left++;
                }
                while (inputlist[right] > pivot)
                {
                    right--;
                }
                if (left <= right)
                {
                    if (inputlist[left] != inputlist[right])
                        swap(inputlist, left, right);
                    left++;
                    right--;

                }

            }
            return left;

        }
        private void swap(List<int> inputlist, int left, int right)
        {
            if (inputlist[left] != inputlist[right])
            {
                int tmp = inputlist[left];
                inputlist[left] = inputlist[right];
                inputlist[right] = tmp;
            }
        }
        #endregion
    }
}
