using System;

namespace SequenceSort
{
    public static class IntArrayExtensions
    {
        /// <summary>
        /// Sort a sequence of integers with Insertion sort.
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="sortInDescendingOrder"></param>
        public static void InsertionSort(this int[] sequence, bool sortInDescendingOrder)
        {
            Func<int, int, bool> CompareSubArrayItemToKey;

            // Calling this function in iterations allows for optional descending or ascending sorts.
            if (sortInDescendingOrder)
            {
                CompareSubArrayItemToKey = (subArrayItem, key) => subArrayItem < key;
            }
            else
            {
                CompareSubArrayItemToKey = (subArrayItem, key) => subArrayItem > key;
            }

            // Insertion Sort Algorithm
            for (int i = 1; i < sequence.Length; i++)
            {
                int key = sequence[i];
                int subArrayIndex = i - 1;

                while (subArrayIndex > -1 && CompareSubArrayItemToKey(sequence[subArrayIndex],key))
                {
                    sequence[subArrayIndex + 1] = sequence[subArrayIndex];
                    subArrayIndex--;
                }
                sequence[subArrayIndex + 1] = key;
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
