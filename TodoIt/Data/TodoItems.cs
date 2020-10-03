using System;
using System.Linq;
using TodoIt.Model;

namespace TodoIt.Data
{
    public class TodoItems
    {
        static Todo[] allTodos = new Todo[0];

        public static int Size()
        {
            return allTodos.Length;
        }

        public static Todo[] FindAll()
        {
            return allTodos;
        }

        public static Todo FindById (int todoId)
        {
            return Array.Find(allTodos, i => i.TodoId == todoId);
        }

        public static Todo NewTodo(string userDescription)
        {
            int todoId = TodoSequencer.NextTodoID();
            Array.Resize(ref allTodos, allTodos.Length + 1);
            allTodos[allTodos.Length - 1] = new Todo(todoId, userDescription);
            return allTodos[allTodos.Length - 1];
        }

        public static void Clear()
        {
            allTodos = new Todo[0];
        }

        public static Todo[] FindByDoneStatus(bool doneStatus)
        {
            return Array.FindAll(allTodos, i => i.Done == doneStatus); // Using "i" lacks in descriptive power, but couldn't figure out what the range represented in reality
        }

        public static Todo[] FindByAssignee(int personId)
        {
            return Array.FindAll(allTodos, i => i.Assignee == personId);
        }

        public static Todo[] FindByAssignee(Person assignee)
        {
            return Array.FindAll(allTodos, i => i.Assignee == assignee.PersonId); 
        }

        public static Todo[] FindAllUnassignedTodoItems()
        {
            return Array.FindAll(allTodos, i => i.Assignee == 0);
        }

        public static void RemoveObject(int todoId)
        {
            int indexNumber = Array.FindIndex(allTodos, i => i.TodoId == todoId);
            allTodos = allTodos.Where((val, index) => index != indexNumber).ToArray();
        }
    }
}
