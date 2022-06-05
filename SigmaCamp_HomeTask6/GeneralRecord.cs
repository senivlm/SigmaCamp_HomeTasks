using System;
using System.Collections.Generic;
using System.IO;
namespace SigmaCamp_HomeTask6
{
    static internal class GeneralRecord
    {
        private static Dictionary<Person, List<ConsumptionRecord>> PersonRecords;
        private static int _numberOfRooms;
        private static int _quartal;
        public static void ReadFromFile(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    PersonRecords = new Dictionary<Person, List<ConsumptionRecord>>();
                    string[] firstLine = sr.ReadLine().Split(' ');
                    _numberOfRooms = int.Parse(firstLine[0]);
                    _quartal = int.Parse(firstLine[1]);
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
                                PersonRecords[person].Add(new ConsumptionRecord(recordParts[4], startValue, endValue, _quartal));
                            }
                            else
                            {
                                PersonRecords[FindPerson(recordParts[1], room)].Add(new ConsumptionRecord(recordParts[4], startValue, endValue, _quartal));
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
    }
}
