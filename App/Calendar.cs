using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    public class Calendar
    {
        //Holiday
        private List<CalendarItem> schedulables = new();
        //when we make a new class called holiday, we extend calendar item and we will not have to modify anything on calendar 
        //and any other class besides holiday

        public void addSchedulable(CalendarItem schedulable)
        {
            schedulables.Add(schedulable);
            schedulables = schedulables.OrderBy(s => getLocalDateTime(s)).ToList();
        }

        public List<CalendarItem> items()
        {
            return schedulables;
        }

        public List<DateTime?> dates()
        {
            return schedulables.Select(s => getLocalDateTime(s)).ToList();
        }

        public List<string> descriptionsFor(DateTime date)
        {
            return schedulables.Where(s => getLocalDateTime(s).Value == date).Select(s => s.ToString()).ToList();
        }

        public DateTime? getFirstDateTime()
        {
            if (schedulables.Count == 0) return null;
            var item = schedulables.First();
            return getLocalDateTime(item);
        }

        public DateTime? getLastDateTime()
        {
            if (schedulables.Count == 0) return null;
            var item = schedulables.Last();
            return getLocalDateTime(item);
        }

        public string format()
        {
            var formatter = new MonthlyFormatter();
            return formatter.format(this);
        }

        private DateTime? getLocalDateTime(CalendarItem item)
        {
            var isEvent = item is Event;
            var isReminder = item is Reminder;

            if (isEvent)
                return ((Event) item).getStartsAt();
            if (isReminder) return ((Reminder) item).getRemindsAt();

            return null;
        }
    }
}