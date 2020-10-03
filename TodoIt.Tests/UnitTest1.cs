using System;
using System.Collections.Generic;
using Xunit;
using TodoIt.Data;
using TodoIt.Model;


namespace TodoIt.Tests
{
    public class UnitTest1
    {

        // The four test of TodoItems:
        //FindByDoneStatus(bool doneStatus)
        //FindByAssignee(int personId)
        //FindByAssignee(Person assignee)
        //FindUnassignedTodoItems()
        //All of them could return null, which would cause problems. 

        [Fact]
        public void PersonConstructor()
        {
            //Arrange
            string firstName = "Stefan";
            string lastName = "Lund";
            int firstId = 1;

            //Act
            PersonSequencer.Reset();
            Person result = new Person(firstId, firstName, lastName);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(firstName, result.FirstName);
            Assert.Equal(lastName, result.LastName);
            Assert.Equal(firstId, result.PersonId);
        }

        [Fact]
        public void TodoConstructor()
        {
            //Arrange
            string todoDescription = "Text field";
            int firstId = 1;

            //Act
            TodoSequencer.Reset();
            Todo result = new Todo(firstId, todoDescription);

            //Assert
            Assert.Equal(todoDescription, result.Description);
            Assert.Equal(firstId, result.TodoId);
        }

        [Fact]
        public void TodoAssignee()
        {
            //Arrange
            var aNewPerson = People.NewPerson("Siv", "Karlsson");
            var aTodoInstance = TodoItems.NewTodo("We must empty the waste basket.");

            //Act
            aTodoInstance.Assignee = aNewPerson.PersonId;

            //Assert
            Assert.Equal(aNewPerson.PersonId, aTodoInstance.Assignee);
        }

        [Fact]
        public void NextNameIdIncrement()
        {
            //Arrange

            //Act
            int firstResult = PersonSequencer.NextPersonId() + 1;
            int secondResult = PersonSequencer.NextPersonId();

            //Assert
            Assert.Equal(firstResult, secondResult);

        }

        [Fact]
        public void NextTodoItIncrement()
        {
            //Arrange

            //Act
            int firstResult = TodoSequencer.NextTodoID() + 1;
            int secondResult = TodoSequencer.NextTodoID();

            //Assert
            Assert.Equal(firstResult, secondResult);
        }

        [Fact]
        public void ReturnSizePeople()
        {
            //Arrange

            //Act
            var valueBefore = People.Size();
            People.NewPerson("Hans", "Fall");
            var valueAfter = People.Size();

            //Assert
            Assert.Equal(valueBefore, valueAfter - 1);
        }

        [Fact]
        public void ReturnOfPersonArray()
        {
            //Arrange
            People.NewPerson("Siv", "Karlsson");
            People.NewPerson("Mats", "Larsson");

            //Act
            Person[] result = People.FindAll();
            var arrayLength = People.Size();

            //Assert
            Assert.Equal("Siv", result[arrayLength - 2].FirstName);
            Assert.Equal("Larsson", result[arrayLength - 1].LastName);

        }

        [Fact]
        public void FindIdPersonInPeople()
        {
            //Arrange
            People.NewPerson("Siv", "Karlsson");
            People.NewPerson("Mats", "Larsson");

            //Act
            var personReturned = People.FindById(2);

            //Assert
            Assert.Equal("Mats", personReturned.FirstName);
            Assert.Equal("Larsson", personReturned.LastName);
        }

        [Fact]
        public void AddingNewPerson()
        {
            //Arrange

            //Act
            var result = People.NewPerson("Stina", "Gladh");

            //Assert
            Assert.Equal("Stina", result.FirstName);
        }

        [Fact]
        public void ClearThePeopleArray()
        {
            //Arrange
            People.NewPerson("Siv", "Karlsson");
            People.NewPerson("Mats", "Larsson");

            //Act
            People.Clear();
            var resultArray = People.FindAll();
            var resultLength = People.Size();

            //Assert
            Assert.Empty(resultArray);
            Assert.Equal(0, resultLength);
        }

        [Fact]
        public void ReturnSiceTodoItems()
        {
            //Arrange

            //Act
            var valueBefore = TodoItems.Size();
            TodoItems.NewTodo("We must empty the waste basket.");
            var valueAfter = TodoItems.Size();

            //Assert
            Assert.Equal(valueBefore, valueAfter - 1);
        }

        [Fact]
        public void ReturnOfTodoArray()
        {
            //Arrange
            TodoItems.NewTodo("We must empty the waste basket.");
            TodoItems.NewTodo("Find a new venue.");

            //Act
            Todo[] result = TodoItems.FindAll();
            var arrayLength = TodoItems.Size();

            //Assert
            Assert.Equal("We must empty the waste basket.", result[arrayLength - 2].Description);
            Assert.Equal("Find a new venue.", result[arrayLength - 1].Description);

        }

        [Fact]
        public void FindIdTodoInTodoItems()
        {
            //Arrange
            TodoItems.NewTodo("We must empty the waste basket.");
            TodoItems.NewTodo("Find a new venue.");

            //Act
            var todoReturned = TodoItems.FindById(2);

            //Assert
            Assert.Equal("Find a new venue.", todoReturned.Description);

        }

        [Fact]
        public void AddingNewTodo()
        {
            //Arrange

            //Act
            var result = TodoItems.NewTodo("Pay the bill.");

            //Assert
            Assert.Equal("Pay the bill.", result.Description);

        }

        [Fact]
        public void ClearTheTodoItemsArray()
        {
            //Arrange
            TodoItems.NewTodo("We must empty the waste basket.");
            TodoItems.NewTodo("Find a new venue.");

            //Act
            TodoItems.Clear();
            var resultArray = TodoItems.FindAll();
            var resultLength = TodoItems.Size();

            //Assert
            Assert.Empty(resultArray);
            Assert.Equal(0, resultLength);

        }

        [Fact]
        public void AllDoneStatusFound()
        {
            //Arrange
            var firstTodo = TodoItems.NewTodo("We must empty the waste basket.");
            TodoItems.NewTodo("Find a new venue.");
            var thirdTodo = TodoItems.NewTodo("Pay the bill.");
            firstTodo.Done = true;
            thirdTodo.Done = true;

            //Act
            Todo[] doneTodos = TodoItems.FindByDoneStatus(true);

            //Assert
            Assert.Equal("Pay the bill.", doneTodos[1].Description);

        }

        [Fact]
        public void AllAssigneeStatusFoundById()
        {
            //Arrange
            var firstNewPerson = People.NewPerson("Siv", "Karlsson");
            var secondNewPerson = People.NewPerson("Mats", "Larsson");
            var firstTodo = TodoItems.NewTodo("We must empty the waste basket.");
            var secondTodo = TodoItems.NewTodo("Find a new venue.");
            var thirdTodo = TodoItems.NewTodo("Pay the bill.");
            firstTodo.Assignee = firstNewPerson.PersonId;
            thirdTodo.Assignee = secondNewPerson.PersonId;


            //Act
            Todo[] firstAssignee = TodoItems.FindByAssignee(firstNewPerson.PersonId);
            Todo[] secondAssignee = TodoItems.FindByAssignee(secondNewPerson.PersonId);


            //Assert
            Assert.Equal("We must empty the waste basket.", firstAssignee[firstAssignee.Length -1].Description);
            Assert.Equal("Pay the bill.", secondAssignee[secondAssignee.Length - 1].Description);
        }

        [Fact]
        public void AllAssigneeStatusFoundByPerson()
        {
            //Arrange
            var firstNewPerson = People.NewPerson("Siv", "Karlsson");
            var secondNewPerson = People.NewPerson("Mats", "Larsson");
            var firstTodo = TodoItems.NewTodo("We must empty the waste basket.");
            var secondTodo = TodoItems.NewTodo("Find a new venue.");
            var thirdTodo = TodoItems.NewTodo("Pay the bill.");
            firstTodo.Assignee = firstNewPerson.PersonId;
            thirdTodo.Assignee = secondNewPerson.PersonId;

            //Act
            Todo[] firstAssignee = TodoItems.FindByAssignee(firstNewPerson);
            Todo[] secondAssignee = TodoItems.FindByAssignee(secondNewPerson);

            //Assert
            Assert.Equal("We must empty the waste basket.", firstAssignee[firstAssignee.Length - 1].Description);
            Assert.Equal("Pay the bill.", secondAssignee[secondAssignee.Length - 1].Description);
        }

        [Fact]
        public void UnassignedTodoItemsFound()
        {
            //Arrange
            var firstNewPerson = People.NewPerson("Siv", "Karlsson");
            var secondNewPerson = People.NewPerson("Mats", "Larsson");
            var firstTodo = TodoItems.NewTodo("We must empty the waste basket.");
            var secondTodo = TodoItems.NewTodo("Find a new venue.");
            var thirdTodo = TodoItems.NewTodo("Pay the bill.");
            firstTodo.Assignee = firstNewPerson.PersonId;
            thirdTodo.Assignee = secondNewPerson.PersonId;

            //Act
            Todo[] unassignedTodoItems = TodoItems.FindAllUnassignedTodoItems();

            //Assert
            Assert.Equal("Find a new venue.", unassignedTodoItems[unassignedTodoItems.Length - 1].Description);
        }

        [Fact]
        public void RemoveObjectInPeople()
        {
            //Arrange
            var firstNewPerson = People.NewPerson("Siv", "Karlsson");
            var secondNewPerson = People.NewPerson("Mats", "Larsson");
            var thirdNewPerson = People.NewPerson("Kaj", "Fasth");
            var arraySizeBeforeRemoval = People.Size();

            //Act
            People.RemoveObject(secondNewPerson.PersonId);
            var arraySizeAfterRemoval = People.Size();
            Person isPersonIdRemoved = People.FindById(secondNewPerson.PersonId);

            //Assert
            Assert.Equal(arraySizeBeforeRemoval - 1, arraySizeAfterRemoval);
            Assert.Null(isPersonIdRemoved);
        }

        [Fact]
        public void RemoveObjectTodoItems()
        {
            //Arrange
            TodoItems.Clear();
            var firstTodo = TodoItems.NewTodo("We must empty the waste basket.");
            var secondTodo = TodoItems.NewTodo("Find a new venue.");
            var thirdTodo = TodoItems.NewTodo("Pay the bill.");
            var arraySizeBeforeRemoval = TodoItems.Size();

            //Act
            TodoItems.RemoveObject(secondTodo.TodoId);
            var arraySizeAfterRemoval = TodoItems.Size();
            Todo isTodoIdRemoved = TodoItems.FindById(secondTodo.TodoId);

            //Assert
            Assert.Equal(arraySizeBeforeRemoval - 1, arraySizeAfterRemoval);
            Assert.Null(isTodoIdRemoved);


        }

    }
}
