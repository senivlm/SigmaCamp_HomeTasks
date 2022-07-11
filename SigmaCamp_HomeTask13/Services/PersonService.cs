
using SigmaCamp_HomeTask13.Data;
using System;
using System.Collections.Generic;
using System.IO;
namespace SigmaCamp_HomeTask13.Services
{
    static internal class PersonService
    {
        static public List<Person> ReadPersons(string filePath = "../../../Persons.txt")
        {
            Reader reader = new Reader(filePath);
            List<Person> persons = new List<Person>();
            List<string> stringPersons = reader.ReadAllLines();

            foreach (var person in stringPersons)
            {
                persons.Add(PersonsParser.Parse(person));
            }
            return persons;
        }
        static public Person GeneratePerson(int maxAge)
        {
            Random random = new Random();
            var statusValues = Enum.GetValues(typeof(PersonStatus));
            PersonStatus status = (PersonStatus)statusValues.GetValue(random.Next(0, statusValues.Length));
            return new Person($"Passanger{Guid.NewGuid().ToString()[0..3]}", status.ToString(), random.Next(1, maxAge),
                Math.Round((double)random.Next(1, 100) / 5), random.Next(1, 10));
        }
        static public void WriteRandomGenerate(string fileName, int number, int maxAge)
        {
            File.WriteAllText(fileName, string.Empty);
            for (int i = 0; i < number; i++)
            {
                Writer<Person> writer = new(fileName);
                writer.Write(GeneratePerson(maxAge));
            }
        }
    }
}
