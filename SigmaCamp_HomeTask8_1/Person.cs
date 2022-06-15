using System;
using System.Collections.Generic;
namespace SigmaCamp_HomeTask6
{
    internal class Person
    {

        int _room;
        readonly string _surname;
        public Person(string surname, int room)
        {
            _surname = surname;
            Room = room;
        }
        public int Room
        {
            get { return _room; }
            set
            {
                if (value > 0)
                {
                    _room = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect value for room");
                }
            }
        }
        public string Surname
        {
            get { return _surname; }
        }
    }
}
