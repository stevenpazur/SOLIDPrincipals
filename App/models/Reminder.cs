using System;
using System.Text;

namespace App
{
    public class Reminder : CalendarItem, ICompletable, IGetStartsAt
    {
        private bool complete;
        private readonly DateTime remindsAt;
        //TODO change title to Description
        public string description { get; set; }

        public Reminder(string description, DateTime remindsAt)
        {
            this.description = description;
            this.remindsAt = remindsAt;
        }

        public string getTitle()
        {
            return description;
        }
        public DateTime getStartsAt()
        {
            return remindsAt;
        }

        public bool isComplete()
        {
            return complete;
        }

        public void markComplete()
        {
            complete = true;
        }

        public void markIncomplete()
        {
            complete = false;
        }

        public override string iCalendar()
        {
            if (description == null) return "";

            return new StringBuilder()
                .Append("BEGIN:VALARM\n")
                .Append($"TRIGGER:-{getStartsAt().ToString("yyyy-MM-ddThh:mm")}\n")
                .Append("ACTION:DISPLAY\n")
                .Append($"UID:{getUuid()}@example.com\n")
                .Append($"DESCRIPTION:{getTitle()}\n")
                .Append("END:VALARM\n")
                .ToString();
        }

        public override string ToString()
        {
            var isC = isComplete() ? "complete" : "incomplete";
            var remind = getStartsAt().ToString(DATE_FORMATTER);
            return $"{getTitle()} at {remind} ({isC})";
        }
    }
}