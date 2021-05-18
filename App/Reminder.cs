using System;
using System.Text;

namespace App
{
    public class Reminder : CalendarItem, ICompletable
    {
        private bool complete;

        private readonly string description;
        private readonly DateTime remindsAt;

        public Reminder(string description, DateTime remindsAt)
        {
            this.description = description;
            this.remindsAt = remindsAt;
        }

        public string getDescription()
        {
            return description;
        }

        public string getTextToDisplay()
        {
            return getDescription();
        }

        public DateTime getRemindsAt()
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
                .Append($"TRIGGER:-{getRemindsAt().ToString("yyyy-MM-ddThh:mm")}\n")
                .Append("ACTION:DISPLAY\n")
                .Append($"UID:{getUuid()}@example.com\n")
                .Append($"DESCRIPTION:{getTextToDisplay()}\n")
                .Append("END:VALARM\n")
                .ToString();
        }

        public override string ToString()
        {
            var isC = isComplete() ? "complete" : "incomplete";
            var remind = getRemindsAt().ToString(DATE_FORMATTER);
            return $"{getDescription()} at {remind} ({isC})";
        }
    }
}