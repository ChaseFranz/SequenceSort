using System;
using System.Diagnostics;

namespace SequenceSort
{
    public class Program
    {
        private static int[] sequence;
        private static int userInput;

        static void Main(string[] args)
        {
            sequence = new int[5000];
            bool isActive = true;
            Stopwatch stopWatch = new Stopwatch();

            Console.WriteLine("SequenceSort: A project by Chase Franz\n");

            do
            {
                AskForUserInput();
                bool validInput = CollectAndValidateUserInput();
                
                // TODO: Use Enum instead of 'magic numbers'
                if (validInput)
                {
                    try
                    {
                        switch (userInput)
                        {
                            case -1:
                                // User wants to end loop
                                isActive = false;
                                break;

                            case 1:
                                sequence.PopulateWithRandomValues();
                                stopWatch.Reset();
                                stopWatch.Start();

                                // Execute Sort
                                sequence.InsertionSort();

                                stopWatch.Stop();
                                LogSortDetails(sequence, stopWatch.Elapsed, "Insertion Sort");
                                break;

                            case 2:
                                sequence.PopulateWithRandomValues();
                                stopWatch.Reset();
                                stopWatch.Start();

                                // Execute Sort
                                sequence.SelectionSort();

                                stopWatch.Stop();
                                LogSortDetails(sequence, stopWatch.Elapsed, "Selection Sort");
                                break;

                            // TODO: Implement merge sort.

                            default:
                                throw new ArgumentException("Unhandled user input");
                        }
                    }
                    catch(Exception ex)
                    {
                        LogException(ex);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
            while (isActive);
            Console.WriteLine("Closing Project...");
        }

        public static bool CollectAndValidateUserInput()
        {
            return int.TryParse(Console.ReadLine(), out userInput) && 1 <= userInput && userInput <= 2 || userInput == -1;
        }

        public static void AskForUserInput()
        {
            Console.WriteLine("Please select an option from the list below");
            Console.WriteLine("\tInsertion Sort Ascending:  1");
            Console.WriteLine("\tSelection Sort: 2");
            Console.WriteLine("\tClose Project:\t-1");
        }

        public static void LogException(Exception ex)
        {
            //Console.Clear();
            Console.WriteLine(ex);
        }

        public static void LogSortDetails(int[] sequence, TimeSpan sortTimeSpan, string sortName)
        {
            Console.Write("\nOrdered Sequence = { ");
            for (int i = 0; i < sequence.Length; i++)
            {
                Console.Write(sequence[i]);
                if (i < sequence.Length - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.WriteLine(" }\n");

            Console.WriteLine($"SORT DETAILS");
            Console.WriteLine($"Sorting Algorithm: {sortName}");
            Console.WriteLine($"Execution Time: {sortTimeSpan}");
            Console.WriteLine("\n\n--------------------------------------------------------------------------------------------------\n");
        }
    }
}
