using System;

namespace SigmaCamp_HomeTask8_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(65001);
            try
            {
                GeneralRecord myRecords1 = new GeneralRecord("../../../ConsumedElectricity1.txt");
                GeneralRecord myRecords2 = new GeneralRecord("../../../ConsumedElectricity2.txt");
                myRecords1.GetFullInfo("../../../Report1.txt");
                myRecords1 -= myRecords2;
                myRecords1.GetFullInfo("../../../Report1.1.txt");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Console.WriteLine($"The biggest deptor is {GeneralRecord.GetTheBiggestDebtor()}");
            //int notOccupiedRoom = GeneralRecord.GetNotOccupiedRoom();
            //if (notOccupiedRoom != 0)
            //{
            //    Console.WriteLine($"{notOccupiedRoom} room hasn't been used no electricity thoughout {GeneralRecord.GetQuarter()} quarter");
            //}
            //Console.WriteLine(GeneralRecord.GetInfoAboutRoom(17) ?? "There is no info about such room");
            //Console.WriteLine(GeneralRecord.GetTimeFromLastRecord());
        }
    }
}
