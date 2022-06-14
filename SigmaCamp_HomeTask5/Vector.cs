using System;
using System.IO;
using System.Collections;
namespace SigmaCamp_HomeTask3
{
    internal class Vector:IEnumerable
    {
        static int counter = 0;
        int[] arr;
        public Vector() : this(10) { }
        public Vector(int size)
        {
            arr = new int[size];
        }
        public int this[int index]
        {
            get
            {
                if (index<0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return arr[index];
            }
            set
            {
                arr[index] = value;
            }
        }
        public int GetLength()
        {
            return arr.Length;
        }
        public void InitRandom(int a, int b)
        {
            Random randomInt = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = randomInt.Next(a, b);
            }
        }
        public void InitShuffle()
        {
            Random randomInt = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = 0;
                bool isInit = false;
                do
                {
                    int r = randomInt.Next(1, arr.Length + 1);
                    if (Array.IndexOf(arr, r) < 0)
                    {
                        arr[i] = r;
                        isInit = true;
                    }
                } while (!isInit);
            }

        }
        public static void GenerateDataToFile(string path, int size = 100)
        {
            Random randInt = new Random();
            using(StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < size; i++)
                {
                    sw.WriteLine(randInt.Next(1, size * 10));
                }
            }
        }
        public Pair[] CalculateFrequency()
        {
            Pair[] pairs = new Pair[arr.Length];
            for (int i = 0; i < pairs.Length; i++)
            {
                pairs[i] = new Pair();
            }
            int countDifference = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if (arr[i]==pairs[j].Number)
                    {
                        pairs[j].Frequency++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDifference].Frequency++;
                    pairs[countDifference].Number = arr[i];
                    countDifference++;
                }
            }
            Array.Resize<Pair>(ref pairs, countDifference);
            return pairs;
        }
        public bool CheckForPalindrome()
        {
            bool isPalindrome = false;
            for (int i = 0, j = arr.Length-1; i < arr.Length/2; i++, j--)
            {
                if (arr[i]==arr[j])
                {
                    isPalindrome = true;
                }
                else
                {
                    isPalindrome = false;
                    break;
                }

            }
            return isPalindrome;           
        }
        public void Reverse()
        {
            for (int i = 0; i < arr.Length/2; i++)
            {
                int temp = arr[i];
                arr[i] = arr[arr.Length-1-i];
                arr[arr.Length-1-i] = temp;
            }
        }
        public void BuiltInReverse()
        {
            Array.Reverse(arr);
        }
        public string GetLongestSequence()
        {
            string currentSequence = string.Empty;
            string maxSequence = string.Empty;
            for (int i = 0; i < arr.Length; i++)
            {
                currentSequence = arr[i].ToString();
                for (int j = i+1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                    {
                        currentSequence += " " + arr[j];
                        if (currentSequence.Length >= maxSequence.Length)
                        {
                            maxSequence = currentSequence;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return maxSequence;
        }

        public int[] GetCopy()
        {
            int[] copy = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                copy[i] = arr[i];
            }
            return copy;
        }
        public override string ToString()
        {
            string stringArr = "";
            foreach (var item in arr)
            {
                stringArr += item + " ";
            }
            return stringArr;
        }

        public IEnumerator GetEnumerator()
        {
            return arr.GetEnumerator();
        }
    }
}
