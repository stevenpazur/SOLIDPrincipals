using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace App.Tests
{
    public class TodoListTest
    {
        [Fact]
        public void itManagesCompletablesCorrectly()
        {
            var reminder1 = new Reminder(
                "Buy birthday hats",
                new DateTime(2028, 6, 7, 6, 9, 0));

            var todo1 = new Todo("Do stuff", new Owner("Alex", "Hamilton", "alex@example.com", "Treasurer"));

            var todoList = new TodoList();

            todoList.add(reminder1);
            todoList.add(todo1);

            todoList.all().Should().ContainInOrder(new List<ICompletable> { reminder1, todo1 });
            todoList.uncompleted().Should().ContainInOrder(new List<ICompletable> { reminder1, todo1 });
            todoList.completed().Should().BeEmpty();

            reminder1.markComplete();

            todoList.all().Should().ContainInOrder(new List<ICompletable> { reminder1, todo1 });
            todoList.uncompleted().Should().ContainInOrder(new List<ICompletable> { todo1 });
            todoList.completed().Should().ContainInOrder(new List<ICompletable> { reminder1 });

            todoList.completeAll();

            todoList.all().Should().ContainInOrder(new List<ICompletable> { reminder1, todo1 });
            todoList.uncompleted().Should().BeEmpty();
            todoList.completed().Should().ContainInOrder(new List<ICompletable> { reminder1, todo1 });

            todoList.uncompleteAll();

            todoList.all().Should().ContainInOrder(new List<ICompletable> { reminder1, todo1 });
            todoList.uncompleted().Should().ContainInOrder(new List<ICompletable> { reminder1, todo1 });
            todoList.completed().Should().BeEmpty();
        }

        [Fact]
        public void itShouldPopulateList()
        {
            //Given
            var owner = new Owner("Jack", "Sparrow", "jack@jack.net", "pirate");
            var todo1 = new Todo("Happy birthday", owner);
            var todoList = new TodoList();
            //When
            todoList.add(todo1);
            //Then
            todoList.ToString().Should().Be("□ Happy birthday\n");
        }
    }
}