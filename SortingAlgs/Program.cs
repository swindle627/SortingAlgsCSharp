using System;
using System.Collections.Generic;

/* Mergesort: 
 * O(n log n) for best, worst and average cases
 * Counts comparisons made when merging the arrays
 */

/* Quicksort: 
 * O(n log n) for best and avaerage cases. O(n^2) for worst case
 * Counts comparisons when comparing left and right values to the pivot value
 * Causes a stack overflow error for increasing and decreasing arrays
 * Because they are already ordered there is a partition made for every value in the array
 * Increasing has an exact comparison count of n(n-1)/2
 * Decreasing has an exact comparison count of n(n-2)/2
 * Both of these line up with the worst case running time of O(n^2)
 */

/* Heapsort:
 * O(n log n) for best, worst and average cases
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

            List<int[]> arrayList = new List<int[]>()
            {
                new int[1000], new int[10000], new int[100000], new int [1000000], // arrays of random generated ints (indexes: 0-3)
                new int[1000], new int[10000], new int[100000], new int [1000000], // arrays of increasing ints (indexes: 4-7)
                new int[1000], new int[10000], new int[100000], new int [1000000], // arrays of decreasing ints (indexes: 8-11)
            };

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
                    for (int i = 0; i < 12; i++)
                    {
                        // populating random arrays
                        if(i < 4)
                        {
                            arrayList[i] = RandomIntegers(arrayList[i].Length);
                        }
                        // populating increasing arrays
                        else if(i < 8)
                        {
                            arrayList[i] = IncreasingIntegers(arrayList[i].Length);
                        }
                        // populating decreasing arrays
                        else
                        {
                            arrayList[i] = DecreasingIntegers(arrayList[i].Length);
                        }
                    }

                    Console.WriteLine("Arrays populated");
                }
                else if (option == 2)
                {
                    Console.Clear();

                    // running sorting algorithms
                    for(int i = 0; i < 12; i++)
                    {
                        int randomIndex = i % 4; // increments through indexes 0-3 in arrayList which are the random arrays
                        int increasingIndex = randomIndex + 4; // increments through indexes 4-7 in arrayList which are the increasing arrays
                        int decreasingIndex = increasingIndex + 4; //increments through indexes 8-11 in arrayList which are the decreasing arrays

                        // 0-3 is mergesort
                        if (i < 4)
                        {
                            randomComparisons[i] = mergeSort.SortArray(arrayList[randomIndex]);
                            increasingComparisons[i] = mergeSort.SortArray(arrayList[increasingIndex]);
                            decreasingComparisons[i] = mergeSort.SortArray(arrayList[decreasingIndex]);
                        }
                        // 4-7 is quicksort
                        else if(i < 8)
                        {
                            randomComparisons[i] = quickSort.SortArray(arrayList[randomIndex]);

                            if(arrayList[increasingIndex].Length > 10000)
                            {
                                increasingComparisons[i] = -1;
                            }
                            else
                            {
                                increasingComparisons[i] = quickSort.SortArray(arrayList[increasingIndex]);
                            }

                            if (arrayList[decreasingIndex].Length > 10000)
                            {
                                decreasingComparisons[i] = -1;
                            }
                            else
                            {
                                decreasingComparisons[i] = quickSort.SortArray(arrayList[decreasingIndex]);
                            }
                        }
                        // 8-11 is heapsort
                        else
                        {
                            randomComparisons[i] = heapSort.SortArray(arrayList[randomIndex]);
                            Console.WriteLine("random " + arrayList[randomIndex].Length + " comeplete");
                            increasingComparisons[i] = heapSort.SortArray(arrayList[increasingIndex]);
                            Console.WriteLine("increasing " + arrayList[increasingIndex].Length + " comeplete");
                            decreasingComparisons[i] = heapSort.SortArray(arrayList[decreasingIndex]);
                            Console.WriteLine("decreasing " + arrayList[decreasingIndex].Length + " comeplete");
                        }
                    }

                    Console.WriteLine("Alogrithms Complete");
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

                        randomData += randomComparisons[i].ToString() + "\t";
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
                randomInts[i] = rnd.Next();
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
