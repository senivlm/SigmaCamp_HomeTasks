using System;

namespace SigmaCamp_HomeTask6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(65001);
            GeneralRecord myRecords = new GeneralRecord("../../../ConsumedElectricity.txt");
            //Console.WriteLine($"The biggest deptor is {GeneralRecord.GetTheBiggestDebtor()}");
            //int notOccupiedRoom = GeneralRecord.GetNotOccupiedRoom();
            //if (notOccupiedRoom != 0)
            //{
            //    Console.WriteLine($"{notOccupiedRoom} room hasn't been used no electricity thoughout {GeneralRecord.GetQuarter()} quarter");
            //}
            //Console.WriteLine(GeneralRecord.GetInfoAboutRoom(17) ?? "There is no info about such room");
            myRecords.GetFullInfo("../../../Report.txt");
            //Console.WriteLine(GeneralRecord.GetTimeFromLastRecord());
        }
    }
}
