using System;
using TodoIt.Data;

namespace TodoIt.Model
{
    public class Todo
    {
        //a.Required private fields are todoId(int and readonly), description(String), done(bool) and assignee(Person).
        //b.Make a constructor that take in todoId(int) and a description(String).


        readonly int todoId;
        string description;
        bool done;
        int assignee;

        public string Description
        {
            get { return description; }
            set { description = value; } // No need to filter editing of descritions
        }

        public int Assignee
        {
            get { return assignee; }
            set             // Only registered persons should be able to assign as assignees
            {
                if (Array.Exists(People.FindAll(), persons => persons.PersonId == value))
                    { assignee = value; }
                else
                    { throw new ArgumentException("Person proposed as assignee has not been registered."); }
            } 
        }

        public int TodoId
        {
            get { return todoId; } //todoId is readonly
        }

        public bool Done
        {
            get { return done; }
            set { done = value; } // No need to filter the setting of done status
        }

        // The user could wish to enter assignee on the same occasion as entering a description, but that
        // functionality could be solved better in the user interface (first constructor, then immediately set assignee) 
        public Todo(int todoId, string description)
        {
            this.todoId = todoId;
            this.description = description;

        }
    }
}
