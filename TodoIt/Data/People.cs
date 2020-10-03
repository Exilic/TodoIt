using System;
using System.Collections.Generic;
using System.Linq;
using TodoIt.Model;

namespace TodoIt.Data
{
    public class People
    {
        
        static Person[] allPersons = new Person[0]; 

        public static int Size()
        {
            return allPersons.Length;
        }

        public static Person[] FindAll() 
        {
            return allPersons;
        }

        public static Person FindById(int personId) 
        {
            return Array.Find(allPersons, i => i.PersonId == personId);
        }

        public static Person NewPerson(string userFirstName, string userLastName)
        {
            int personId = PersonSequencer.NextPersonId();
            Array.Resize(ref allPersons, allPersons.Length + 1);
            allPersons[allPersons.Length - 1] = new Person(personId, userFirstName, userLastName);
            return allPersons[allPersons.Length - 1];
        }

         public static void Clear()
        {
            allPersons = new Person[0]; // Array.Clear produced an error. Therefore this construction.
        }

        public static void RemoveObject(int personId)
        {
            int indexNumber = Array.FindIndex(allPersons, i => i.PersonId == personId);
            allPersons = allPersons.Where((val, index) => index != indexNumber).ToArray();
        }


    }
}