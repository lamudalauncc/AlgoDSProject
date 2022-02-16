using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class CalculateRunTime
    {
		public static int[] RevsortedArray(int[] random)
		{
			int[] array = new int[random.Length];
			Array.Copy(random, 0, array, 0, random.Length);
			int length = array.Length;
			for (int i = 1; i < length; i++)
			{
				int k = array[i];
				int j = i - 1;
				while (j >= 0 && array[j] < k)
				{
					array[j + 1] = array[j];
					j = j - 1;
				}
				array[j + 1] = k;
			}
			return array;
		}
        public static void Sorting(int[] randomArray, String outputHeader)
        {
            Array.Sort(randomArray);
            TimeCal(randomArray, outputHeader);
        }
        public static void ReverseOrderedSort(int[] randomArray, String outputHeader)
        {
            int[] reverseSortedArray = RevsortedArray(randomArray);
            TimeCal(reverseSortedArray, outputHeader);
        }
        public static void randomSort(int[] randomArray, String outputHeader)
        {
            int[] array1 = new int[randomArray.Length]; 
            Array.Copy(randomArray, array1, randomArray.Length);
            TimeCal(array1, outputHeader);
        }
        public static void TimeCal(int[] array, String a)
        {
            try
            {
                StreamWriter outputFile = new StreamWriter("Output.txt", true);
                outputFile.WriteLine('\n' + a + '\n');
                int[] sortedArray = new int[array.Length];
                Array.Copy(array, sortedArray, array.Length);
                int[] sortedArray1 = new int[array.Length];
                Array.Copy(array, sortedArray1, array.Length);
                int[] sortedArray2 = new int[array.Length];
                Array.Copy(array, sortedArray2, array.Length);
                int[] sortedArray3 = new int[array.Length];
                Array.Copy(array, sortedArray3, array.Length);
                int[] sortedArray4 = new int[array.Length];
                Array.Copy(array, sortedArray4, array.Length);

                Console.WriteLine("Array prior to sorting algorithm: " + sortedArray.ToString());

                SortingAlgos sortings = new SortingAlgos();

                //InsertionSort
                long insertionSortTimeStart = DateTime.Now.ToFileTime();
                sortings.InsertionSort(sortedArray);
                long insertionSortTimeEnd = DateTime.Now.ToFileTime();
                Console.WriteLine("*#*#*#*# Insertion Sort Implementation *#*#*#*#");
                Console.WriteLine("Insertion Sort Execution Time: " + '\t' + (insertionSortTimeEnd - insertionSortTimeStart) + " Nano Seconds");
                outputFile.WriteLine("\n*#*#*#*# Insertion Sort Implementation *#*#*#*# \n");
                outputFile.WriteLine("Execution Time of Insertion Sort  : " + '\t' + (insertionSortTimeEnd - insertionSortTimeStart) + " Nano Seconds" + '\n');
                //Console.WriteLine("[{0}]", string.Join(", ", sortedArray));

                //MergeSort
                long mergeSortTimeStart = DateTime.Now.ToFileTime();
                sortings.MergeSort(sortedArray3, 0, sortedArray3.Length - 1);
                long mergeSortTimeEnd = DateTime.Now.ToFileTime();
                Console.WriteLine("*#*#*#*# Merge Sort Implementation *#*#*#*#");
                Console.WriteLine("Merge Sort Execution time:" + '\t' + (mergeSortTimeEnd - mergeSortTimeStart) + " Nano Seconds");
                outputFile.WriteLine("\n*#*#*#*# Merge Sort Implementation*#*#*#*#\n");
                outputFile.WriteLine("\nMerge Sort Execution time:" + '\t' + (mergeSortTimeEnd - mergeSortTimeStart) + " Nano Seconds" + '\n');
                //Console.WriteLine("[{0}]", string.Join(", ", sortedArray3));

                //HeapSort
                long heapSortTimeStart = DateTime.Now.ToFileTime();
                sortings.HeapSort(sortedArray4);
                long heapSortTimeEnd = DateTime.Now.ToFileTime();
                Console.WriteLine("*#*#*#*# Heap Sort *#*#*#*#");
                Console.WriteLine("Heap Sort Execution time:" + '\t' + (heapSortTimeEnd - heapSortTimeStart) + " Nano Seconds");
                outputFile.WriteLine("\n*#*#*#*# Heap Sort *#*#*#*#\n");
                outputFile.WriteLine("\n Heap Sort Execution time:" + '\t' + (heapSortTimeEnd - heapSortTimeStart) + " Nano Seconds" + '\n');
                //Console.WriteLine("[{0}]", string.Join(", ", sortedArray4));

                //In-Place QuickSort
                long inplacequickTimeStart = DateTime.Now.ToFileTime();
                SortingAlgos.InPlaceQuickSort(sortedArray2, 0, sortedArray2.Length - 1);
                //sortings.InPlaceQuickSort(sortedArray2, 0, sortedArray2.Length - 1);
                long inplacequickTimeEnd = DateTime.Now.ToFileTime();
                Console.WriteLine("*#*#*#*# Inplace Quick Sort *#*#*#*#");
                Console.WriteLine("Inplace Quick Sort Execution time:" + '\t' + (inplacequickTimeEnd - inplacequickTimeStart) + " Nano Seconds");
                outputFile.WriteLine("\n*#*#*#*# Inplace Quick Sort *#*#*#*#\n");
                outputFile.WriteLine("\nInplace Quick Sort Execution time:" + '\t' + (inplacequickTimeEnd - inplacequickTimeStart) + " Nano Seconds" + '\n');
                //Console.WriteLine("[{0}]", string.Join(", ", sortedArray2));

                //Modified QuickSort
                long modifiedquickTimeStart = DateTime.Now.ToFileTime();
                sortings.modifiedQuickSort(0, sortedArray1.Length - 1, sortedArray1);
                long modifiedquickTimeEnd = DateTime.Now.ToFileTime();
                Console.WriteLine("*#*#*#*# Modified Quick Sort *#*#*#*#");
                Console.WriteLine("Modified Quick Sort Execution time:" + '\t' + (modifiedquickTimeEnd - modifiedquickTimeStart) + " Nano Seconds");
                //Console.WriteLine("[{0}]", string.Join(", ", sortedArray1));
                outputFile.WriteLine("\n*#*#*#*# Modified Quick Sort *#*#*#*#\n");
                outputFile.WriteLine("\n Modified Quick Sort Execution time:" + '\t' + (modifiedquickTimeEnd - modifiedquickTimeStart) + " Nano Seconds" + '\n');
                outputFile.Close();
            }
            catch (IOException e)
            {
                Console.WriteLine("Exception");
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
