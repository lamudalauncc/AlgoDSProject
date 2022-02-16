using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class SortingAlgos
    {

        public int[] getRandomNumbers(int arraySize)
        {
            Random randomNumber = new Random();
            int RANGE = 80000;
            int min = 0;
            int[] array = new int[arraySize];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = randomNumber.Next(min,RANGE);
            }
            return array;
        }
        public void swap(int p, int r, int[] inputArray)
        {
            int temp = inputArray[p];
            inputArray[p] = inputArray[r];
            inputArray[r] = temp;
        }

        //get Median
        public int getMedian(int leftele, int rightele, int[] inputArray)
        {
            int center = (leftele + rightele) / 2;
            if (inputArray[center] < inputArray[leftele])
                swap(center, leftele, inputArray);
            if (inputArray[rightele] < inputArray[leftele])
                swap(rightele, leftele, inputArray);
            if (inputArray[rightele] < inputArray[center])
                swap(rightele, center, inputArray);
            swap(center, rightele - 1, inputArray);
            return inputArray[rightele - 1];
        }

        //get middle
        private int getMiddle(int leftelem, int rightelem, int pivotItem, int[] inputArray)
        {
            int i = leftelem, j = rightelem - 1;
            while (true)
            {
                while (inputArray[++i] < pivotItem) ;
                while (pivotItem < inputArray[--j]) ;
                if (i >= j)
                    break;
                else
                    swap(i, j, inputArray);
            }
            swap(i, rightelem - 1, inputArray);
            return i;
        }

        //Insertion Sort
        public void InsertionSort(int[] inputArrray)
        {
            int n = inputArrray.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = inputArrray[i];
                int j = i - 1;

                while (j >= 0 && inputArrray[j] > key)
                {
                    inputArrray[j + 1] = inputArrray[j];
                    j = j - 1;
                }
                inputArrray[j + 1] = key;
            }
        }

        public void merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;

            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            for (i = 0; i < n1; ++i)
                L[i] = arr[l + i];
            for (j = 0; j < n2; ++j)
                R[j] = arr[m + 1 + j];

            i = 0;
            j = 0;

            int k = l;
            while (i < n1 && j < n2)
            {
                if (L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }
                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            }
        }

        // merge()
        public void MergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);
                merge(arr, l, m, r);
            }
        }
        
        public void HeapifyArr(int[] arrToHeapify, int n, int i)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && arrToHeapify[l] > arrToHeapify[largest])
                largest = l;

            if (r < n && arrToHeapify[r] > arrToHeapify[largest])
                largest = r;

            if (largest != i)
            {
                int swap = arrToHeapify[i];
                arrToHeapify[i] = arrToHeapify[largest];
                arrToHeapify[largest] = swap;

                HeapifyArr(arrToHeapify, n, largest);
            }
        }

        //Heap Sort
        public void HeapSort(int[] inputArrray)
        {
            int n = inputArrray.Length;

            for (int i = n / 2 - 1; i >= 0; i--)
                HeapifyArr(inputArrray, n, i);

            for (int i = n - 1; i > 0; i--)
            {
                int temp = inputArrray[0];
                inputArrray[0] = inputArrray[i];
                inputArrray[i] = temp;

                HeapifyArr(inputArrray, i, 0);
            }
        }
        public static void InPlaceQuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(arr, left, right);

                if (pivot > 1)
                {
                    InPlaceQuickSort(arr, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    InPlaceQuickSort(arr, pivot + 1, right);
                }
            }

        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivot = arr[left];
            while (true)
            {

                while (arr[left] < pivot)
                {
                    left++;
                }

                while (arr[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    if (arr[left] == arr[right]) return right;

                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;


                }
                else
                {
                    return right;
                }
            }
        }

        //Modified Quick Sort
        public void modifiedQuickSort(int leftele, int rightele, int[] inputArray)
        {
            if (leftele + 8 <= rightele)
            {
                int pivot = getMedian(leftele, rightele, inputArray);
                int middle = getMiddle(leftele, rightele, pivot, inputArray);
                modifiedQuickSort(leftele, middle - 1, inputArray);
                modifiedQuickSort(middle + 1, rightele, inputArray);
            }
            else
            {
                InsertionSort(inputArray);
            }
        }
    }
}
