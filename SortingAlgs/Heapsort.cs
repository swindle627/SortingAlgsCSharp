using System;

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
            Sort(unsorted);
            return comparisonCount;
        }
        // Sorts array using heapsort
        private int[] Sort(int[] unsorted)
        {
            int size = unsorted.Length;
            int[] sorted = new int[size];

            // builds initial heap
            int[] heap = CreateHeap(unsorted, size);

            // sorting heap
            for (int i = 0; i < sorted.Length; i++)
            {
                sorted[i] = heap[0];

                // swap the first and last element of the heap
                // this plus reheaping is reversing the actual heap. returning heap instead of sorted will show that
                int temp = heap[0];
                heap[0] = heap[size - 1];
                heap[size - 1] = temp;

                // decrease size of heap
                size--;

                // re-heapification
                heap = ReHeap(heap, size, 0);
            }

            return sorted;
        }
        private int[] ReHeap(int[] heap, int size, int root)
        {
            int largest = root; // index of tree/sub-tree root
            int leftChild = 2 * root + 1; // left child index
            int rightChild = 2 * root + 2; // right child index

            // if left child value is larger than root value set its index to largest
            if (leftChild < size && heap[largest] < heap[leftChild])
            {
                largest = leftChild;
                comparisonCount++;
            }

            // if right child is larger than root or left child value set its index to largest
            if (rightChild < size && heap[largest] < heap[rightChild])
            {
                largest = rightChild;
                comparisonCount++;
            }

            // if the root value isnt larger than its children's values swap the largest child value with root value
            // recursive call with the new root set to the index the old root was just swapped to
            if (largest != root)
            {
                int temp = heap[root];
                heap[root] = heap[largest];
                heap[largest] = temp;

                heap = ReHeap(heap, size, largest);
            }

            return heap;
        }
        private int[] CreateHeap(int [] arr, int size)
        {
            int[] heap = new int[size];

            // building heap
            for (int i = 0; i < heap.Length; i++)
            {
                heap[i] = arr[i];

                int curr = i; // current index
                int parent = (curr - 1) / 2; // parent of current index

                // up re-heapification
                while (curr > 0 && heap[curr] > heap[parent])
                {
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
