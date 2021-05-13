using System;

namespace App
{
    public abstract class CalendarItem : ICompletable
    {
        public static string DATE_FORMATTER = "MMM d, yyyy h:mm tt";
        private string uuid;

        public CalendarItem() {
            uuid =  Guid.NewGuid().ToString();
        }

        public string getUuid() {
            return uuid;
        }

        public abstract string iCalendar();

        public abstract string getTextToDisplay();

        public abstract void markComplete();

        public abstract void markIncomplete();

        public abstract bool isComplete();
    }
}
