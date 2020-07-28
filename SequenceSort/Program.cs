using System;
using System.Diagnostics;
using System.Linq;

namespace SequenceSort
{
    public class Program
    {
        private static int[] sequence;
        private static int userInput;

        static void Main(string[] args)
        {
            //sequence = new int[50000000];
            bool isActive = true;
            Stopwatch stopWatch = new Stopwatch();

            Console.WriteLine("SequenceSort: A project by Chase Franz\n");

            SortingCalibrator calibrator = new SortingCalibrator();
            //calibrator.Calibrate();

            do
            {
                AskUserForSequenceSize();
                AskUserForSortAlgorithmChoice();
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
                                LogSortDetails(stopWatch.Elapsed, "Insertion Sort");
                                break;

                            case 2:
                                sequence.PopulateWithRandomValues();
                                stopWatch.Reset();
                                stopWatch.Start();

                                // Execute Sort
                                sequence.SelectionSort();

                                stopWatch.Stop();
                                LogSortDetails(stopWatch.Elapsed, "Selection Sort");
                                break;

                            case 3:
                                sequence.PopulateWithRandomValues();
                          
                                stopWatch.Reset();
                                stopWatch.Start();

                                // Execute Sort
                                sequence.MergeSort(false);

                                stopWatch.Stop();
                                LogSortDetails(stopWatch.Elapsed, "Merge Sort");
                                break;

                            case 4:
                                sequence.PopulateWithRandomValues();

                                stopWatch.Reset();
                                stopWatch.Start();

                                // Execute Sort
                                sequence.MergeSort(true);

                                stopWatch.Stop();
                                LogSortDetails(stopWatch.Elapsed, "Merge Sort");
                                break;

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

        private static void AskUserForSequenceSize()
        {
            Console.WriteLine("Please submit a sequence length (N <= ~50000000).");
            string userInput = Console.ReadLine();
            bool isValid = int.TryParse(userInput, out int sequenceSize) && 0 <= sequenceSize;// && sequenceSize <= 50000000;

            if(isValid)
            {
                sequence = new int[sequenceSize];
            }
        }

        public static bool CollectAndValidateUserInput()
        {
            return int.TryParse(Console.ReadLine(), out userInput) && 1 <= userInput && userInput <= 3 || userInput == -1;
        }

        public static void AskUserForSortAlgorithmChoice()
        {
            Console.WriteLine("Please select an option from the list below");
            Console.WriteLine("\tInsertion Sort:  1");
            Console.WriteLine("\tSelection Sort: 2");
            Console.WriteLine("\tMerge Sort: 3");
            Console.WriteLine("\tClose Project:\t-1");
        }

        public static void LogException(Exception ex)
        {
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

        public static void LogSortDetails(TimeSpan sortTimeSpan, string sortName)
        {
            Console.WriteLine($"SORT DETAILS");
            Console.WriteLine($"Sorting Algorithm: {sortName}");
            Console.WriteLine($"Execution Time: {sortTimeSpan}");
            Console.WriteLine("\n\n--------------------------------------------------------------------------------------------------\n");
        }
    }
}
