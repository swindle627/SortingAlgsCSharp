using System;
using System.Collections.Generic;

/* Mergesort: 
 * O(n log n) for best, worst and average cases
 * Counts comparisons made when merging the arrays
 */

/* Quicksort: 
 * O(n log n) for best and avaerage cases. O(n^2) for worst case
 * Counts comparisons when comparing left and right values to the pivot value
 * Causes a stack overflow error for large increasing and decreasing arrays
 * Because they are already ordered there is a partition made for every value in the array
 * All increasing and decreasing arrays have an exact comaprison count of n(n-1)/2
 * This lines up with the worst case running time of O(n^2)
 */

/* Heapsort:
 * O(n log n) for best, worst and average cases
 * Counts comparisons made when reheaping
 */

namespace SortingAlgs
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = 0;

            // Sort objects
            Mergesort mergeSort = new Mergesort();
            Quicksort quickSort = new Quicksort();
            Heapsort heapSort = new Heapsort();

            int oneK = 1000, tenK = 10000, hundredK = 100000, oneMil = 1000000;

            int[] rnd1k = new int[oneK], rnd10k = new int[tenK], rnd100k = new int[hundredK], rnd1mil = new int[oneMil]; // arrays of random generated ints 
            int[] inc1k = new int[oneK], inc10k = new int[tenK], inc100k = new int[hundredK], inc1mil = new int[oneMil]; // arrays of increasing ints 
            int[] dec1k = new int[oneK], dec10k = new int[tenK], dec100k = new int[hundredK], dec1mil = new int[oneMil]; // arrays of decreasing ints

            // arrays that store comparison counts for each sort
            // indexes: mergesort = (0-3), quicksort = (4-7), heapsort = (8-11)
            int[] randomComparisons = new int[12];
            int[] increasingComparisons = new int[12];
            int[] decreasingComparisons = new int[12];

            while (option != 4)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("1. Populate Arrays");
                Console.WriteLine("2. Run Algorithms");
                Console.WriteLine("3. Display Outputs");
                Console.WriteLine("4. Exit program");
                Console.WriteLine("\nEnter option number:");

                option = Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                    Console.Clear();

                    // populating arrays
                    rnd1k = RandomIntegers(oneK);
                    rnd10k = RandomIntegers(tenK);
                    rnd100k = RandomIntegers(hundredK);
                    rnd1mil = RandomIntegers(oneMil);

                    inc1k = IncreasingIntegers(oneK);
                    inc10k = IncreasingIntegers(tenK);
                    inc100k = IncreasingIntegers(hundredK);
                    inc1mil = IncreasingIntegers(oneMil);

                    dec1k = DecreasingIntegers(oneK);
                    dec10k = DecreasingIntegers(tenK);
                    dec100k = DecreasingIntegers(hundredK);
                    dec1mil = DecreasingIntegers(oneMil);

                    Console.WriteLine("Arrays populated");
                }
                else if (option == 2)
                {
                    Console.Clear();

                    // Random array sorts
                    randomComparisons[0] = mergeSort.SortArray(rnd1k);
                    Console.WriteLine("mergesort rnd1k done");
                    randomComparisons[1] = mergeSort.SortArray(rnd10k);
                    Console.WriteLine("mergesort rnd10k done");
                    randomComparisons[2] = mergeSort.SortArray(rnd100k);
                    Console.WriteLine("mergesort rnd100k done");
                    randomComparisons[3] = mergeSort.SortArray(rnd1mil);
                    Console.WriteLine("mergesort rnd1mil done");
                    randomComparisons[4] = quickSort.SortArray(rnd1k);
                    Console.WriteLine("quicksort rnd1k done");
                    randomComparisons[5] = quickSort.SortArray(rnd10k);
                    Console.WriteLine("quicksort rnd10k done");
                    randomComparisons[6] = quickSort.SortArray(rnd100k);
                    Console.WriteLine("quicksort rnd100k done");
                    randomComparisons[7] = quickSort.SortArray(rnd1mil);
                    Console.WriteLine("quicksort rnd1mil done");
                    randomComparisons[8] = heapSort.SortArray(rnd1k);
                    Console.WriteLine("heapsort rnd1k done");
                    randomComparisons[9] = heapSort.SortArray(rnd10k);
                    Console.WriteLine("heapsort rnd10k done");
                    randomComparisons[10] = heapSort.SortArray(rnd100k);
                    Console.WriteLine("heapsort rnd100k done");
                    randomComparisons[11] = heapSort.SortArray(rnd1mil);
                    Console.WriteLine("heapsort rnd1mil done");

                    // Increasing array sorts
                    increasingComparisons[0] = mergeSort.SortArray(inc1k);
                    Console.WriteLine("mergesort inc1k done");
                    increasingComparisons[1] = mergeSort.SortArray(inc10k);
                    Console.WriteLine("mergesort inc10k done");
                    increasingComparisons[2] = mergeSort.SortArray(inc100k);
                    Console.WriteLine("mergesort inc100k done");
                    increasingComparisons[3] = mergeSort.SortArray(inc1mil);
                    Console.WriteLine("mergesort inc1mil done");
                    increasingComparisons[4] = quickSort.SortArray(inc1k);
                    Console.WriteLine("quicksort inc1k done");
                    increasingComparisons[5] = quickSort.SortArray(inc10k);
                    Console.WriteLine("quicksort inc10k done");
                    increasingComparisons[6] = -1;
                    Console.WriteLine("quicksort inc100k done");
                    increasingComparisons[7] = -1;
                    Console.WriteLine("quicksort inc1mil done");
                    increasingComparisons[8] = heapSort.SortArray(inc1k);
                    Console.WriteLine("heapsort inc1k done");
                    increasingComparisons[9] = heapSort.SortArray(inc10k);
                    Console.WriteLine("heapsort inc10k done");
                    increasingComparisons[10] = heapSort.SortArray(inc100k);
                    Console.WriteLine("heapsort inc100k done");
                    increasingComparisons[11] = heapSort.SortArray(inc1mil);
                    Console.WriteLine("heapsort inc1mil done");

                    // Decreasing array sorts
                    decreasingComparisons[0] = mergeSort.SortArray(dec1k);
                    Console.WriteLine("mergesort dec1k done");
                    decreasingComparisons[1] = mergeSort.SortArray(dec10k);
                    Console.WriteLine("mergesort dec10k done");
                    decreasingComparisons[2] = mergeSort.SortArray(dec100k);
                    Console.WriteLine("mergesort dec100k done");
                    decreasingComparisons[3] = mergeSort.SortArray(dec1mil);
                    Console.WriteLine("mergesort dec1mil done");
                    decreasingComparisons[4] = quickSort.SortArray(dec1k);
                    Console.WriteLine("quicksort dec1k done");
                    decreasingComparisons[5] = quickSort.SortArray(dec10k);
                    Console.WriteLine("quicksort dec10k done");
                    decreasingComparisons[6] = -1;
                    Console.WriteLine("quicksort dec100k done");
                    decreasingComparisons[7] = -1;
                    Console.WriteLine("quicksort dec1mil done");
                    decreasingComparisons[8] = heapSort.SortArray(dec1k);
                    Console.WriteLine("heapsort dec1k done");
                    decreasingComparisons[9] = heapSort.SortArray(dec10k);
                    Console.WriteLine("heapsort dec10k done");
                    decreasingComparisons[10] = heapSort.SortArray(dec100k);
                    Console.WriteLine("heapsort dec100k done");
                    decreasingComparisons[11] = heapSort.SortArray(dec1mil);
                    Console.WriteLine("heapsort dec1mil done");

                    Console.WriteLine("Algorithms Complete");
                }
                else if (option == 3)
                {
                    Console.Clear();

                    // strings used to display the data for each array type
                    string randomData = "Mergesort\t", increasingData = "Mergesort\t", decreasingData = "Mergesort\t";

                    for(int i = 0; i < 12; i++)
                    {
                        // starts quicksort row because quicksort comaparison data starts at index 4
                        if(i == 4)
                        {
                            randomData += "\nQuicksort\t";
                            increasingData += "\nQuicksort\t";
                            decreasingData += "\nQuicksort\t";
                        }
                        // starts heapsort row because heapsort comaparison data starts at index 8
                        else if (i == 8)
                        {
                            randomData += "\nHeapsort\t";
                            increasingData += "\nHeapsort\t";
                            decreasingData += "\nHeapsort\t";
                        }

                        if(randomComparisons[i] == -1)
                        {
                            randomData += "Overflow\t";
                        }
                        else
                        {
                            randomData += randomComparisons[i].ToString() + "\t";
                        }

                        if (increasingComparisons[i] == -1)
                        {
                            increasingData += "Overflow\t";
                        }
                        else
                        {
                            increasingData += increasingComparisons[i].ToString() + "\t";
                        }
                        
                        if(decreasingComparisons[i] == -1)
                        {
                            decreasingData += "Overflow\t";
                        }
                        else
                        {
                            decreasingData += decreasingComparisons[i].ToString() + "\t";
                        }
                    }

                    // displaying comparisons from random array sorts
                    Console.WriteLine("\nArray Type: Random\nAlgorithm\tn=10^3\tn=10^4\tn=10^5\tn=10^6\n------------------------------------------------");
                    Console.WriteLine(randomData);

                    // displaying comparisons from increasing array sorts
                    Console.WriteLine("\nArray Type: Increasing\nAlgorithm\tn=10^3\tn=10^4\tn=10^5\tn=10^6\n------------------------------------------------");
                    Console.WriteLine(increasingData);

                    // displaying comparisons from decreasing array sorts
                    Console.WriteLine("\nArray Type: Decreasing\nAlgorithm\tn=10^3\tn=10^4\tn=10^5\tn=10^6\n------------------------------------------------");
                    Console.WriteLine(decreasingData);
                }


                if (option != 4)
                {
                    Console.WriteLine("\nPress enter to contiune...");
                    ConsoleKeyInfo c;
                    do
                    {
                        c = Console.ReadKey();
                    }
                    while (c.Key != ConsoleKey.Enter);
                }

                Console.Clear();
            }

            Environment.Exit(0);
        }
        // Returns an array of random integers
        // n determines array size
        public static int[] RandomIntegers(int n)
        {
            Random rnd = new Random();
            int[] randomInts = new int[n];

            for(int i = 0; i < n; i++)
            {
                randomInts[i] = rnd.Next(n + 1);
            }

            return randomInts;
        }
        // Returns an array of increasing integers from 1 to n
        // n determines array size
        public static int[] IncreasingIntegers(int n)
        {
            int[] increasingInts = new int[n];

            for(int i = 0; i < n; i++)
            {
                increasingInts[i] = i + 1;
            }

            return increasingInts;
        }
        // Returns an array of decreasing integers from n to 1
        // n determines array size
        public static int[] DecreasingIntegers(int n)
        {
            int[] decreasingInts = new int[n];

            for (int i = 0; i < decreasingInts.Length; i++)
            {
                decreasingInts[i] = n;
                n--;
            }

            return decreasingInts;
        }
    }
}
