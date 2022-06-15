using System;
using System.Collections.Generic;
namespace SigmaCamp_HomeTask8_1
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
            init
            {
                if (value!= null)
                {
                    _surname = value;
                }
                throw new ArgumentNullException("Surname can't be null");
            }
        }
        public override bool Equals(object obj)
        {
            if (obj != null && !(obj is Person))
            {
                return false;
            }
            Person anotherPerson = (Person)obj;
            return this.Room.Equals(anotherPerson.Room) && this.Surname.Equals(anotherPerson.Surname);
        }
        public override int GetHashCode()
        {
            return Room.GetHashCode() ^ Surname.GetHashCode();
        }
    }
}
