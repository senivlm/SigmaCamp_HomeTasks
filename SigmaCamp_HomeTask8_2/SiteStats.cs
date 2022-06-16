using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SigmaCamp_HomeTask8_2
{
    internal static class SiteStats
    {
        private static List<VisitingRecord> visitsByIPs;
        public static void ReadVisits(string fileName)
        {
            string path = "../../../" + fileName;
            visitsByIPs = new List<VisitingRecord>();
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] visitParts = sr.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        int index = visitsByIPs.FindIndex(x => x.IP == visitParts[0]);
                        if (index != -1)
                        {
                            visitsByIPs[index].AddVisit(visitParts[1], visitParts[2]);
                        }
                        else
                        {
                            visitsByIPs.Add(new VisitingRecord(visitParts[0], visitParts[1], visitParts[2]));
                        }
                    }
                }
            }
            else
            {
                throw new FileNotFoundException($"File is not found at this {path} path");
            }
        }
        public static string GetNumberOfVisitsByIPs()
        {
            string info = string.Empty;
            foreach (VisitingRecord visitsByIP in visitsByIPs)
            {
                info += $"{visitsByIP.IP}: {visitsByIP.GetNumberOfVisits()}\n";
            }
            return info;
        }
        public static string GetTheMostPopularDays()
        {
            string maxVisitDaysInfo = string.Format("{0,-15} | The most popular day | Visits\n", "IP");
            foreach (VisitingRecord visitsByIP in visitsByIPs)
            {
                maxVisitDaysInfo += visitsByIP.GetMaxVisitingDay();
            }
            return maxVisitDaysInfo;
        }
        public static string GetMostPopularHours()
        {
            string maxVisitHoursInfo = string.Format("{0,-15} | The most popular time | Visits\n", "IP");
            foreach (VisitingRecord visitsByIP in visitsByIPs)
            {
                var maxVisitHour = visitsByIP.GetMaxVisitingHour();
                maxVisitHoursInfo += string.Format("{0,-15} | {1, -2} - {2,-16} | {3, -6}\n", visitsByIP.IP, maxVisitHour.Hour, maxVisitHour.Hour + 1, maxVisitHour.Times);
            }
            return maxVisitHoursInfo;
        }
        public static string GetMostPopularHour()
        {
            List<(int, int)> maxVisitingHours = new List<(int, int)>();
            foreach (VisitingRecord visitsByIP in visitsByIPs)
            {
                maxVisitingHours.Add(visitsByIP.GetMaxVisitingHour());
            }
            var maxVisitingHoursGrouped = maxVisitingHours.GroupBy(maxHour => maxHour.Item1).Select(g => new { Value = g.Key, TotalHours = g.Sum(hourTimes => hourTimes.Item2)});
            var maxVisitingHour = maxVisitingHoursGrouped.OrderByDescending(timesInHour => timesInHour.TotalHours).First();
            return $"The most popular hour to visit site is {maxVisitingHour.Value}. It was visited {maxVisitingHour.TotalHours} times at this time.";
        }
    }
}
