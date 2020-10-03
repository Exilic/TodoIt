using System;
namespace TodoIt.Data
{
    public class TodoSequencer
    {
        static int todoId;

        public static int NextTodoID()
        {
            return ++todoId; // todoId ranging from 1 and up -- personId on first occasion is 0
        }

        public static void Reset()
        {
            todoId = 0;
        }
    }
}
