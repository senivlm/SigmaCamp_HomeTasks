using System;
using System.Collections.Generic;
using System.IO;
namespace SigmaCamp_HomeTask6
{
    static internal class GeneralRecord
    {
        private const decimal priceFor1kWh = 1.44m;
        private static Dictionary<Person, List<ConsumptionRecord>> PersonRecords;
        private static int _numberOfRooms;
        private static int _quarter;
        public static void ReadFromFile(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    PersonRecords = new Dictionary<Person, List<ConsumptionRecord>>();
                    string[] firstLine = sr.ReadLine().Split(' ');
                    _numberOfRooms = int.Parse(firstLine[0]);
                    _quarter = int.Parse(firstLine[1]);
                    while (sr.ReadLine() is string line)
                    {
                        string[] recordParts = line.Split(' ');
                        int room, startValue, endValue;
                        if (int.TryParse(recordParts[0], out room) && int.TryParse(recordParts[2], out startValue) && int.TryParse(recordParts[3], out endValue))
                        {
                            bool isExists = false;
                            foreach (var person in PersonRecords.Keys)
                            {                          
                                if (person.Surname == recordParts[1])
                                {
                                    isExists = true;
                                    break;
                                }
                            }
                            if (!isExists)
                            {
                                Person person = new Person(recordParts[1], room);
                                PersonRecords.Add(person, new List<ConsumptionRecord>());
                                PersonRecords[person].Add(new ConsumptionRecord(recordParts[4], startValue, endValue, _quarter));
                            }
                            else
                            {
                                PersonRecords[FindPerson(recordParts[1], room)].Add(new ConsumptionRecord(recordParts[4], startValue, endValue, _quarter));
                            }
                        }
                        else
                        {
                            throw new FormatException("Incorrect format of record");
                        }
                    }
                }
            }
            else
            {
                throw new FileNotFoundException($"File is not found at this {path} path");
            }
        }
        static public Person FindPerson(string surname, int room)
        {
            foreach (var person in PersonRecords.Keys)
            {
                if (person.Surname.Equals(surname) && person.Room.Equals(room))
                {
                    return person;
                }
            }
            return null;
        }
        static public int GetQuarter()
        {
            return _quarter;
        }
        static string[] GetMonths()
        {
            string[] months = new string[3];
            foreach (var personRecord in PersonRecords)
            {
                int i = 0 ;
                foreach (ConsumptionRecord record in personRecord.Value)
                {
                    months[i] = record.GetMonthName();
                    i++;
                }
                return months;
            }
            return null;
        }
        static public void GetFullInfo(string outputPath)
        {
            using (StreamWriter sw = new StreamWriter(outputPath))
            {
                string months = "|";
                foreach (string month in GetMonths())
                {
                    months += " " + string.Format("{0, -9}", month) + " |";
                }
                sw.WriteLine("Room | " + string.Format("{0,-11}", "Surname") +  months + "TotalDebt |");
                sw.WriteLine("-----|------------|-----------|-----------|-----------|----------|");
                foreach (KeyValuePair<Person, List<ConsumptionRecord>> personRecord in PersonRecords)
                {
                    string line = string.Format("{0, -4} | {1, -10} |", personRecord.Key.Room, personRecord.Key.Surname);
                    foreach (ConsumptionRecord record in personRecord.Value)
                    {
                        line += string.Format(" {0, -9} |", record.EndCounterValue - record.StartCounterValue);
                    }
                    line += string.Format(" {0, -8:0.##} |", CountExpense(personRecord));
                    sw.WriteLine(line);
                }
            }
        }
        static public string GetTheBiggestDebtor()
        {
            var e = PersonRecords.GetEnumerator();
            e.MoveNext();
            var maxDebtor = e.Current;
            int maxValue = 0;
            string maxDebtorSurname = maxDebtor.Key.Surname;
            foreach (ConsumptionRecord record in maxDebtor.Value)
            {
                maxValue += record.EndCounterValue - record.StartCounterValue;   
            }
            foreach (KeyValuePair<Person, List<ConsumptionRecord>> personRecord in PersonRecords)
            {
                int currentValue = 0;
                foreach (ConsumptionRecord record in personRecord.Value)
                {
                    currentValue += record.EndCounterValue - record.StartCounterValue;
                }
                if (currentValue*priceFor1kWh > maxValue*priceFor1kWh)
                {
                    maxValue = currentValue;
                    maxDebtorSurname = personRecord.Key.Surname;
                }
            }
            return maxDebtorSurname;
        }
        static public string GetInfoAboutRoom(int room)
        {
            string roomInfo = string.Empty;
            if (room <= 0)
            {
                throw new ArgumentException("Incorrect value for room");
            }
            foreach (KeyValuePair<Person, List<ConsumptionRecord>> personRecord in PersonRecords)
            {
                if (personRecord.Key.Room == room)
                {
                    roomInfo += $"Info about {room} room:\n";
                    roomInfo += $"\tOwder: {personRecord.Key.Surname}\n";
                    foreach (ConsumptionRecord record in personRecord.Value)
                    {
                        roomInfo += $"\t{record}\n";
                    }
                    return roomInfo;
                }
            }
            return null;
        }
        static public int GetNotOccupiedRoom()
        {
            foreach (KeyValuePair<Person, List<ConsumptionRecord>> personRecord in PersonRecords)
            {
                int currentValue = 0;
                foreach (ConsumptionRecord record in personRecord.Value)
                {
                    currentValue += record.EndCounterValue - record.StartCounterValue;
                }
                if (currentValue == 0)
                {
                    return personRecord.Key.Room;
                }
            }
            return 0;
        }
        static public decimal CountExpense(KeyValuePair<Person, List<ConsumptionRecord>> personRecord)
        {
            int totalValue = 0;
            decimal totalExpenses = 0.0m;
            foreach (ConsumptionRecord record in personRecord.Value)
            {
                totalValue += record.EndCounterValue - record.StartCounterValue;
            }
            totalExpenses = totalValue * priceFor1kWh;
            return totalExpenses;
        }
        static public string GetExpenses()
        {
            string infoExpenses = string.Empty;
            foreach (KeyValuePair<Person, List<ConsumptionRecord>> personRecord in PersonRecords)
            {
                infoExpenses += $"Expenses of {personRecord.Key.Surname} from {personRecord.Key.Room} room: {CountExpense(personRecord)}\n";
            }
            return infoExpenses;
        }
        static public string GetTimeFromLastRecord()
        {
            string lastRecords = string.Empty;
            foreach (KeyValuePair<Person, List<ConsumptionRecord>> personRecord in PersonRecords)
            {
                int i = 1;
                foreach (ConsumptionRecord record in personRecord.Value)
                {
                    if (i==personRecord.Value.Count)
                    {
                        lastRecords += $"{personRecord.Key.Surname} last time metered electricity {Math.Round(DateTime.Now.Subtract(record.Date).TotalDays)} days ago\n";
                    }
                    i++;
                }
            }
            return lastRecords;
        }
    }
}
