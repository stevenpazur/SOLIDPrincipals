using System;
using System.Text;

namespace App
{
    public class Event : CalendarItem {

        private string title;
        private DateTime startsAt;
        private TimeSpan duration;

        public Event(string title, DateTime startsAt, TimeSpan duration) {
            this.title = title;
            this.startsAt = startsAt;
            this.duration = duration;
        }

        public string getTitle() {
            return title;
        }

        public override string getTextToDisplay() {
            return getTitle();
        }

        public DateTime getStartsAt() {
            return startsAt;
        }

        public TimeSpan getDuration() {
            return duration;
        }

        public DateTime getEndsAt() {
            return startsAt +  getDuration();
        }

        public override void markComplete() {
        }

        public override void markIncomplete() {
        }

        public override bool isComplete() {
            return false;
        }

        public override string iCalendar() {
            if (title == null) return "";

            return new StringBuilder()
                    .Append("BEGIN:VEVENT\n")
                    .Append($"DTSTART:{getStartsAt().ToString("yyyy-MM-ddThh:mm")}\n")
                    .Append($"DTEND:{getEndsAt().ToString("yyyy-MM-ddThh:mm")}\n")
                    .Append($"UID:{getUuid()}@example.com\n")
                    .Append($"DESCRIPTION:{getTextToDisplay()}\n")
                    .Append("END:VEVENT\n")
                    .ToString();
        }

        public override string ToString() {
            var a  = getTitle();
            var b = getStartsAt().ToString(DATE_FORMATTER);
            var c = getEndsAt().ToString(DATE_FORMATTER);
            return $"{a} at {b} (ends at {c})";
        }
    }
}
