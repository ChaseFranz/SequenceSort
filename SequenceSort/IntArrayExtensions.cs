using System;
using System.Numerics;

namespace SequenceSort
{
    public static class IntArrayExtensions
    {
        /// <summary>
        /// Sort a sequence of integers with Insertion sort.
        /// Theta of n-squared order of growth worst case and Theta of n best case.
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="sortInDescendingOrder"></param>
        public static void InsertionSort(this int[] sequence)
        {
            // Insertion Sort Algorithm
            for (int i = 1; i < sequence.Length; i++)
            {
                int key = sequence[i];
                int subArrayIndex = i - 1;

                while (subArrayIndex > -1 && sequence[subArrayIndex] < key)
                {
                    sequence[subArrayIndex + 1] = sequence[subArrayIndex];
                    subArrayIndex--;
                }
                sequence[subArrayIndex + 1] = key;
            }
        }

        public static void InsertionSort(this int[] sequence, int p, int q)
        {
            // Insertion Sort Algorithm
            for (int i = p + 1; i < q - p; i++)
            {
                int key = sequence[i];
                int subArrayIndex = i - 1;

                while (subArrayIndex >= p && sequence[subArrayIndex] < key)
                {
                    sequence[subArrayIndex + 1] = sequence[subArrayIndex];
                    subArrayIndex--;
                }
                sequence[subArrayIndex + 1] = key;
            }
        }

        /// <summary>
        /// Sort a sequence of integers with Selection sort.
        /// Theta of n-squared for best and worst case.
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="sortInDescendingOrder"></param>
        public static void SelectionSort(this int[] sequence)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                int min = sequence[i];
                int k = i;
                for (int j = i; j < sequence.Length; j++)
                {
                    if (min >= sequence[j])
                    {
                        k = j;
                        min = sequence[j];
                    }
                }
                sequence[k] = sequence[i];
                sequence[i] = min;
            }
        }

        /// <summary>
        /// Sort a sequence of integers with Merge sort.
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="sortInDescendingOrder"></param>
        public static void MergeSort(this int[] sequence, bool useInsertionSort)
        {
            if (useInsertionSort)
            {
                // TODO: need to make the sorting calibrator a singleton and calibrate when program starts (before the sort method is called)
                MergeSort(sequence, 0, sequence.Length - 1, new SortingCalibrator());
            }
            else
            {
                MergeSort(sequence, 0, sequence.Length - 1);
            }
        }

        private static void MergeSort(int[] sequence, int p, int r)
        {
            if (p < r)
            {
                int q = (p + r) / 2;
                MergeSort(sequence, p, q);
                MergeSort(sequence, q + 1, r);
                Merge(sequence, p, q, r);
            }
        }

        private static void MergeSort(int[] sequence, int p, int r, SortingCalibrator calibrator)
        {
            if(p<r)
            {
                if(r-p <= calibrator.K)
                {
                    // Using insertion sort on low N values is a faster operation than merge sort.
                    InsertionSort(sequence, p, r);
                }
                else
                {
                    int q = (p + r) / 2;
                    MergeSort(sequence, p, q);
                    MergeSort(sequence, q + 1, r);
                    Merge(sequence, p, q, r);
                }
            }
        }

        private static void Merge(int[] sequence, int p, int q, int r)
        {
            //Console.WriteLine($"Merge: p:{p} q:{q} r:{r}");
            int n1 = q - p + 1;
            int n2 = r - q;

            int[] left = new int[n1 + 1];
            int[] right = new int[n2 + 1];

            int i;
            int j;

            for (i=0; i < n1; i++)
            {
                left[i] = sequence[p + i];//sequence[p + i - 1];
            }
            for (j=0; j < n2; j++)
            {
                right[j] = sequence[q + j + 1];//sequence[p + j - 1];
            }

            // Can't use cardinal values?
            left[n1] = int.MaxValue;
            right[n2] = int.MaxValue;

            i = 0;
            j = 0;

            for(int k = p; k <= r; k++)
            {
                if(left[i] <= right[j])
                {
                    sequence[k] = left[i];
                    i++;
                }
                else
                {
                    sequence[k] = right[j];
                    j++;
                }
            } 
        }

        /// <summary>
        /// Puprose is to populate all array indexes with random values. 
        /// values are within the set [0,n) where n is the array length.
        /// </summary>
        /// <param name="sequence"></param>
        public static void PopulateWithRandomValues(this int[] sequence)
        {
            Random rand = new Random();
            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = rand.Next(0, sequence.Length);
            }
        }
    }
}
