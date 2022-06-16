using System;

namespace SigmaCamp_HomeTask8_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SiteStats.ReadVisits("Visits.txt");
            //Console.WriteLine(SiteStats.GetNumberOfVisitsByIPs());
            //Console.WriteLine(SiteStats.GetTheMostPopularDays());
            Console.WriteLine(SiteStats.GetMostPopularHours());
            Console.WriteLine(SiteStats.GetMostPopularHour());
        }
    }
}
