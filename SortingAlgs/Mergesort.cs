using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgs
{
    class Mergesort
    {
        // counts comparisions made in the merge method
        private int comparisonCount; 

        // Sorts array using mergesort
        public int SortArray(int[] unsorted)
        {
            comparisonCount = 0;
            Sort(unsorted);
            return comparisonCount;
        }
        private int[] Sort(int[] unsorted)
        {
            if (unsorted.Length == 1)
            {
                return unsorted;
            }

            // set arrOne size to half the size of unsorted
            int arrOneSize = unsorted.Length / 2;
            // set arrTwo size to half the size of unsorted
            // if size of unsorted is odd arrTwo will have the extra value
            int arrTwoSize = unsorted.Length - arrOneSize;

            int[] arrOne = new int[arrOneSize];
            int[] arrTwo = new int[arrTwoSize];

            Array.Copy(unsorted, 0, arrOne, 0, arrOneSize);
            Array.Copy(unsorted, arrOneSize, arrTwo, 0, arrTwoSize); // value of arrOneSize will always be one number above the last index arrOne is copying

            arrOne = Sort(arrOne);
            arrTwo = Sort(arrTwo);

            return Merge(arrOne, arrTwo);
        }
        private int[] Merge(int[] arrOne, int[] arrTwo)
        {
            int[] mergedArray = new int[arrOne.Length + arrTwo.Length];

            int arrOneIndex = 0; // increments every time value from arrOne is added to mergedArray
            int arrTwoIndex = 0; // increments every time value from arrTwo is added to mergedArray
            int mergeIndex = 0; // index of mergedArray that values will be added to when merging. increments every time value is added to mergedArray

            // runs until all the values in arrOne OR arrTwo have been added to mergedArray
            // the lowest value is added to mergedArray which will order the array from least to greatest
            while (arrOneIndex < arrOne.Length && arrTwoIndex < arrTwo.Length)
            {
                if (arrOne[arrOneIndex] > arrTwo[arrTwoIndex])
                {
                    mergedArray[mergeIndex] = arrTwo[arrTwoIndex];
                    arrTwoIndex++;
                }
                else
                {
                    mergedArray[mergeIndex] = arrOne[arrOneIndex];
                    arrOneIndex++;
                }

                comparisonCount++;
                mergeIndex++;
            }

            // add any remaining values from arrOne or arrTwo to the end of the mergedArray
            // only one of these loops will run because one of the arrays will already have all its values added
            while (arrOneIndex < arrOne.Length)
            {
                mergedArray[mergeIndex] = arrOne[arrOneIndex];
                arrOneIndex++;
                mergeIndex++;
            }
            while (arrTwoIndex < arrTwo.Length)
            {
                mergedArray[mergeIndex] = arrTwo[arrTwoIndex];
                arrTwoIndex++;
                mergeIndex++;
            }

            return mergedArray;
        }
    }
}
