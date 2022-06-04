using System;
using System.IO;
namespace SigmaCamp_HomeTask3
{
    static internal class SortMethods
    {
        public static int counter = 0;
        static string outputFilePath1 = @"C:\Users\Bogdan\OneDrive - Technical Lyceum NTUU KPI\Навчання\Sigma Camp\SigmaCamp_HomeTask1\SigmaCamp_HomeTask3\DataHomeTask5_outputPart1.txt";
        static string outputFilePath2 = @"C:\Users\Bogdan\OneDrive - Technical Lyceum NTUU KPI\Навчання\Sigma Camp\SigmaCamp_HomeTask1\SigmaCamp_HomeTask3\DataHomeTask5_outputPart2.txt";
        static string outputFilePath3 = @"C:\Users\Bogdan\OneDrive - Technical Lyceum NTUU KPI\Навчання\Sigma Camp\SigmaCamp_HomeTask1\SigmaCamp_HomeTask3\DataHomeTask5_outputFull.txt";
        private static void Merge(Vector arr, int l, int q, int r)
        {
            int i = l;
            int j = q;
            int[] temp = new int[r - l];
            int k = 0;
            while (!(i == q || j == r))
            {
                if (arr[i] < arr[j])
                {
                    temp[k] = arr[i++];
                }
                else
                {
                    temp[k] = arr[j++];
                }
                k++;
            }
            if (i == q)
            {
                for (int m = j; m < r; m++)
                {
                    temp[k++] = arr[m];
                }
            }
            else
            {
                while (i < q)
                {
                    temp[k++] = arr[i++];
                }
            }
            for (int n = 0; n < temp.Length; n++)
            {
                arr[n + l] = temp[n];
            }
        }
        static void MergeSort(Vector arr, int l, int r)
        {
            if (r - l <= 1) return;
            int mid = (r + l) / 2;
            MergeSort(arr, l, mid);
            MergeSort(arr, mid, r);
            Merge(arr, l, mid, r);
        }
        static void FormTwoMergeSortedHalves(string inputFilePath, int size)
        {
            Vector myVector = new Vector(size / 2);
            using (StreamReader sr = new StreamReader(inputFilePath))
            {
                for (int i = 0; i < size; i++)
                {
                    if (i < size / 2)
                    {
                        myVector[i] = int.Parse(sr.ReadLine());
                    }
                    else
                    {
                        if (i == size / 2)
                        {
                            MergeSort(myVector, 0, myVector.GetLength());

                            //Writing first sorted part of array to file
                            using (StreamWriter sw = new StreamWriter(outputFilePath1))
                            {
                                for (int j = 0; j < myVector.GetLength(); j++)
                                {
                                    sw.WriteLine(myVector[j]);
                                }
                            }
                        }
                        myVector[i - size / 2] = int.Parse(sr.ReadLine());
                    }
                }
                MergeSort(myVector, 0, myVector.GetLength());

                //Writing second sorted part of array to file
                using (StreamWriter sw = new StreamWriter(outputFilePath2))
                {
                    for (int j = 0; j < myVector.GetLength(); j++)
                    {
                        sw.WriteLine(myVector[j]);
                    }
                }
            }
        }
        static void FormCompleteMergeSortedArray(int size)
        {
            //Mergesort and writing to a file complete array
            using (StreamWriter sw = new StreamWriter(outputFilePath3))
            {
                using (StreamReader part1 = new StreamReader(outputFilePath1), part2 = new StreamReader(outputFilePath2))
                {
                    int i = 0;
                    int j = 0;
                    int firstPartElement = int.Parse(part1.ReadLine());
                    int secondPartElement = int.Parse(part2.ReadLine());
                    while (!(i == size / 2 || j == size / 2))
                    {
                        if (firstPartElement < secondPartElement)
                        {
                            sw.WriteLine(firstPartElement);
                            string line = part1.ReadLine();
                            if (line != null) firstPartElement = int.Parse(line);
                            i++;
                        }
                        else
                        {
                            sw.WriteLine(secondPartElement);
                            string line = part2.ReadLine();
                            if (line != null) secondPartElement = int.Parse(line);
                            j++;
                        }
                    }
                    if (i == size / 2)
                    {
                        for (int m = j; m < size / 2; m++)
                        {
                            sw.WriteLine(secondPartElement);
                            string line = part2.ReadLine();
                            if (line != null) secondPartElement = int.Parse(line);
                        }
                    }
                    else
                    {
                        while (i < size / 2)
                        {
                            sw.WriteLine(firstPartElement);
                            string line = part1.ReadLine();
                            if (line != null) firstPartElement = int.Parse(line);
                            i++;
                        }
                    }
                }
            }
        }
        public static void MergeSortFromFile(string inputFilePath, int size = 100)
        {
            if (File.Exists(inputFilePath))
            {
                FormTwoMergeSortedHalves(inputFilePath, size);
                FormCompleteMergeSortedArray(size);
            }
            else
            {
                throw new FileNotFoundException();
            }
        }
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
