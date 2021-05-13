using System;
using System.Collections.Generic;

namespace App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var defaultDuration = new TimeSpan(1, 0, 0);
            Event event1 = new Event("Event 1", new DateTime(2017, 1, 3, 4, 4, 0), defaultDuration);
            Event event2 = new Event("Event 2", new DateTime(2017, 1, 3, 5, 5, 0), defaultDuration);
            Event event3 = new Event("Event 3", new DateTime(2017, 1, 12, 5, 5, 0), defaultDuration);
            Reminder reminder1 = new Reminder("Reminder 1", new DateTime(2017, 3, 17, 4, 4, 1));
            reminder1.markComplete();
            Todo todo1 = new Todo("Do stuff", "Alex", "Hamilton", "alex@example.com", "Treasurer");

            MonthlyFormatter monthlyFormatter = new MonthlyFormatter();
            ScheduleFormatter scheduleFormatter = new ScheduleFormatter();

            Calendar calendar = new Calendar();
            calendar.addSchedulable(event1);
            calendar.addSchedulable(event2);
            calendar.addSchedulable(reminder1);
            calendar.addSchedulable(event3);

            Console.WriteLine("------------------\nCalendar View:\n------------------\n");
            Console.WriteLine(monthlyFormatter.format(calendar));

            Console.WriteLine("------------------\nSchedule View:\n------------------\n");
            Console.WriteLine(scheduleFormatter.format(calendar));

            // this shows how the TodoList works
            Console.WriteLine("-------------------\nTodo List:\n-------------------\n");
            TodoList todoList = new TodoList();
            todoList.add(todo1);
            todoList.add(reminder1);
            Console.WriteLine(todoList.ToString());

            // this shows how the export service works
            Console.WriteLine("-------------------\niCalendar Export:\n-------------------\n");
            List<CalendarItem> items = new List<CalendarItem>{event1, event2, todo1, reminder1, event3};
            ExportService exporter = new ExportService();
            Console.WriteLine(exporter.export(items));
        }
    }
}
