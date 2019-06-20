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
            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left.Add(input[i]);
            }
            for (int i = middle; i < input.Count; i++)
            {
                right.Add(input[i]);
            }
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

        public int[] MergeSort(int[] input)
        {
            if (input.Length <= 1)
                return input;
            int middle = input.Length / 2;
            int[] left = new int[middle];
            int[] right = new int[input.Length - middle];

            for (int i = 0; i < middle; i++)  //Dividing the unsorted list
            {
                left[i] = input[i];
            }
            for (int i = 0; i < middle + input.Length % 2; i++)
            {
                right[i] = input[middle + i];
            }
            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }
        private int[] Merge(int[] left, int[] right)
        {
            List<int> result = new List<int>();
            int leftIndex, rightIndex;
            leftIndex = rightIndex = 0;
            while (leftIndex < left.Length || rightIndex < right.Length)
            {
                if (leftIndex < left.Length && rightIndex < right.Length)
                {
                    if (left[leftIndex] <= right[rightIndex])
                    {
                        result.Add(left[leftIndex]);
                        leftIndex++;
                    }
                    else if (left[leftIndex] > right[rightIndex])
                    {
                        result.Add(right[rightIndex]);
                        rightIndex++;
                    }
                }
                else
                {
                    if (leftIndex < left.Length)
                    {
                        result.Add(left[leftIndex]);
                        leftIndex++;
                    }
                    if (rightIndex < right.Length)
                    {
                        result.Add(right[rightIndex]);
                        rightIndex++;
                    }
                }
            }
            return result.ToArray();
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
            int pivot = inputList[(right + left) / 2];
            int index = partition(inputList, left, right, pivot);
            if (index > 1)
            {
                QuickSort(inputList, left, index - 1);
            }
            if (index < right)
            {
                QuickSort(inputList, index, right);
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
        #region bubble sort
        public int[] BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (arr[j] > arr[j + 1])
                    {
                        // swap temp and arr[i] 
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
            return arr;
        }
        #endregion
        #region Selection Sort
        public int[] SelectionSort(int[] arr)
        {
            int n = arr.Length;

            // One by one move boundary of unsorted subarray 
            for (int i = 0; i < n - 1; i++)
            {
                // Find the minimum element in unsorted array 
                int min_idx = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[min_idx])
                        min_idx = j;

                // Swap the found minimum element with the first 
                // element 
                int temp = arr[min_idx];
                arr[min_idx] = arr[i];
                arr[i] = temp;
            }
            return arr;
        }
        #endregion
        #region Heap Sort
        public int[] HeapSort(int[] arr)
        {
            int n = arr.Length;
            BuildHeap(arr);
            for (int i = n - 1; i >= 0; i--)
            {
                // Move current root to end 
                swap(arr, 0, i);
                // call max heapify on the reduced heap 
                heapify(arr, i, 0);
            }

            return arr;
        }
        public int[] BuildHeap(int[] arr)
        {
            int n = arr.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                heapify(arr, n, i);
            }
            return arr;
        }
        private void heapify(int[] arr, int n, int i)
        {
            int largest = i; // Initialize largest as root 
            int left = 2 * i + 1; // left = 2*i + 1 
            int right = 2 * i + 2; // right = 2*i + 2 
            // If left child is larger than root 
            if (left < n && arr[left] > arr[largest])
                largest = left;

            // If right child is larger than largest so far 
            if (right < n && arr[right] > arr[largest])
                largest = right;

            // If largest is not root 
            if (largest != i)
            {
                swap(arr, i, largest);
                // Recursively heapify the affected sub-tree 
                heapify(arr, n, largest);
            }
        }
        private void swap(int[] inputlist, int left, int right)
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