using System;
using System.Text;

namespace App
{
    public class Todo : CalendarItem, ICompletable
    {
        private DateTime? completedAt;
        private readonly Owner owner;
        private TodoStatus status = TodoStatus.INCOMPLETE;

        private readonly string text;

        public Todo(string text, Owner owner)
        {
            this.text = text;
            this.owner = owner;
        }

        public string getText()
        {
            return text;
        }

        public string getTextToDisplay()
        {
            return getText();
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
            if (text == null) throw new ArgumentException("You must specify the text");

            return new StringBuilder()
                .Append("BEGIN:VTODO\n")
                .Append($"COMPLETED::{getCompletedAt()}\n")
                .Append($"UID:{getUuid()}@example.com\n")
                .Append($"SUMMARY:{getTextToDisplay()}\n")
                .Append("END:VTODO\n")
                .ToString();
        }

        public override string ToString()
        {
            var a = getText();
            var b = owner.getOwnerFirstName();
            var c = owner.getOwnerLastName();
            var d = owner.getOwnerEmail();
            var e = owner.getOwnerJobTitle();
            var f = status == TodoStatus.INCOMPLETE ? "incomplete" : "complete";

            return $"{a} <{b} {c}> {d} ({e}): {f}";
        }
    }
}