using System;

namespace SigmaCamp_HomeTask3
{
    internal class Vector
    {
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
        public override string ToString()
        {
            string stringArr = "";
            foreach (var item in arr)
            {
                stringArr += item + " ";
            }
            return stringArr;
        }
    }
}
