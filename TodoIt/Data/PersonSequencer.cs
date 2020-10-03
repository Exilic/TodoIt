using System;
using TodoIt.Model;

namespace TodoIt.Data
{
    public class PersonSequencer
    {
        //a. In PersonSequencer creates a private static int variable called personId.
        //b. Add a static method called nextPersonId that increment and return the next personId value.
        //c. Add a static method called reset() that sets the personId variable to 0. 

        static int personId;

        public static int NextPersonId()
        {
            return ++personId; // personId ranging from 1 and up -- personId on first occasion is 0
        }

        public static void Reset()
        {
            personId = 0;
        }


    }
}
