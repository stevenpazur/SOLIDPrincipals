using System;
using System.Collections.Generic;
using App.models;

namespace App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var defaultDuration = new TimeSpan(1, 0, 0);
            var event1 = new Event("Event 1", new DateTime(2017, 1, 3, 4, 4, 0), defaultDuration);
            var event2 = new Event("Event 2", new DateTime(2017, 1, 3, 5, 5, 0), defaultDuration);
            var event3 = new Event("Event 3", new DateTime(2017, 1, 12, 5, 5, 0), defaultDuration);
            var reminder1 = new Reminder(null, new DateTime(2017, 3, 17, 4, 4, 1));
            reminder1.markComplete();
            var owner = new Owner("Alex", "Hamilton", "alex@example.com", "Treasurer");
            var todo1 = new Todo("Do stuff", owner);
            var todo3 = new Todo(null, owner);
            var event4 = new Holiday("Event 4", new DateTime(2017, 2, 12, 5, 5, 0), defaultDuration);
            owner.ChangeFirstName("Harry");
            owner.ChangeLastName("Potter");

            var monthlyFormatter = new MonthlyFormatter();
            var scheduleFormatter = new ScheduleFormatter();

            var calendar = new Calendar();
            calendar.addSchedulable(event1);
            calendar.addSchedulable(event2);
            calendar.addSchedulable(reminder1);
            calendar.addSchedulable(event3);
            calendar.addSchedulable(event4);
            var dr = new MasterFormatterDr();
            dr._Formatter = new MonthlyFormatter();
            

            Console.WriteLine("------------------\nCalendar View:\n------------------\n");
            //Console.WriteLine(monthlyFormatter.format(calendar));
            Console.WriteLine(dr.format(calendar));
            Console.WriteLine("------------------\nSchedule View:\n------------------\n");
            dr._Formatter = new ScheduleFormatter();
            Console.WriteLine(dr.format(calendar));


            // this shows how the TodoList works
            Console.WriteLine("-------------------\nTodo List:\n-------------------\n");
            var todoList = new TodoList();
            todoList.add(todo1);
            todoList.add(reminder1);
            Console.WriteLine(todoList.ToString());

            // this shows how the export service works
            Console.WriteLine("-------------------\niCalendar Export:\n-------------------\n");
            List<CalendarItem> items = new() {event1, event2, todo1, reminder1, event3, event4, todo3};
            var exporter = new ExportService();
            Console.WriteLine(exporter.export(items));
        }
    }
}