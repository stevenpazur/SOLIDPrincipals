using System;
using Xunit;
using System.Collections.Generic;
using FluentAssertions;

namespace App.Tests
{
    public class TodoListTest
    {
        [Fact]
        public void itManagesCompletablesCorrectly() {
            Reminder reminder1 = new Reminder(
                    "Buy birthday hats",
                    new DateTime(2028, 6, 7, 6, 9, 0));

            Todo todo1 = new Todo("Do stuff", new Owner("Alex", "Hamilton", "alex@example.com", "Treasurer"));

            TodoList todoList = new TodoList();

            todoList.add(reminder1);
            todoList.add(todo1);

            todoList.all().Should().ContainInOrder(new List<ICompletable>{reminder1, todo1});
            todoList.uncompleted().Should().ContainInOrder(new List<ICompletable>{reminder1, todo1});
            todoList.completed().Should().BeEmpty();

            reminder1.markComplete();

            todoList.all().Should().ContainInOrder(new List<ICompletable>{reminder1, todo1});
            todoList.uncompleted().Should().ContainInOrder(new List<ICompletable>{todo1});
            todoList.completed().Should().ContainInOrder(new List<ICompletable>{reminder1});

            todoList.completeAll();

            todoList.all().Should().ContainInOrder(new List<ICompletable>{reminder1, todo1});
            todoList.uncompleted().Should().BeEmpty();
            todoList.completed().Should().ContainInOrder(new List<ICompletable>{reminder1, todo1});

            todoList.uncompleteAll();

            todoList.all().Should().ContainInOrder(new List<ICompletable>{reminder1, todo1});
            todoList.uncompleted().Should().ContainInOrder(new List<ICompletable>{reminder1, todo1});
            todoList.completed().Should().BeEmpty();
        }
    }
}
