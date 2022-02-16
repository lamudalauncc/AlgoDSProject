using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Project1
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            try
            {
                String randomHeading = "Sorting for Random Numbers";
                String sortedHeading = "Sorting for Sorted Numbers";
                String revsortedHeading = "Sorting for Reverse Ordered Sorted Numbers";

                Console.WriteLine("Enter a number of elments to sort:");
                int n = int.Parse(Console.ReadLine());

                SortingAlgos sortalgo = new SortingAlgos();

                int[] inputArray = sortalgo.getRandomNumbers(n);
                int[] inputArray1 = new int[inputArray.Length];
                Array.Copy(inputArray, inputArray1, inputArray.Length);
                int[] inputArray2 = new int[inputArray.Length];
                Array.Copy(inputArray, inputArray2, inputArray.Length);

                StreamWriter file = new StreamWriter("Output.txt", true);
                file.WriteLine("\n Size of Input" + n);
                file.Flush();
                file.Close();

                CalculateRunTime calTime = new CalculateRunTime();

                Console.WriteLine('\n' + "Sorting -*#*#*#*#- Random Numbers  *#*#*#*#" + '\t' + '\n');
                CalculateRunTime.randomSort(inputArray, randomHeading);

                Console.WriteLine('\n' + "Sorting -*#*#*#*#- Sorted Numbers *#*#*#*#" + '\t' + '\n');
                CalculateRunTime.randomSort(inputArray1, sortedHeading);

                Console.WriteLine('\n' + "Sorting -*#*#*#*#- Reverse Ordered Sorted Numbers *#*#*#*#" + '\t' + '\n');
                CalculateRunTime.randomSort(inputArray2, revsortedHeading);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        } 
    }
}