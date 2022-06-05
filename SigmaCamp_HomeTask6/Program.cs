using System;

namespace SigmaCamp_HomeTask6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GeneralRecord.ReadFromFile("../../../ConsumedElectricity.txt");
            GeneralRecord.DisplayRecords();
        }
    }
}
