using System;
using System.IO;
namespace SigmaCamp_HomeTask3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector myVector = new Vector(10);
            myVector.InitRandom(1, 20);
            try
            {
                //string inputPath = @"C:\Users\Bogdan\OneDrive - Technical Lyceum NTUU KPI\Навчання\Sigma Camp\SigmaCamp_HomeTask1\SigmaCamp_HomeTask3\DataHomeTask5_input.txt";
                //Vector.GenerateDataToFile(inputPath);
                //SortMethods.MergeSortFromFile(inputPath);
                Console.WriteLine(myVector);
                SortMethods.HeapSort(myVector);
                Console.WriteLine(myVector);
                //for (int i = 0; i < myVector.GetLength()/2; i++)
                //{
                //    myVector[i] = i;
                //    myVector[myVector.GetLength() - 1 - i] = i;
                //}
                //Console.WriteLine("Initial array: \n" + myVector);
                //Console.WriteLine("\nSorted array with first element as pivot: \n" );
                //foreach (var item in SortMethods.QuickSort(myVector, 0, myVector.GetCopy().Length-1, "start"))
                //{
                //    Console.Write(item + " ");
                //}
                //Console.WriteLine("\nNumber of iterations: " + SortMethods.counter);
                //SortMethods.counter = 0;
                //myVector.InitRandom(1, myVector.GetLength() - 1);
                //Console.WriteLine("\nSorted array with mid element as pivot: \n");
                //foreach (var item in SortMethods.QuickSort(myVector, 0, myVector.GetCopy().Length - 1, "mid"))
                //{
                //    Console.Write(item + " ");
                //}
                //Console.WriteLine("\nNumber of iterations: " + SortMethods.counter);
                //SortMethods.counter = 0;
                //myVector.InitRandom(1, myVector.GetLength() - 1);
                //Console.WriteLine("\nSorted array with last element as pivot: \n");
                //foreach (var item in SortMethods.QuickSort(myVector, 0, myVector.GetCopy().Length - 1, "end"))
                //{
                //    Console.Write(item + " ");
                //}
                //Console.WriteLine("\nNumber of iterations: " + SortMethods.counter);
                //foreach (var item in myVector.CalculateFrequency())
                //{
                //    Console.WriteLine(item);
                //}
                //Pair pair1 = new Pair(2,5);
                //Pair pair2 = new Pair(2,5);
                //Console.WriteLine(pair1.Equals(pair2));
                //if (myVector.CheckForPalindrome())
                //{
                //    Console.WriteLine("This array is palindrome");
                //}
                //myVector.Reverse();
                //Console.WriteLine($"Result of my reverse method: {myVector}");
                //myVector.BuiltInReverse();
                //Console.WriteLine($"Result of built-in reverse method: {myVector}");
                //Console.WriteLine(myVector.GetLongestSequence());
                //Console.WriteLine(myVector);

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
