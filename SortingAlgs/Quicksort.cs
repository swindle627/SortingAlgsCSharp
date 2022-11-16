using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

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
            Sort(unsorted);
            return comparisonCount;
        }
        // Sorts array using quicksort
        private int[] Sort(int[] unsorted)
        {
            int low = 0; // first index of the array
            int high = unsorted.Length - 1; // last index of the array
            Stack<int> indexes = new Stack<int>(); // stack containing low and high indexes

            indexes.Push(low);
            indexes.Push(high);


            while (indexes.Count > 0)
            {
                high = indexes.Pop();
                low = indexes.Pop();

                int pIndex = Partition(ref unsorted, low, high); // gets the partition index

                // adds the low and high indexes for the left partition to the stack
                if (pIndex - 1 > low)
                {
                    indexes.Push(low);
                    indexes.Push(pIndex - 1);
                }

                // adds the low and high indexes for the right partition to the stack
                if (pIndex + 1 < high)
                {
                    indexes.Push(pIndex + 1);
                    indexes.Push(high);
                }
            }

            return unsorted;
        }
        private int Partition(ref int[] unsorted, int low, int high)
        {
            int pivot = unsorted[high]; // sets pivot value to farthest right value
            int pIndex = low - 1; // partition index
            int temp; // used for swapping

            // puts values lower than or equal to the pivot value to the left of it and values higher than the pivot value to the right of it
            // loop stops before it reaches the pivot value's index
            for (int i = low; i < high; i++)
            {
                if (unsorted[i] <= pivot)
                {
                    pIndex++;
                    temp = unsorted[i];
                    unsorted[i] = unsorted[pIndex];
                    unsorted[pIndex] = temp;
                }
                comparisonCount++;
            }

            // this will set pIndex to the index the pivot value is supposed to be at
            pIndex++;

            // puts the pivot value into its correct place
            temp = unsorted[high];
            unsorted[high] = unsorted[pIndex];
            unsorted[pIndex] = temp;

            return pIndex;
        }
    }
}
