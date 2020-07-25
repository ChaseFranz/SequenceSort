using System;

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
        /// Sort a sequence of integers with Selection sort.
        /// Theta of n-squared for best and worst case.
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="sortInDescendingOrder"></param>
        public static void MergeSort(this int[] sequence)
        {
            throw new NotImplementedException();
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
