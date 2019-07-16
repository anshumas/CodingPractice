using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPrograms
{
    public class MinMaxHeap
    {
        #region MinHeap Methods
        public static int[] BuildMinHeap(int[] inputArray)
        {
            int n = inputArray.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                MinHeapify(inputArray, n, i);
            }
            return inputArray;
        }
        public static int[] SortMinHeap(int[] inputArray)
        {
            int n = inputArray.Length;
            // Build heap (rearrange array) 
            for (int i = n / 2 - 1; i >= 0; i--)
                MinHeapify(inputArray, n, i);

            // One by one extract an element from heap 
            for (int i = n - 1; i >= 0; i--)
            {

                // Move current root to end 
                int temp = inputArray[0];
                inputArray[0] = inputArray[i];
                inputArray[i] = temp;

                // call max heapify on the reduced heap 
                MinHeapify(inputArray, i, 0);
            }
            return inputArray;
        }
        public static int[] AddItemInMinHeap(int[] inputArray, int item)
        {
            return inputArray;
        }
        public static int[] DeleteItemFromMinHeap(int[] inputArray, int item)
        {
            return inputArray;
        }
        public static int[] FindItemInMinHeap(int[] inputArray, int item)
        {
            return inputArray;
        }
        #endregion

        #region MaxHeap Methods
        public static int[] BuildMaxHeap(int[] inputArray)
        {
            int n = inputArray.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(inputArray, n, i);
            }
            return inputArray;
        }

        public static int[] SortMaxHeap(int[] inputArray)
        {
            for (int i = inputArray.Length - 1; i >= 0; i--)
            {
                // Move current root to end 
                swap(inputArray, 0, i);
                // call max heapify on the reduced heap 
                MaxHeapify(inputArray, i, 0);
            }
            return inputArray;
        }
        public static int[] AddItemInMaxHeap(int[] inputArray, int item)
        {
            return inputArray;
        }
        public static int[] DeleteItemFromMaxHeap(int[] inputArray, int item)
        {
            return inputArray;
        }
        public static int FindItemInMaxHeap(int[] inputArray, int item)
        {
            int index = 0;
            while (index < inputArray.Length)
            {
                if (inputArray[index] == item)
                    break;
                if (item < inputArray[index])
                {
                    index = 2 * index + 1;
                }
                else if (item > inputArray[index])
                {
                    index = 2 * index + 2;
                }
            }
            return index;
        }
        private static void MaxHeapify(int[] arr, int n, int i)
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
                MaxHeapify(arr, n, largest);
            }
        }
        private static void MinHeapify(int[] arr, int n, int i)
        {
            int smallest = i; // Initialize smalles as root 
            int l = 2 * i + 1; // left = 2*i + 1 
            int r = 2 * i + 2; // right = 2*i + 2 

            // If left child is smaller than root 
            if (l < n && arr[l] < arr[smallest])
                smallest = l;

            // If right child is smaller than smallest so far 
            if (r < n && arr[r] < arr[smallest])
                smallest = r;

            // If smallest is not root 
            if (smallest != i)
            {
                int temp = arr[i];
                arr[i] = arr[smallest];
                arr[smallest] = temp;

                // Recursively heapify the affected sub-tree 
                MinHeapify(arr, n, smallest);
            }
        }
        #endregion
        private static void swap(int[] inputlist, int left, int right)
        {
            if (inputlist[left] != inputlist[right])
            {
                int tmp = inputlist[left];
                inputlist[left] = inputlist[right];
                inputlist[right] = tmp;
            }

        }
    }
}
