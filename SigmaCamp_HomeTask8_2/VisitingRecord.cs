using System;
using System.Collections.Generic;
using System.Linq;

namespace SigmaCamp_HomeTask8_2
{
    internal class VisitingRecord
    {
        public readonly string IP;
        private List<(TimeSpan timeOfVisit, DayOfWeek dayOfVisit)> _visits;
        public VisitingRecord()
        {
            IP = "000.000.000.000";
            _visits = new List<(TimeSpan timeOfVisit, DayOfWeek dayOfVisit)> ();
        }
        public VisitingRecord(string ip, string time, string day):this()
        {
            IP = ip;
            AddVisit (time, day);
        }
        public void AddVisit(string time, string day)
        {
            TimeSpan visitTime;
            DayOfWeek visitDay;
            if (TimeSpan.TryParse(time, out visitTime) && Enum.TryParse(day, true, out visitDay))
            {
                _visits.Add((visitTime, visitDay));
            }
            else
            {
                throw new FormatException("Incorrect format of visit time or day");
            }
        }
        public List<(TimeSpan timeOfVisit, DayOfWeek dayOfVisit)> GetVisits()
        {
            return _visits;
        }
        public int GetNumberOfVisits()
        {
            return _visits.Count;
        }
        public string GetMaxVisitingDay()
        {
            int maxVisitNumber = 0;
            string maxVisitDay = string.Empty;
            foreach (var day in Enum.GetValues(typeof(DayOfWeek)))
            {
                int visitNumber = 0;
                visitNumber = _visits.Where(visit => visit.dayOfVisit == (DayOfWeek)day).Count();
                if (visitNumber > maxVisitNumber)
                {
                    maxVisitDay = ((DayOfWeek)day).ToString();
                    maxVisitNumber = visitNumber;
                }
            }
            return string.Format("{0,-15} | {1, -20} | {2, -6}\n", IP, maxVisitDay, maxVisitNumber);
        }
        public (int Hour, int Times) GetMaxVisitingHour()
        {
            int maxVisitNumber = 0;
            int maxVisitHour = 0;
            for (int hour = 0; hour < 24; hour++)
            {
                int visitNumber = 0;
                visitNumber = _visits.Where(visit => visit.timeOfVisit.Hours == hour).Count();
                if (visitNumber > maxVisitNumber)
                {
                    maxVisitHour = hour;
                    maxVisitNumber = visitNumber;
                }
            }
            return (maxVisitHour, maxVisitNumber);
        }
    }
}
