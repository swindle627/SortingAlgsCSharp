using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgs
{
    class Quicksort
    {
        // counts comparisions
        private int comparisonCount;

        // Calls Sort() and returns comparison count
        public int SortArray(int[] unsorted)
        {
            comparisonCount = 0;
            Sort(unsorted, 0, unsorted.Length-1);
            return comparisonCount;
        }
        // Sorts array using quicksort
        private int[] Sort(int[] unsorted, int low, int high)
        {
            int left = low; // leftmost index
            int right = high; // rightmost index
            int pivot = unsorted[high]; // pivot set to the rightmost index

            // sorts array so that a values less than the pivot will be on its left...
            // ...and all values greater than the pivot will be on its right
            while (left <= right)
            {
                // left index skips values less than the pivot
                while (unsorted[left] < pivot)
                {
                    left++;
                    comparisonCount++;
                }

                // right index skips values greater than the pivot
                while (unsorted[right] > pivot)
                {
                    right--;
                    comparisonCount++;
                }

                // swaps left and right values if left index is not greater than right index
                if (left <= right)
                {
                    int temp = unsorted[left];
                    unsorted[left] = unsorted[right];
                    unsorted[right] = temp;
                    left++;
                    right--;
                }
            }

            // sorts left partition
            if (low < right)
            {
                Sort(unsorted, low, right);
            }

            // sorts right partition
            if (left < high)
            {
                Sort(unsorted, left, high);
            }

            return unsorted;
        }

    }
}
