using System;
using TodoIt.Data;

namespace TodoIt.Model

{
    public class Person
    {
        //a. Required private fields are personId (int and readonly), firstName and lastName (String).
        //b. Make a constructor that can build the object.
        //c. Use Properties to prevent names from saving NULL & Empty

        readonly int personId;
        string firstName;
        string lastName;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("First name field cannot be empty");
                else firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new ArgumentException("Last name field cannot be empty");
                else lastName = value;
            }
        }

        // personId is readonly
        public int PersonId
        {
            get { return personId; }
        }

        // As it is now, personId could be entered without involving PersonSequencer. So double personId could happen. 
        public Person(int personId, string firstName, string lastName)
        {
            this.personId = personId;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
