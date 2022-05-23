using System;

namespace SigmaCamp_HomeTask3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector myVector = new Vector(9);
            myVector.InitRandom(1, 5);
            try
            {
                for (int i = 0; i < myVector.GetLength()/2; i++)
                {
                    myVector[i] = i;
                    myVector[myVector.GetLength() - 1 - i] = i;
                }
                Console.WriteLine(myVector);
                //foreach (var item in myVector.CalculateFrequency())
                //{
                //    Console.WriteLine(item);
                //}
                //Pair pair1 = new Pair(2,5);
                //Pair pair2 = new Pair(2,5);
                //Console.WriteLine(pair1.Equals(pair2));
                if (myVector.CheckForPalindrome())
                {
                    Console.WriteLine("This array is palindrome");
                }

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
