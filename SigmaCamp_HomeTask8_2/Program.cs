using System;
using System.IO;
namespace SigmaCamp_HomeTask8_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SiteStats.ReadVisits("Visits.txt");
                //Console.WriteLine(SiteStats.GetNumberOfVisitsByIPs());
                //Console.WriteLine(SiteStats.GetTheMostPopularDays());
                Console.WriteLine(SiteStats.GetMostPopularHours());
                Console.WriteLine(SiteStats.GetMostPopularHour());
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
