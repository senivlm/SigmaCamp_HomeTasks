using System;

namespace SigmaCamp_HomeTask3
{
    static internal class SortMethods
    {
        public static int counter = 0; 
        public static Vector QuickSort(Vector arr, int start, int end, string pivotPlace = "end")
        {
            int pivot;
            switch (pivotPlace)
            {
                case "start":
                    pivot = arr[start];
                    break;
                case "mid":
                    pivot = arr[(end+start)/2];
                    break;
                case "end":
                    pivot = arr[end];
                    break;
                default:
                    throw new ArgumentException("Incorrect parametr to choose pivot");
            }
            int left = start;
            int right = end;
            while (left <= right)
            {
                counter++;
                while (arr[left] < pivot)
                {
                    counter++;
                    left++;
                }

                while (arr[right] > pivot)
                {
                    counter++;
                    right--;
                }
                if (left <= right)
                {
                    int temp = arr[left];
                    arr[left] = arr[right];
                    arr[right] = temp;
                    left++;
                    right--;
                }
            }

            if (start < right)
                QuickSort(arr, start, right, pivotPlace);
            if (left < end)
                QuickSort(arr, left, end, pivotPlace);
            return arr;
        }
    }
}
