using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgs
{
    class Heapsort
    {
        // counts comparisions
        private int comparisonCount;

        // Calls Sort() and returns comparison count
        public int SortArray(int[] unsorted)
        {
            comparisonCount = 0;
            Sort(Heapify(unsorted, unsorted.Length));
            return comparisonCount;
        }
        // Sorts array using heapsort
        private void Sort(int[] heap)
        {
            int[] sorted = new int[heap.Length];
            int size = heap.Length;

            // sorting heap
            for (int i = 0; i < sorted.Length; i++)
            {
                sorted[i] = heap[0];
                heap[0] = heap[size - 1];
                heap[size - 1] = -1;
                size--;

                double completion = (float)(i + 1) / sorted.Length;

                if(completion == 0.25)
                {
                    Console.WriteLine("25% done with array size " + sorted.Length);
                }
                else if(completion == 0.50)
                {
                    Console.WriteLine("50% done with array size " + sorted.Length);
                }
                else if(completion == 0.75)
                {
                    Console.WriteLine("75% done with array size " + sorted.Length);
                }
                else if(completion == 0.90)
                {
                    Console.WriteLine("90% done with array size " + sorted.Length);
                }

                int curr = 0;
                int leftChild = 2 * curr + 1; // left child index
                int rightChild = 2 * curr + 2; // right child index

                if (heap[curr] < heap[leftChild] || heap[curr] < heap[rightChild])
                {
                    heap = Heapify(heap, size);
                }
            }
        }
        // Builds heap
        private int[] Heapify(int [] arr, int size)
        {
            int[] heap = new int[size];

            // building heap
            for (int i = 0; i < heap.Length; i++)
            {
                heap[i] = arr[i];

                int curr = i;
                int parent = (curr - 1) / 2; // parent of current index

                // up re-heapification
                while (curr > 0 && heap[curr] > heap[parent])
                {
                    comparisonCount++;
                    //Console.WriteLine(comparisonCount);
                    int temp = heap[curr];
                    heap[curr] = heap[parent];
                    heap[parent] = temp;

                    curr = parent;
                    parent = (curr - 1) / 2;
                }
            }

            return heap;
        }
    }
}
