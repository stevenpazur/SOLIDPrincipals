using System;
using System.Text;

namespace App
{
    public class Todo : CalendarItem, ICompletable
    {
        private DateTime? completedAt;
        private readonly Owner owner;
        private TodoStatus status = TodoStatus.INCOMPLETE;
        public string text { get; set; }
        public string description { get; set; }

        public Todo(string text, Owner owner)
        {
            this.text = text;
            this.owner = owner;
        }

        public string getTitle()
        {
            return text;
        }

        public string TextToDisplay()
        {
            return text;
        }

        public void markComplete()
        {
            status = TodoStatus.COMPLETE;
            completedAt = DateTime.Now;
        }

        public void markIncomplete()
        {
            status = TodoStatus.INCOMPLETE;
            completedAt = null;
        }

        public bool isComplete()
        {
            return status == TodoStatus.COMPLETE;
        }

        public DateTime? getCompletedAt()
        {
            return completedAt;
        }

        public Owner getOwner()
        {
            return owner;
        }

        public override string iCalendar()
        {
            if (text == null) return "";

            return new StringBuilder()
              .Append("BEGIN:VTODO\n")
              .Append($"COMPLETED::{getCompletedAt()}\n")
              .Append($"UID:{getUuid()}@example.com\n")
              .Append($"SUMMARY:{this.text}\n")
              .Append("END:VTODO\n")
              .ToString();
        }

        public override string ToString()
        {
            var a = this.text;
            var b = owner.getOwnerFirstName();
            var c = owner.getOwnerLastName();
            var d = owner.getOwnerEmail();
            var e = owner.getOwnerJobTitle();
            var f = status == TodoStatus.INCOMPLETE ? "incomplete" : "complete";

            return $"{a} <{b} {c}> {d} ({e}): {f}";
        }
    }
}